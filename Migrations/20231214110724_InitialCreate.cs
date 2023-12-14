using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FranciscoDavidSantosSousa.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    IdCliente = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nome = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NotaDeVendaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.IdCliente);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Marca",
                columns: table => new
                {
                    IdMarca = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    descricao = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ProdutoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Marca", x => x.IdMarca);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TipoDePagamento",
                columns: table => new
                {
                    IdTipoDePagamento = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nomeDoCobrado = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    informacoesAdicionais = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NotaDeVendaId = table.Column<int>(type: "int", nullable: true),
                    Discriminator = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    numeroDoCartao = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    bandeira = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    banco = table.Column<int>(type: "int", nullable: true),
                    nomeDoBanco = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoDePagamento", x => x.IdTipoDePagamento);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Transportadora",
                columns: table => new
                {
                    IdTransportadora = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nome = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NotaDevendaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transportadora", x => x.IdTransportadora);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Vendedors",
                columns: table => new
                {
                    IdVendedor = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nome = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NotaDeVendaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vendedors", x => x.IdVendedor);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Produto",
                columns: table => new
                {
                    IdProduto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nome = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    quantidade = table.Column<int>(type: "int", nullable: true),
                    preco = table.Column<double>(type: "double", nullable: true),
                    ItemId = table.Column<int>(type: "int", nullable: true),
                    MarcaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produto", x => x.IdProduto);
                    table.ForeignKey(
                        name: "FK_Produto_Marca_MarcaId",
                        column: x => x.MarcaId,
                        principalTable: "Marca",
                        principalColumn: "IdMarca");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "NotaDeVenda",
                columns: table => new
                {
                    IdNotaDeVenda = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DataDaVenda = table.Column<DateOnly>(type: "date", nullable: true),
                    tipo = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    cancelado = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    devolvido = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    TipoDePagamentoId = table.Column<int>(type: "int", nullable: true),
                    PagamentoId = table.Column<int>(type: "int", nullable: true),
                    TransportadoraId = table.Column<int>(type: "int", nullable: true),
                    VendedorId = table.Column<int>(type: "int", nullable: true),
                    ClienteId = table.Column<int>(type: "int", nullable: true),
                    ItemId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotaDeVenda", x => x.IdNotaDeVenda);
                    table.ForeignKey(
                        name: "FK_NotaDeVenda_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "IdCliente");
                    table.ForeignKey(
                        name: "FK_NotaDeVenda_TipoDePagamento_PagamentoId",
                        column: x => x.PagamentoId,
                        principalTable: "TipoDePagamento",
                        principalColumn: "IdTipoDePagamento");
                    table.ForeignKey(
                        name: "FK_NotaDeVenda_Transportadora_TransportadoraId",
                        column: x => x.TransportadoraId,
                        principalTable: "Transportadora",
                        principalColumn: "IdTransportadora");
                    table.ForeignKey(
                        name: "FK_NotaDeVenda_Vendedors_VendedorId",
                        column: x => x.VendedorId,
                        principalTable: "Vendedors",
                        principalColumn: "IdVendedor");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Item",
                columns: table => new
                {
                    IdItem = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    preco = table.Column<double>(type: "double", nullable: true),
                    percentual = table.Column<int>(type: "int", nullable: true),
                    quantidade = table.Column<int>(type: "int", nullable: true),
                    ProdutoId = table.Column<int>(type: "int", nullable: true),
                    NotaDeVendaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Item", x => x.IdItem);
                    table.ForeignKey(
                        name: "FK_Item_NotaDeVenda_NotaDeVendaId",
                        column: x => x.NotaDeVendaId,
                        principalTable: "NotaDeVenda",
                        principalColumn: "IdNotaDeVenda");
                    table.ForeignKey(
                        name: "FK_Item_Produto_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "Produto",
                        principalColumn: "IdProduto");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Pagamento",
                columns: table => new
                {
                    IdPagamento = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    dataLimite = table.Column<DateOnly>(type: "date", nullable: true),
                    valor = table.Column<double>(type: "double", nullable: true),
                    pago = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    NotaDevendaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pagamento", x => x.IdPagamento);
                    table.ForeignKey(
                        name: "FK_Pagamento_NotaDeVenda_NotaDevendaId",
                        column: x => x.NotaDevendaId,
                        principalTable: "NotaDeVenda",
                        principalColumn: "IdNotaDeVenda");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Item_NotaDeVendaId",
                table: "Item",
                column: "NotaDeVendaId");

            migrationBuilder.CreateIndex(
                name: "IX_Item_ProdutoId",
                table: "Item",
                column: "ProdutoId");

            migrationBuilder.CreateIndex(
                name: "IX_NotaDeVenda_ClienteId",
                table: "NotaDeVenda",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_NotaDeVenda_PagamentoId",
                table: "NotaDeVenda",
                column: "PagamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_NotaDeVenda_TransportadoraId",
                table: "NotaDeVenda",
                column: "TransportadoraId");

            migrationBuilder.CreateIndex(
                name: "IX_NotaDeVenda_VendedorId",
                table: "NotaDeVenda",
                column: "VendedorId");

            migrationBuilder.CreateIndex(
                name: "IX_Pagamento_NotaDevendaId",
                table: "Pagamento",
                column: "NotaDevendaId");

            migrationBuilder.CreateIndex(
                name: "IX_Produto_MarcaId",
                table: "Produto",
                column: "MarcaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Item");

            migrationBuilder.DropTable(
                name: "Pagamento");

            migrationBuilder.DropTable(
                name: "Produto");

            migrationBuilder.DropTable(
                name: "NotaDeVenda");

            migrationBuilder.DropTable(
                name: "Marca");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "TipoDePagamento");

            migrationBuilder.DropTable(
                name: "Transportadora");

            migrationBuilder.DropTable(
                name: "Vendedors");
        }
    }
}
