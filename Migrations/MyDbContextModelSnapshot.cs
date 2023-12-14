﻿// <auto-generated />
using System;
using FranciscoDavidSantosSousa.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FranciscoDavidSantosSousa.Migrations
{
    [DbContext(typeof(MyDbContext))]
    partial class MyDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("FranciscoDavidSantosSousa.Models.Cliente", b =>
                {
                    b.Property<int>("IdCliente")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("NotaDeVendaId")
                        .HasColumnType("int");

                    b.Property<string>("nome")
                        .HasColumnType("longtext");

                    b.HasKey("IdCliente");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("FranciscoDavidSantosSousa.Models.Item", b =>
                {
                    b.Property<int>("IdItem")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("NotaDeVendaId")
                        .HasColumnType("int");

                    b.Property<int?>("ProdutoId")
                        .HasColumnType("int");

                    b.Property<int?>("percentual")
                        .HasColumnType("int");

                    b.Property<double?>("preco")
                        .HasColumnType("double");

                    b.Property<int?>("quantidade")
                        .HasColumnType("int");

                    b.HasKey("IdItem");

                    b.HasIndex("NotaDeVendaId");

                    b.HasIndex("ProdutoId");

                    b.ToTable("Item");
                });

            modelBuilder.Entity("FranciscoDavidSantosSousa.Models.Marca", b =>
                {
                    b.Property<int>("IdMarca")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("ProdutoId")
                        .HasColumnType("int");

                    b.Property<string>("descricao")
                        .HasColumnType("longtext");

                    b.HasKey("IdMarca");

                    b.ToTable("Marca");
                });

            modelBuilder.Entity("FranciscoDavidSantosSousa.Models.NotaDeVenda", b =>
                {
                    b.Property<int>("IdNotaDeVenda")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("ClienteId")
                        .HasColumnType("int");

                    b.Property<DateOnly?>("DataDaVenda")
                        .HasColumnType("date");

                    b.Property<int?>("ItemId")
                        .HasColumnType("int");

                    b.Property<int?>("PagamentoId")
                        .HasColumnType("int");

                    b.Property<int?>("TipoDePagamentoId")
                        .HasColumnType("int");

                    b.Property<int?>("TransportadoraId")
                        .HasColumnType("int");

                    b.Property<int?>("VendedorId")
                        .HasColumnType("int");

                    b.Property<bool?>("cancelado")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool?>("devolvido")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool?>("tipo")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("IdNotaDeVenda");

                    b.HasIndex("ClienteId");

                    b.HasIndex("PagamentoId");

                    b.HasIndex("TransportadoraId");

                    b.HasIndex("VendedorId");

                    b.ToTable("NotaDeVenda");
                });

            modelBuilder.Entity("FranciscoDavidSantosSousa.Models.Pagamento", b =>
                {
                    b.Property<int>("IdPagamento")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("NotaDevendaId")
                        .HasColumnType("int");

                    b.Property<DateOnly?>("dataLimite")
                        .HasColumnType("date");

                    b.Property<bool?>("pago")
                        .HasColumnType("tinyint(1)");

                    b.Property<double?>("valor")
                        .HasColumnType("double");

                    b.HasKey("IdPagamento");

                    b.HasIndex("NotaDevendaId");

                    b.ToTable("Pagamento");
                });

            modelBuilder.Entity("FranciscoDavidSantosSousa.Models.Produto", b =>
                {
                    b.Property<int>("IdProduto")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("ItemId")
                        .HasColumnType("int");

                    b.Property<int?>("MarcaId")
                        .HasColumnType("int");

                    b.Property<string>("nome")
                        .HasColumnType("longtext");

                    b.Property<double?>("preco")
                        .HasColumnType("double");

                    b.Property<int?>("quantidade")
                        .HasColumnType("int");

                    b.HasKey("IdProduto");

                    b.HasIndex("MarcaId");

                    b.ToTable("Produto");
                });

            modelBuilder.Entity("FranciscoDavidSantosSousa.Models.TipoDePagamento", b =>
                {
                    b.Property<int>("IdTipoDePagamento")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int?>("NotaDeVendaId")
                        .HasColumnType("int");

                    b.Property<string>("informacoesAdicionais")
                        .HasColumnType("longtext");

                    b.Property<string>("nomeDoCobrado")
                        .HasColumnType("longtext");

                    b.HasKey("IdTipoDePagamento");

                    b.ToTable("TipoDePagamento");

                    b.HasDiscriminator<string>("Discriminator").HasValue("TipoDePagamento");
                });

            modelBuilder.Entity("FranciscoDavidSantosSousa.Models.Transportadora", b =>
                {
                    b.Property<int>("IdTransportadora")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("NotaDevendaId")
                        .HasColumnType("int");

                    b.Property<string>("nome")
                        .HasColumnType("longtext");

                    b.HasKey("IdTransportadora");

                    b.ToTable("Transportadora");
                });

            modelBuilder.Entity("FranciscoDavidSantosSousa.Models.Vendedor", b =>
                {
                    b.Property<int>("IdVendedor")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("NotaDeVendaId")
                        .HasColumnType("int");

                    b.Property<string>("nome")
                        .HasColumnType("longtext");

                    b.HasKey("IdVendedor");

                    b.ToTable("Vendedors");
                });

            modelBuilder.Entity("FranciscoDavidSantosSousa.Models.PagamentoComCartao", b =>
                {
                    b.HasBaseType("FranciscoDavidSantosSousa.Models.TipoDePagamento");

                    b.Property<string>("bandeira")
                        .HasColumnType("longtext");

                    b.Property<string>("numeroDoCartao")
                        .HasColumnType("longtext");

                    b.HasDiscriminator().HasValue("PagamentoComCartao");
                });

            modelBuilder.Entity("FranciscoDavidSantosSousa.Models.PagamentoComCheque", b =>
                {
                    b.HasBaseType("FranciscoDavidSantosSousa.Models.TipoDePagamento");

                    b.Property<int?>("banco")
                        .HasColumnType("int");

                    b.Property<string>("nomeDoBanco")
                        .HasColumnType("longtext");

                    b.HasDiscriminator().HasValue("PagamentoComCheque");
                });

            modelBuilder.Entity("FranciscoDavidSantosSousa.Models.Item", b =>
                {
                    b.HasOne("FranciscoDavidSantosSousa.Models.NotaDeVenda", "NotaDeVenda")
                        .WithMany("Item")
                        .HasForeignKey("NotaDeVendaId");

                    b.HasOne("FranciscoDavidSantosSousa.Models.Produto", "Produto")
                        .WithMany("Item")
                        .HasForeignKey("ProdutoId");

                    b.Navigation("NotaDeVenda");

                    b.Navigation("Produto");
                });

            modelBuilder.Entity("FranciscoDavidSantosSousa.Models.NotaDeVenda", b =>
                {
                    b.HasOne("FranciscoDavidSantosSousa.Models.Cliente", "Cliente")
                        .WithMany("NotaDeVenda")
                        .HasForeignKey("ClienteId");

                    b.HasOne("FranciscoDavidSantosSousa.Models.TipoDePagamento", "TipoDePagamento")
                        .WithMany("NotaDeVenda")
                        .HasForeignKey("PagamentoId");

                    b.HasOne("FranciscoDavidSantosSousa.Models.Transportadora", "Transportadora")
                        .WithMany("NotaDeVenda")
                        .HasForeignKey("TransportadoraId");

                    b.HasOne("FranciscoDavidSantosSousa.Models.Vendedor", "Vendedor")
                        .WithMany("NotaDeVenda")
                        .HasForeignKey("VendedorId");

                    b.Navigation("Cliente");

                    b.Navigation("TipoDePagamento");

                    b.Navigation("Transportadora");

                    b.Navigation("Vendedor");
                });

            modelBuilder.Entity("FranciscoDavidSantosSousa.Models.Pagamento", b =>
                {
                    b.HasOne("FranciscoDavidSantosSousa.Models.NotaDeVenda", "NotaDeVenda")
                        .WithMany("Pagamento")
                        .HasForeignKey("NotaDevendaId");

                    b.Navigation("NotaDeVenda");
                });

            modelBuilder.Entity("FranciscoDavidSantosSousa.Models.Produto", b =>
                {
                    b.HasOne("FranciscoDavidSantosSousa.Models.Marca", "Marca")
                        .WithMany("Produto")
                        .HasForeignKey("MarcaId");

                    b.Navigation("Marca");
                });

            modelBuilder.Entity("FranciscoDavidSantosSousa.Models.Cliente", b =>
                {
                    b.Navigation("NotaDeVenda");
                });

            modelBuilder.Entity("FranciscoDavidSantosSousa.Models.Marca", b =>
                {
                    b.Navigation("Produto");
                });

            modelBuilder.Entity("FranciscoDavidSantosSousa.Models.NotaDeVenda", b =>
                {
                    b.Navigation("Item");

                    b.Navigation("Pagamento");
                });

            modelBuilder.Entity("FranciscoDavidSantosSousa.Models.Produto", b =>
                {
                    b.Navigation("Item");
                });

            modelBuilder.Entity("FranciscoDavidSantosSousa.Models.TipoDePagamento", b =>
                {
                    b.Navigation("NotaDeVenda");
                });

            modelBuilder.Entity("FranciscoDavidSantosSousa.Models.Transportadora", b =>
                {
                    b.Navigation("NotaDeVenda");
                });

            modelBuilder.Entity("FranciscoDavidSantosSousa.Models.Vendedor", b =>
                {
                    b.Navigation("NotaDeVenda");
                });
#pragma warning restore 612, 618
        }
    }
}
