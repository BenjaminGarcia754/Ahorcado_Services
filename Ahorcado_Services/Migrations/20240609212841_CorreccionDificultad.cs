using Microsoft.EntityFrameworkCore.Migrations;

namespace Ahorcado_Services.Migrations
{
    public partial class CorreccionDificultad : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Palabras_Categorias_CategoriaId",
                table: "Palabras");

            migrationBuilder.AlterColumn<int>(
                name: "CategoriaId",
                table: "Palabras",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Palabras_Categorias_CategoriaId",
                table: "Palabras",
                column: "CategoriaId",
                principalTable: "Categorias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Palabras_Categorias_CategoriaId",
                table: "Palabras");

            migrationBuilder.AlterColumn<int>(
                name: "CategoriaId",
                table: "Palabras",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Palabras_Categorias_CategoriaId",
                table: "Palabras",
                column: "CategoriaId",
                principalTable: "Categorias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
