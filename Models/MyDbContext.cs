using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using FranciscoDavidSantosSousa.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FranciscoDavidSantosSousa.Models
{
    public class MyDbContext:DbContext
    {
      public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
       {


       }

        public DbSet<NotaDeVenda> NotaDeVenda { get;set;}
        public DbSet<Cliente> Clientes { get;set;}
        public DbSet<Vendedor> Vendedors { get;set;}
        public DbSet<Transportadora> Transportadora { get;set;}
        public DbSet<Pagamento> Pagamento { get;set;}
        public DbSet<Item> Item { get;set;}
        public DbSet<Produto> Produto { get;set;}
        public DbSet<Marca> Marca { get;set;}
        public DbSet<TipoDePagamento> TipoDePagamento { get;set;}
        public DbSet<PagamentoComCheque> PagamentoComCheque { get;set;}
        public DbSet<PagamentoComCartao> PagamentoComCartao { get;set;}


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /*
            modelBuilder.Entity<Cliente>()
                .HasMany(c => c.NotaDeVenda)  // Um cliente possui muitas notas de venda
                .WithOne(n => n.Cliente)    // Uma nota de venda pertence a apenas um cliente
                .HasForeignKey(n => n.ClienteId);
            
            modelBuilder.Entity<Vendedor>()
            .HasMany(v => v.NotaDeVenda)
            .WithOne(n => n.Vendedor)
            .HasForeignKey(v => v.IdNotaDeVenda); 

            modelBuilder.Entity<Transportadora>()
            .HasMany(t => t.NotaDeVenda)
            .WithOne (n => n.Transportadora)
            .HasForeignKey(t => t.IdNotaDeVenda);

           modelBuilder.Entity<Pagamento>()
           .HasOne(n => n.NotaDeVenda)
           .WithMany(p => p.Pagamento)
            .HasForeignKey(n => n.IdPagamento);


           modelBuilder.Entity<TipoDePagamento>()
            .HasMany(t => t.NotaDeVenda)
            .WithOne(n => n.TipoDePagamento)
            .HasForeignKey(t => t.IdNotaDeVenda);

         modelBuilder.Entity<Produto>()
            .HasMany(p => p.Item)
            .WithOne(i => i.Produto)
            .HasForeignKey(p => p.IdItem);

        modelBuilder.Entity<Marca>()
            .HasMany(m => m.Produto)
            .WithOne(p => p.Marca)
            .HasForeignKey(m => m.IdProduto);

        modelBuilder.Entity<Item>()
         .HasOne(n => n.NotaDeVenda)
         .WithMany(i => i.Item)
         .HasForeignKey(n => n.NotaDeVendaId);
         */

         modelBuilder.Entity<NotaDeVenda>()
                .HasOne(n => n.Cliente)
                .WithMany(c => c.NotaDeVenda)
                .HasForeignKey(n => n.ClienteId);

            modelBuilder.Entity<NotaDeVenda>()
                .HasOne(n => n.Vendedor)
                .WithMany(v => v.NotaDeVenda)
                .HasForeignKey(n => n.VendedorId);

            modelBuilder.Entity<NotaDeVenda>()
                .HasOne(n => n.Transportadora)
                .WithMany(t => t.NotaDeVenda)
                .HasForeignKey(n => n.TransportadoraId);

            modelBuilder.Entity<Pagamento>()
                .HasOne(p => p.NotaDeVenda)
                .WithMany(n => n.Pagamento)
                .HasForeignKey(p => p.NotaDevendaId);

            modelBuilder.Entity<NotaDeVenda>()
                .HasOne(n => n.TipoDePagamento)
                .WithMany(tp => tp.NotaDeVenda)
                .HasForeignKey(n => n.PagamentoId);

            modelBuilder.Entity<Item>()
                .HasOne(i => i.Produto)
                .WithMany(p => p.Item)
                .HasForeignKey(i => i.ProdutoId);

            modelBuilder.Entity<Produto>()
                .HasOne(p => p.Marca)
                .WithMany(m => m.Produto)
                .HasForeignKey(p => p.MarcaId);

            modelBuilder.Entity<Item>()
                .HasOne(i => i.NotaDeVenda)
                .WithMany(n => n.Item)
                .HasForeignKey(i => i.NotaDeVendaId);
        }

    }
}