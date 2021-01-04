using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;

namespace Alura.ListaLeitura.App
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRouting();
            services.AddMvc();
        }
        public void Configure(IApplicationBuilder app)
        {
            RouteBuilder builder = new RouteBuilder(app);

            app.UseMvcWithDefaultRoute();

            //builder.MapRoute("Livros/ParaLer", LivrosLogica.LivrosParaLer);
            //builder.MapRoute("Livros/Lendo", LivrosLogica.LivrosLendo);
            //builder.MapRoute("Livros/Lidos", LivrosLogica.LivrosLidos);
            //builder.MapRoute("Cadastro/Novolivro/{nome}/{autor}", CadastroLogica.NovoLivroParaLer);
            //builder.MapRoute("Livros/Detalhes/{id:int}", LivrosLogica.Detalhes);
            //builder.MapRoute("Cadastro/Novolivro", CadastroLogica.ExibeFormulario);
            //builder.MapRoute("Cadastro/Incluir", CadastroLogica.ProcessaFormulario);
            //IRouter rotas = builder.Build();
            //app.UseRouter(rotas);

            //app.Run(Roteamento);
        }

        //Sistema de Roteamento 
        //Sistema para identificar um Request e qualificalo par um Response
        //public Task Roteamento(HttpContext context)
        //{
        //    Dictionary<string, RequestDelegate> caminhosAtendidos = new Dictionary<string, RequestDelegate>
        //    {
        //        {"/Livros/ParaLer",LivrosParaLer },
        //        {"/Livros/Lendo", LivrosLendo},
        //        {"/Livros/Lidos", LivrosLidos}
        //    };
        //    if (caminhosAtendidos.ContainsKey(context.Request.Path))
        //    {
        //        RequestDelegate metodo = caminhosAtendidos[context.Request.Path];
        //        return metodo.Invoke(context);
        //    }
        //    context.Response.StatusCode = 404;
        //    return context.Response.WriteAsync("Caminho inexistente !!");
        //}
    }
}