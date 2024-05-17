using Microsoft.EntityFrameworkCore.Migrations;

namespace Ahorcado_Services.Migrations
{
    public partial class InternacionalizacionBDv1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Palabras_Subcategorias_SubcategoriaId",
                table: "Palabras");

            migrationBuilder.DropTable(
                name: "Subcategorias");

            migrationBuilder.DropIndex(
                name: "IX_Palabras_SubcategoriaId",
                table: "Palabras");

            migrationBuilder.DropColumn(
                name: "IdSubcategoria",
                table: "Palabras");

            migrationBuilder.DropColumn(
                name: "SubcategoriaId",
                table: "Palabras");

            migrationBuilder.AddColumn<int>(
                name: "CategoriaId",
                table: "Palabras",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "DescripcionIngles",
                table: "Palabras",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "IdCategoria",
                table: "Palabras",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "NombreIngles",
                table: "Palabras",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NombreIngles",
                table: "Dificultades",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NombreIngles",
                table: "Categorias",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Palabras_CategoriaId",
                table: "Palabras",
                column: "CategoriaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Palabras_Categorias_CategoriaId",
                table: "Palabras",
                column: "CategoriaId",
                principalTable: "Categorias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Palabras_Categorias_CategoriaId",
                table: "Palabras");

            migrationBuilder.DropIndex(
                name: "IX_Palabras_CategoriaId",
                table: "Palabras");

            migrationBuilder.DropColumn(
                name: "CategoriaId",
                table: "Palabras");

            migrationBuilder.DropColumn(
                name: "DescripcionIngles",
                table: "Palabras");

            migrationBuilder.DropColumn(
                name: "IdCategoria",
                table: "Palabras");

            migrationBuilder.DropColumn(
                name: "NombreIngles",
                table: "Palabras");

            migrationBuilder.DropColumn(
                name: "NombreIngles",
                table: "Dificultades");

            migrationBuilder.DropColumn(
                name: "NombreIngles",
                table: "Categorias");

            migrationBuilder.AddColumn<int>(
                name: "IdSubcategoria",
                table: "Palabras",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SubcategoriaId",
                table: "Palabras",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Subcategorias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCategoria = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    categoriaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subcategorias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Subcategorias_Categorias_categoriaId",
                        column: x => x.categoriaId,
                        principalTable: "Categorias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Palabras_SubcategoriaId",
                table: "Palabras",
                column: "SubcategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_Subcategorias_categoriaId",
                table: "Subcategorias",
                column: "categoriaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Palabras_Subcategorias_SubcategoriaId",
                table: "Palabras",
                column: "SubcategoriaId",
                principalTable: "Subcategorias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
