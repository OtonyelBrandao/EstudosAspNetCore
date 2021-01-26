using CasaDoCodigo.Models;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CasaDoCodigo
{
    public interface IRelatorioHelper
    {
        Task GerarRelatorio(Pedido pedido);
    }

    public class RelatorioHelper : IRelatorioHelper
    {
        private const string RelativeUri = "/api/relatorio";
        private readonly IConfiguration configuration;
        private readonly HttpClient httpclient;
        public RelatorioHelper(IConfiguration configuration, HttpClient httpclient)
        {
            this.configuration = configuration;
            this.httpclient = httpclient;
        }
        public async Task GerarRelatorio(Pedido pedido)
        {
            string linhaRelatorio = await GetLinhaRelatorio(pedido);
            //using (HttpClient httpclient = new HttpClient())
            //using (HttpClient httpclient = HttpClientFactory.Create())
            //{
                var json = JsonConvert.SerializeObject(linhaRelatorio);
                HttpContent httpContent = new StringContent(json,Encoding.UTF8,"application/json");
                Uri BaseUri = new Uri(configuration["RelatorioWebApiURL"]);
                Uri uri = new Uri(BaseUri, RelativeUri);
                HttpResponseMessage httpResponseMessage
                    = await httpclient.PostAsync(uri, httpContent);
                if (!httpResponseMessage.IsSuccessStatusCode)
                {
                    throw new ApplicationException(httpResponseMessage.ReasonPhrase);
                }
            //}
                

            //await System.IO.File.AppendAllLinesAsync("Relatorio.txt", new string[] { linhaRelatorio });
        }

        private async Task<string> GetLinhaRelatorio(Pedido pedido)
        {
            StringBuilder sb = new StringBuilder();
            string templatePedido =
                    await System.IO.File.ReadAllTextAsync("TemplatePedido.txt");

            string templateItemPedido =
                await System.IO.File.ReadAllTextAsync("TemplateItemPedido.txt");

            string linhaPedido =
                string.Format(templatePedido,
                    pedido.Id,
                    pedido.Cadastro.Nome,
                    pedido.Cadastro.Endereco,
                    pedido.Cadastro.Complemento,
                    pedido.Cadastro.Bairro,
                    pedido.Cadastro.Municipio,
                    pedido.Cadastro.UF,
                    pedido.Cadastro.Telefone,
                    pedido.Cadastro.Email,
                    pedido.Itens.Sum(i => i.Subtotal));

            sb.AppendLine(linhaPedido);

            foreach (var i in pedido.Itens)
            {
                string linhaItemPedido =
                    string.Format(
                        templateItemPedido,
                        i.Produto.Codigo,
                        i.PrecoUnitario,
                        i.Produto.Nome,
                        i.Quantidade,
                        i.Subtotal);

                sb.AppendLine(linhaItemPedido);
            }
            sb.AppendLine($@"=============================================");

            return sb.ToString();
        }
    }
}