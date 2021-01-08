using CasaDoCodigo.Models;
using System.Collections.Generic;

namespace CasaDoCodigo.Repositories
{
    public interface IProdutoRepository
    {
        void SaveProdutos(List<Livro> Livros);
        IList<Produto> GetProduto();
    }
}