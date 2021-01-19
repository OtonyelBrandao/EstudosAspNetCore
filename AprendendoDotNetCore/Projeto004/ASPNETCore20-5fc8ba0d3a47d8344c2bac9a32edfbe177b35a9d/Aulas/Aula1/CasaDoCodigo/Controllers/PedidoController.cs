using CasaDoCodigo.Models;
using CasaDoCodigo.Models.ViewModels;
using CasaDoCodigo.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CasaDoCodigo.Controllers
{
    public class PedidoController : Controller
    {
        private readonly IProdutoRepository produtoRepository;
        private readonly IPedidoRepository pedidoRepository;
        private readonly IItemPedidoRepository itempedidoRepository;
        private readonly ICadastroRepository cadastroRepository;

        public PedidoController(IProdutoRepository produtoRepository, IPedidoRepository pedidoRepository, IItemPedidoRepository itempedidoRepository, ICadastroRepository cadastroRepository)
        {
            this.produtoRepository = produtoRepository;
            this.pedidoRepository = pedidoRepository;
            this.itempedidoRepository = itempedidoRepository;
            this.cadastroRepository = cadastroRepository;
        }

        public IActionResult Carrossel()
        {
            return View(produtoRepository.GetProduto());
        }
        public IActionResult Carrinho(string codigo)
        {
            if (!string.IsNullOrEmpty(codigo))
            {
                pedidoRepository.AddItem(codigo);
            }
            List<ItemPedido> itens = pedidoRepository.GetPedido().Itens;
            CarrinhoViewModel carrinhoViewModel = new CarrinhoViewModel(itens);
            return base.View(carrinhoViewModel);
        }
        public IActionResult Cadastro()
        {
            var pedido = pedidoRepository.GetPedido();
            if (pedido == null)
            {
                return RedirectToAction("Carrossel");
            }
            return View(pedido.Cadastro);
        }
        [HttpPost]
        public IActionResult Resumo()
        {
            Pedido pedido = pedidoRepository.GetPedido();
            return View(pedido);
        }
        [HttpPost]
        public UpdateQuantidadeResponse UpdateQuantidade([FromBody]ItemPedido itemPedido)
        {
            return pedidoRepository.UpdateQuantidade(itemPedido);

        }
    }
}
