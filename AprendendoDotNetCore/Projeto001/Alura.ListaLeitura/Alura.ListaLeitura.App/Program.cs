using Alura.ListaLeitura.App.Negocio;
using Alura.ListaLeitura.App.Repositorio;
using System;
//Importação dos recursos de host do aspnet core
using Microsoft.AspNetCore.Hosting;



namespace Alura.ListaLeitura.App
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            LivroRepositorioCSV _repo = new LivroRepositorioCSV();
            //criação do hosta da aplicação
            IWebHost host = new WebHostBuilder()
                .UseKestrel()
                .UseStartup<Startup>()
                .Build();
            //Inicialização da aplicação
            host.Run();

            //ImprimeLista(_repo.ParaLer);
            //ImprimeLista(_repo.Lendo);
            //ImprimeLista(_repo.Lidos);
        }

        private static void ImprimeLista(ListaDeLeitura lista)
        {
            Console.WriteLine(lista);
        }
    }
}
