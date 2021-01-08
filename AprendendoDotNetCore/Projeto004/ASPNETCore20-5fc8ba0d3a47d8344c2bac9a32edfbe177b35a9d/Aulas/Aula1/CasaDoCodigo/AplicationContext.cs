using CasaDoCodigo.Models;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CasaDoCodigo
{
    public class AplicationContext : DbContext
    {
        public AplicationContext( DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //HasKey Para Indica Chave Primaria
            //HasMany Para Relacionamentos de 1 : n
            //HasOne Para Relacionamentos de 1 : 1
            //WithOne Para India Um relacionamento de Volta
            //IsRequered Para Indicar Que o atributo é obgrigatorio
            modelBuilder.Entity<Produto>().HasKey(t => t.Id);
            
            modelBuilder.Entity<Pedido>().HasKey(t => t.Id);
            modelBuilder.Entity<Pedido>().HasMany(t => t.Itens).WithOne(t => t.Pedido);
            modelBuilder.Entity<Pedido>().HasOne(t => t.Cadastro).WithOne(t => t.Pedido).IsRequired();

            modelBuilder.Entity<ItemPedido>().HasKey(t => t.Id);
            modelBuilder.Entity<ItemPedido>().HasOne(t => t.Pedido);
            modelBuilder.Entity<ItemPedido>().HasOne(t => t.Produto);


            modelBuilder.Entity<Cadastro>().HasKey(t => t.Id);
            modelBuilder.Entity<Cadastro>().HasOne(t => t.Pedido);
        }
    }
}
