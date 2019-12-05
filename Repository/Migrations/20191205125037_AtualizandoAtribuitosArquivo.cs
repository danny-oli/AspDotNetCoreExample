using Microsoft.EntityFrameworkCore.Migrations;

namespace Repository.Migrations
{
    public partial class AtualizandoAtribuitosArquivo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Artigos_Pessoas_ColunistaAutorPessoaId",
                table: "Artigos");

            migrationBuilder.DropForeignKey(
                name: "FK_ContratacoesColunista_Pessoas_ColunistaAutorPessoaId",
                table: "ContratacoesColunista");

            migrationBuilder.DropIndex(
                name: "IX_ContratacoesColunista_ColunistaAutorPessoaId",
                table: "ContratacoesColunista");

            migrationBuilder.DropIndex(
                name: "IX_Artigos_ColunistaAutorPessoaId",
                table: "Artigos");

            migrationBuilder.DropColumn(
                name: "ColunistaAutorPessoaId",
                table: "ContratacoesColunista");

            migrationBuilder.DropColumn(
                name: "ColunistaAutorPessoaId",
                table: "Artigos");

            migrationBuilder.AddColumn<string>(
                name: "ColunistaAutor",
                table: "ContratacoesColunista",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NomeColunista",
                table: "Artigos",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ColunistaAutor",
                table: "ContratacoesColunista");

            migrationBuilder.DropColumn(
                name: "NomeColunista",
                table: "Artigos");

            migrationBuilder.AddColumn<int>(
                name: "ColunistaAutorPessoaId",
                table: "ContratacoesColunista",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ColunistaAutorPessoaId",
                table: "Artigos",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ContratacoesColunista_ColunistaAutorPessoaId",
                table: "ContratacoesColunista",
                column: "ColunistaAutorPessoaId");

            migrationBuilder.CreateIndex(
                name: "IX_Artigos_ColunistaAutorPessoaId",
                table: "Artigos",
                column: "ColunistaAutorPessoaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Artigos_Pessoas_ColunistaAutorPessoaId",
                table: "Artigos",
                column: "ColunistaAutorPessoaId",
                principalTable: "Pessoas",
                principalColumn: "PessoaId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ContratacoesColunista_Pessoas_ColunistaAutorPessoaId",
                table: "ContratacoesColunista",
                column: "ColunistaAutorPessoaId",
                principalTable: "Pessoas",
                principalColumn: "PessoaId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
