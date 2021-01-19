using CasaDoCodigo.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CasaDoCodigo.Repositories
{
    public interface IItemPedidoRepository
    {
        ItemPedido GetItemPedido(int ItemPedido);
        void RemoveItemPedido(int ItemPedido);
    }
    public class ItemPedidoRepository : BaseRepository<ItemPedido>, IItemPedidoRepository
    {
        public ItemPedidoRepository(AplicationContext context) : base(context)
        {
        }

        public ItemPedido GetItemPedido(int ItemPedidoID)
        {
            return dbSet.Where(ip => ip.Id == ItemPedidoID).SingleOrDefault();
        }

        public void RemoveItemPedido(int ItemPedido)
        {
            dbSet.Remove(GetItemPedido(ItemPedido));
        }
    }
}
