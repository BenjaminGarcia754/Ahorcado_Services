using Microsoft.EntityFrameworkCore.Migrations;

namespace Ahorcado_Services.Migrations
{
    public partial class CorreccionIdiomaPartida : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdiomaPartida",
                table: "Palabras");

            migrationBuilder.AddColumn<string>(
                name: "IdiomaPartida",
                table: "Partidas",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdiomaPartida",
                table: "Partidas");

            migrationBuilder.AddColumn<string>(
                name: "IdiomaPartida",
                table: "Palabras",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
