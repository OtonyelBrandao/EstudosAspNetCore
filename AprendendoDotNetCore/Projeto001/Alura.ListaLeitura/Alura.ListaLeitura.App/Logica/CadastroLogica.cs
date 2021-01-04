using Alura.ListaLeitura.App.HTML;
using Alura.ListaLeitura.App.Negocio;
using Alura.ListaLeitura.App.Repositorio;

namespace Alura.ListaLeitura.App.Logica
{
    internal class CadastroController
    {
        //public string ProcessaFormulario()
        //{
        //    Livro livro = new Livro()
        //    {
        //        //pega informações pela rota
        //        //Autor = Convert.ToString(context.GetRouteValue("autor")),
        //        //Titulo = Convert.ToString(context.GetRouteValue("nome"))

        //        //pega informações atraves da QueryString
        //        //Autor = context.Request.Query["autor"].First(),
        //        //Titulo = context.Request.Query["nome"].First()

        //        //pega informações atraves do formulario com metodo post
        //        Autor = context.Request.Form["autor"].First(),
        //        Titulo = context.Request.Form["nome"].First()
        //    };
        //    LivroRepositorioCSV _repo = new LivroRepositorioCSV();
        //    _repo.Incluir(livro);
        //    return "Livro Criado !!";
        //}
        public string Formulario()
        {
            string html = HtmlUtils.CaregaArquivoHTML("formulario");
            return html;
        }

        public string NovoLivroParaLer(Livro livro)
        {
            LivroRepositorioCSV _repo = new LivroRepositorioCSV();
            _repo.Incluir(livro);
            return "Livro Criado !!";
        }

    }
}
