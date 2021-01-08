using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using CasaDoCodigo.Repositories;

namespace CasaDoCodigo
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSession();
            services.AddDistributedMemoryCache();
            //Adicionando Serviço transitorio de DataService e IDataService
            services.AddTransient<IDataService,DataService>();
            services.AddTransient<IProdutoRepository, ProdutoRepository>();
            //Fornecendo Serviço de padrão de arquitetura MVC.
            services.AddMvc();
            //Fornecendo Servico DeConexão com o banco de dados.
            //string ConectionString = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<AplicationContext>(options =>
                options.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=CasaDoCodigo;Integrated Security=True;Connect Timeout=300;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False")
                //para criar uma migração digite Add-Migration NomeDaMigration.

                //Para aDicionar as Tabelas ao banco Digite Update-DataBase.

                //Utilize -verbose para ter as informações no cmd.
            );
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env,
            IServiceProvider serviceProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();
            app.UseSession();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Pedido}/{action=Carrossel}/{codigo?}");
            });
            //Criação Automatica de Banco de Dados
            serviceProvider.GetService<IDataService>().InicializaDB();
            /*Você pode utilizar EnsurCreated Para Quando tiver fasendo 
              testes, Mas Para aplicações se utilisa Migrate*/
        }

    }
}
