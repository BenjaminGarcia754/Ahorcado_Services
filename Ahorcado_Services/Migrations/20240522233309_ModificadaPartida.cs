using Microsoft.EntityFrameworkCore.Migrations;

namespace Ahorcado_Services.Migrations
{
    public partial class ModificadaPartida : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PartidaGanada",
                table: "Partidas");

            migrationBuilder.AddColumn<bool>(
                name: "PartidaGanadaJugadorAnfitrion",
                table: "Partidas",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "PartidaGanadaJugadorInvitado",
                table: "Partidas",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PartidaGanadaJugadorAnfitrion",
                table: "Partidas");

            migrationBuilder.DropColumn(
                name: "PartidaGanadaJugadorInvitado",
                table: "Partidas");

            migrationBuilder.AddColumn<bool>(
                name: "PartidaGanada",
                table: "Partidas",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
