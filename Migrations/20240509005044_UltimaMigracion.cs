using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Ahorcado_Services.Migrations
{
    public partial class UltimaMigracion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EstadoPalabra",
                table: "Partidas");

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaCreacionPartida",
                table: "Partidas",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "PalabraParcial",
                table: "Partidas",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FechaCreacionPartida",
                table: "Partidas");

            migrationBuilder.DropColumn(
                name: "PalabraParcial",
                table: "Partidas");

            migrationBuilder.AddColumn<string>(
                name: "EstadoPalabra",
                table: "Partidas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
