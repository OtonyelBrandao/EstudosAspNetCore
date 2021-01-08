using CasaDoCodigo.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CasaDoCodigo.Repositories
{
    public class ProdutoRepository : BaseRepository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(AplicationContext context) : base(context)
        {
        }

        public IList<Produto> GetProduto()
        {
            return dbSet.ToList();
        }

        public void SaveProdutos(List<Livro> Livros)
        {
            //Criando Livros Apartir Da variavel List<Livro> chamada Livros.
            foreach (var livro in Livros)
            {
                if (!dbSet.Where(p => p.Codigo == livro.Codigo).Any())
                {
                    dbSet.Add(new Produto(livro.Codigo, livro.Nome, livro.Preco));
                }

            }
            //Salvando no Banco De Dados.
            context.SaveChanges();
        }

    }
    public class Livro
    {
        public string Codigo { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
    }
}
