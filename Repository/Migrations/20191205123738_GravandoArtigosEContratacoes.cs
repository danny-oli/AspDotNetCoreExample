using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Repository.Migrations
{
    public partial class GravandoArtigosEContratacoes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Artigos_Temas_TemaIdTema",
                table: "Artigos");

            migrationBuilder.DropIndex(
                name: "IX_Artigos_TemaIdTema",
                table: "Artigos");

            migrationBuilder.DropColumn(
                name: "TemaIdTema",
                table: "Artigos");

            migrationBuilder.AddColumn<string>(
                name: "Tema",
                table: "Artigos",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ContratacoesColunista",
                columns: table => new
                {
                    IdContratacaoColunista = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ColunistaAutorPessoaId = table.Column<int>(nullable: true),
                    DataHoraContratacao = table.Column<DateTime>(nullable: false),
                    ArtigoIdArtigo = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContratacoesColunista", x => x.IdContratacaoColunista);
                    table.ForeignKey(
                        name: "FK_ContratacoesColunista_Artigos_ArtigoIdArtigo",
                        column: x => x.ArtigoIdArtigo,
                        principalTable: "Artigos",
                        principalColumn: "IdArtigo",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ContratacoesColunista_Pessoas_ColunistaAutorPessoaId",
                        column: x => x.ColunistaAutorPessoaId,
                        principalTable: "Pessoas",
                        principalColumn: "PessoaId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ContratacoesColunista_ArtigoIdArtigo",
                table: "ContratacoesColunista",
                column: "ArtigoIdArtigo");

            migrationBuilder.CreateIndex(
                name: "IX_ContratacoesColunista_ColunistaAutorPessoaId",
                table: "ContratacoesColunista",
                column: "ColunistaAutorPessoaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContratacoesColunista");

            migrationBuilder.DropColumn(
                name: "Tema",
                table: "Artigos");

            migrationBuilder.AddColumn<int>(
                name: "TemaIdTema",
                table: "Artigos",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Artigos_TemaIdTema",
                table: "Artigos",
                column: "TemaIdTema");

            migrationBuilder.AddForeignKey(
                name: "FK_Artigos_Temas_TemaIdTema",
                table: "Artigos",
                column: "TemaIdTema",
                principalTable: "Temas",
                principalColumn: "IdTema",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
