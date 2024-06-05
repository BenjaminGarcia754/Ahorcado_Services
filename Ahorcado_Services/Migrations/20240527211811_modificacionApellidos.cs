using Microsoft.EntityFrameworkCore.Migrations;

namespace Ahorcado_Services.Migrations
{
    public partial class modificacionApellidos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Apellidos",
                table: "Jugadores");

            migrationBuilder.AddColumn<string>(
                name: "palabraSeleccionada",
                table: "Partidas",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApellidoMaterno",
                table: "Jugadores",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ApellidoPaterno",
                table: "Jugadores",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "palabraSeleccionada",
                table: "Partidas");

            migrationBuilder.DropColumn(
                name: "ApellidoMaterno",
                table: "Jugadores");

            migrationBuilder.DropColumn(
                name: "ApellidoPaterno",
                table: "Jugadores");

            migrationBuilder.AddColumn<string>(
                name: "Apellidos",
                table: "Jugadores",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
