using CasaDoCodigo.Models;
using CasaDoCodigo.Repositories;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace CasaDoCodigo
{
    class DataService : IDataService
    {
        private readonly AplicationContext context;
        private readonly IProdutoRepository produtoRepository;

        public DataService(AplicationContext context,IProdutoRepository produtoRepository)
        {
            this.context = context;
            this.produtoRepository = produtoRepository;
        }

        public void InicializaDB()
        {
            //File.ReadAllText << Ler todo o texto de um arquivo.
            //JsonConvert.DeserializeObiject fragmenta uma string em objetos.
            context
                .Database
                .Migrate();
            List<Livro> Livros = GetLivros();
            produtoRepository.SaveProdutos(Livros);
        }

        

        private static List<Livro> GetLivros()
        {
            //Lendo Arquivo e Gravando Navariavel.
            var json = File.ReadAllText("livros.json");
            //Tranformando a VariaVel e Obijatos Chamados de Livro e 
            //quardando na variavel Livros.
            var Livros = JsonConvert.DeserializeObject<List<Livro>>(json);
            return Livros;
        }
    }
    
}
