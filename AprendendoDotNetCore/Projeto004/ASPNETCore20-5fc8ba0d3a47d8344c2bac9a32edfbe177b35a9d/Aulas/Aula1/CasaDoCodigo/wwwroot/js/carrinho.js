class Carrinho {
    ClickIncremento(btn) {
        let data = this.GetData(btn);
        data.Quantidade++;
        this.PostGetData(data);
    }
    ClickDecremento(btn) {
        let data = this.GetData(btn);
        data.Quantidade--;
        this.PostGetData(data);
    };
    updateQuantidade(input) {
        let data = this.GetData(input);
        this.PostGetData(data);
    };
    GetData(elemento) {
        var linhaDoItem = $(elemento).parents('[item-id]')
        var itemid = $(linhaDoItem).attr("item-id");
        var novaQtde = $(linhaDoItem).find('input').val();
        
        return {
            Id: itemid,
            Quantidade: novaQtde
        };
    }
    PostGetData(data) {

        let token = $('[name=__RequestVerificationToken]').val();
        let headers = {};
        headers['RequestVerificationToken'] = token;

        $.ajax({
            url: '/Pedido/UpdateQuantidade',
            type: 'Post',
            contentType: 'application/json',
            data: JSON.stringify(data),
            headers: headers
        }).done(function (response) {
            let itempedido = response.itemPedido;
            var linhadoitem = $('[item-id=' + itempedido.id + ']');
            linhadoitem.find('input').val(itempedido.quantidade);
            linhadoitem.find('[subtotal]').html((itempedido.precoUnitario * itempedido.quantidade).duasCasas());
            var carrinhoViewModel = response.carrinhoViewModel;
            $('[numero-itens]').html('Total: ' + carrinhoViewModel.itens.length + ' itens')
            $('[total]').html((carrinhoViewModel.total).duasCasas())
            if (itempedido.quantidade == 0) {
                linhadoitem.remove();
            }
            //debugger;
        });
}
}
var carrinho = new Carrinho();
Number.prototype.duasCasas = function() {
    return this.toFixed(2).replace('.', ',');
}