using Alura.ListaLeitura.App.HTML;
using Alura.ListaLeitura.App.Negocio;
using Alura.ListaLeitura.App.Repositorio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.ListaLeitura.App.Logica
{
    class LivrosController
    {
        public string ParaLer()
        {
            LivroRepositorioCSV _repo = new LivroRepositorioCSV();

            var conteudoArquivo = HtmlUtils.CaregaArquivoHTML("para-ler");
            //Edição basica atraves de om foreach e metodo Replace
            foreach (var livro in _repo.ParaLer.Livros)
            {
                conteudoArquivo = conteudoArquivo
                    .Replace(
                    "#NovoItem#"
                    , $"<li>{livro.Titulo} - {livro.Autor}</li>#NovoItem#");
            }
            conteudoArquivo = conteudoArquivo.Replace("#NovoItem#", "");
            return conteudoArquivo;
        }
        public string Lendo(HttpContext context)
        {
            LivroRepositorioCSV _repo = new LivroRepositorioCSV();
            return _repo.Lendo.ToString();
        }
        public string Lidos(HttpContext context)
        {
            LivroRepositorioCSV _repo = new LivroRepositorioCSV();
            return _repo.Lidos.ToString();
        }
        public string Detalhes(int id)
        {
            LivroRepositorioCSV _repo = new LivroRepositorioCSV();
            Livro livro = _repo.Todos.First(l => l.Id == id);
            return livro.Detalhes();

        }
        
    }
}
