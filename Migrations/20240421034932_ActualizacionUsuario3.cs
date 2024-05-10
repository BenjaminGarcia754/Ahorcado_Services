using Microsoft.EntityFrameworkCore.Migrations;

namespace Ahorcado_Services.Migrations
{
    public partial class ActualizacionUsuario3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "Jugadores",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Username",
                table: "Jugadores");
        }
    }
}
