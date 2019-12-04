using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Repository.Migrations
{
    public partial class DbCreaation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pessoas",
                columns: table => new
                {
                    PessoaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: true),
                    CPf = table.Column<int>(nullable: false),
                    Cep = table.Column<int>(nullable: false),
                    Password = table.Column<string>(nullable: true),
                    Discriminator = table.Column<string>(nullable: false),
                    Saldo = table.Column<int>(nullable: true),
                    SaldoColunista = table.Column<int>(nullable: true),
                    ClientePessoaId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pessoas", x => x.PessoaId);
                    table.ForeignKey(
                        name: "FK_Pessoas_Pessoas_ClientePessoaId",
                        column: x => x.ClientePessoaId,
                        principalTable: "Pessoas",
                        principalColumn: "PessoaId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Produtos",
                columns: table => new
                {
                    IdProduto = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: false),
                    Descricao = table.Column<string>(maxLength: 100, nullable: false),
                    Preco = table.Column<double>(nullable: false),
                    Quantidade = table.Column<int>(nullable: false),
                    CriadoEm = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produtos", x => x.IdProduto);
                });

            migrationBuilder.CreateTable(
                name: "Temas",
                columns: table => new
                {
                    IdTema = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    tema = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Temas", x => x.IdTema);
                });

            migrationBuilder.CreateTable(
                name: "Artigos",
                columns: table => new
                {
                    IdArtigo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CriadoEm = table.Column<DateTime>(nullable: false),
                    ColunistaAutorPessoaId = table.Column<int>(nullable: true),
                    TemaIdTema = table.Column<int>(nullable: true),
                    Titulo = table.Column<string>(nullable: true),
                    Texto = table.Column<string>(nullable: true),
                    Valor = table.Column<int>(nullable: false),
                    Paginas = table.Column<int>(nullable: false),
                    ClientePessoaId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artigos", x => x.IdArtigo);
                    table.ForeignKey(
                        name: "FK_Artigos_Pessoas_ClientePessoaId",
                        column: x => x.ClientePessoaId,
                        principalTable: "Pessoas",
                        principalColumn: "PessoaId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Artigos_Pessoas_ColunistaAutorPessoaId",
                        column: x => x.ColunistaAutorPessoaId,
                        principalTable: "Pessoas",
                        principalColumn: "PessoaId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Artigos_Temas_TemaIdTema",
                        column: x => x.TemaIdTema,
                        principalTable: "Temas",
                        principalColumn: "IdTema",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Contratacoes",
                columns: table => new
                {
                    IdContratacao = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClienteContrataPessoaId = table.Column<int>(nullable: true),
                    DataHoraContratacao = table.Column<DateTime>(nullable: false),
                    ValorContratacao = table.Column<double>(nullable: false),
                    ArtigoIdArtigo = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contratacoes", x => x.IdContratacao);
                    table.ForeignKey(
                        name: "FK_Contratacoes_Artigos_ArtigoIdArtigo",
                        column: x => x.ArtigoIdArtigo,
                        principalTable: "Artigos",
                        principalColumn: "IdArtigo",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Contratacoes_Pessoas_ClienteContrataPessoaId",
                        column: x => x.ClienteContrataPessoaId,
                        principalTable: "Pessoas",
                        principalColumn: "PessoaId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Artigos_ClientePessoaId",
                table: "Artigos",
                column: "ClientePessoaId");

            migrationBuilder.CreateIndex(
                name: "IX_Artigos_ColunistaAutorPessoaId",
                table: "Artigos",
                column: "ColunistaAutorPessoaId");

            migrationBuilder.CreateIndex(
                name: "IX_Artigos_TemaIdTema",
                table: "Artigos",
                column: "TemaIdTema");

            migrationBuilder.CreateIndex(
                name: "IX_Contratacoes_ArtigoIdArtigo",
                table: "Contratacoes",
                column: "ArtigoIdArtigo");

            migrationBuilder.CreateIndex(
                name: "IX_Contratacoes_ClienteContrataPessoaId",
                table: "Contratacoes",
                column: "ClienteContrataPessoaId");

            migrationBuilder.CreateIndex(
                name: "IX_Pessoas_ClientePessoaId",
                table: "Pessoas",
                column: "ClientePessoaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contratacoes");

            migrationBuilder.DropTable(
                name: "Produtos");

            migrationBuilder.DropTable(
                name: "Artigos");

            migrationBuilder.DropTable(
                name: "Pessoas");

            migrationBuilder.DropTable(
                name: "Temas");
        }
    }
}
