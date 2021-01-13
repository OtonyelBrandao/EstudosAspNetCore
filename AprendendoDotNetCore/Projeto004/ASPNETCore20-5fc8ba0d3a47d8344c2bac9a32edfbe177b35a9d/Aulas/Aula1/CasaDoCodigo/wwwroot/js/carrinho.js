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
    PostGetData(data){
        $.ajax({
            url: '/Pedido/UpdateQuantidade',
            type: 'Post',
            contentType: 'application/json',
            data: JSON.stringify(data)

        });
}
}
var carrinho = new Carrinho();