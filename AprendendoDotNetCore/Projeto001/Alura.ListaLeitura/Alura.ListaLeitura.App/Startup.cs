using Alura.ListaLeitura.App.Negocio;
using Alura.ListaLeitura.App.Repositorio;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alura.ListaLeitura.App
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRouting();
        }
        public void Configure(IApplicationBuilder app)
        {
            RouteBuilder builder = new RouteBuilder(app);
            builder.MapRoute("Livros/ParaLer", LivrosParaLer);
            builder.MapRoute("Livros/Lendo", LivrosLendo);
            builder.MapRoute("Livros/Lidos", LivrosLidos);
            builder.MapRoute("Cadastro/Novolivro/{nome}/{autor}", NovoLivroParaLer);
            builder.MapRoute("Livros/Detalhes/{id:int}", ExibeDetalhes);
            IRouter rotas = builder.Build();
            app.UseRouter(rotas);
            //app.Run(Roteamento);
        }

        private Task ExibeDetalhes(HttpContext context)
        {
            int id = Convert.ToInt32(context.GetRouteValue("id"));
            LivroRepositorioCSV _repo = new LivroRepositorioCSV();
            var livro = _repo.Todos.First(l => l.Id == id);
            return context.Response.WriteAsync(livro.Detalhes());

        }

        public Task NovoLivroParaLer(HttpContext context)
        {
            Livro livro = new Livro()
            {
                Autor = Convert.ToString(context.GetRouteValue("autor")),
                Titulo = Convert.ToString(context.GetRouteValue("nome"))
            };
            LivroRepositorioCSV _repo = new LivroRepositorioCSV();
            _repo.Incluir(livro);
            return context.Response.WriteAsync("Livro Criado !!");
        }

        //Sistema de Roteamento 
        //Sistema para identificar um Request e qualificalo par um Response
        public Task Roteamento(HttpContext context)
        {
            Dictionary<string, RequestDelegate> caminhosAtendidos = new Dictionary<string, RequestDelegate>
            {
                {"/Livros/ParaLer",LivrosParaLer },
                {"/Livros/Lendo", LivrosLendo},
                {"/Livros/Lidos", LivrosLidos}
            };
            if (caminhosAtendidos.ContainsKey(context.Request.Path))
            {
                RequestDelegate metodo = caminhosAtendidos[context.Request.Path];
                return metodo.Invoke(context);
            }
            context.Response.StatusCode = 404;
            return context.Response.WriteAsync("Caminho inexistente !!");
        }
        public Task LivrosParaLer(HttpContext context)
        {
            LivroRepositorioCSV _repo = new LivroRepositorioCSV();
            return context.Response.WriteAsync(_repo.ParaLer.ToString());
        }
        public Task LivrosLendo(HttpContext context)
        {
            LivroRepositorioCSV _repo = new LivroRepositorioCSV();
            return context.Response.WriteAsync(_repo.Lendo.ToString());
        }
        public Task LivrosLidos(HttpContext context)
        {
            LivroRepositorioCSV _repo = new LivroRepositorioCSV();
            return context.Response.WriteAsync(_repo.Lidos.ToString());
        }

    }
}