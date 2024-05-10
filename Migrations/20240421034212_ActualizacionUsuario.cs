using Microsoft.EntityFrameworkCore.Migrations;

namespace Ahorcado_Services.Migrations
{
    public partial class ActualizacionUsuario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Correo",
                table: "Jugadores",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Jugadores_Correo",
                table: "Jugadores",
                column: "Correo",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Jugadores_Correo",
                table: "Jugadores");

            migrationBuilder.AlterColumn<string>(
                name: "Correo",
                table: "Jugadores",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string));
        }
    }
}
