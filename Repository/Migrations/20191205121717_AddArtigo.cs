using Microsoft.EntityFrameworkCore.Migrations;

namespace Repository.Migrations
{
    public partial class AddArtigo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ArtigoPaginas",
                table: "Pessoas",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ArtigoTema",
                table: "Pessoas",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ArtigoTexto",
                table: "Pessoas",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ArtigoTitulo",
                table: "Pessoas",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ArtigoPaginas",
                table: "Pessoas");

            migrationBuilder.DropColumn(
                name: "ArtigoTema",
                table: "Pessoas");

            migrationBuilder.DropColumn(
                name: "ArtigoTexto",
                table: "Pessoas");

            migrationBuilder.DropColumn(
                name: "ArtigoTitulo",
                table: "Pessoas");
        }
    }
}
