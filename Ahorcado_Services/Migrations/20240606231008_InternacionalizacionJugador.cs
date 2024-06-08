using Microsoft.EntityFrameworkCore.Migrations;

namespace Ahorcado_Services.Migrations
{
    public partial class InternacionalizacionJugador : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ApellidoMaterno",
                table: "Jugadores",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ApellidoMaterno",
                table: "Jugadores",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
