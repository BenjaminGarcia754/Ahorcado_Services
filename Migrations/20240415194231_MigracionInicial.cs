using Microsoft.EntityFrameworkCore.Migrations;

namespace Ahorcado_Services.Migrations
{
    public partial class MigracionInicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Dificultades",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: false),
                    Nivel = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dificultades", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EstadosPartida",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadosPartida", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Jugadores",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: false),
                    Apellidos = table.Column<string>(nullable: false),
                    Correo = table.Column<string>(nullable: false),
                    Contrasena = table.Column<string>(nullable: false),
                    Rol = table.Column<int>(nullable: false),
                    Telefono = table.Column<string>(nullable: false),
                    Puntaje = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jugadores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Subcategorias",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: true),
                    IdCategoria = table.Column<int>(nullable: false),
                    categoriaId = table.Column<int>(nullable: true)
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

            migrationBuilder.CreateTable(
                name: "Palabras",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: false),
                    IdSubcategoria = table.Column<int>(nullable: false),
                    SubcategoriaId = table.Column<int>(nullable: false),
                    IdDificultad = table.Column<int>(nullable: false),
                    dificultadId = table.Column<int>(nullable: true),
                    Descripcion = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Palabras", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Palabras_Subcategorias_SubcategoriaId",
                        column: x => x.SubcategoriaId,
                        principalTable: "Subcategorias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Palabras_Dificultades_dificultadId",
                        column: x => x.dificultadId,
                        principalTable: "Dificultades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Partidas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdJugadorAnfitrion = table.Column<int>(nullable: false),
                    IdJugadorInvitado = table.Column<int>(nullable: false),
                    IntentosRestantes = table.Column<int>(nullable: false),
                    IdPalabraSelecionada = table.Column<int>(nullable: false),
                    EstadoPalabra = table.Column<string>(nullable: false),
                    IdEstadoPartida = table.Column<int>(nullable: false),
                    PartidaGanada = table.Column<bool>(nullable: false),
                    EstadoPartidaId = table.Column<int>(nullable: true),
                    PalabraId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Partidas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Partidas_EstadosPartida_EstadoPartidaId",
                        column: x => x.EstadoPartidaId,
                        principalTable: "EstadosPartida",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Partidas_Palabras_PalabraId",
                        column: x => x.PalabraId,
                        principalTable: "Palabras",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Palabras_SubcategoriaId",
                table: "Palabras",
                column: "SubcategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_Palabras_dificultadId",
                table: "Palabras",
                column: "dificultadId");

            migrationBuilder.CreateIndex(
                name: "IX_Partidas_EstadoPartidaId",
                table: "Partidas",
                column: "EstadoPartidaId");

            migrationBuilder.CreateIndex(
                name: "IX_Partidas_PalabraId",
                table: "Partidas",
                column: "PalabraId");

            migrationBuilder.CreateIndex(
                name: "IX_Subcategorias_categoriaId",
                table: "Subcategorias",
                column: "categoriaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Jugadores");

            migrationBuilder.DropTable(
                name: "Partidas");

            migrationBuilder.DropTable(
                name: "EstadosPartida");

            migrationBuilder.DropTable(
                name: "Palabras");

            migrationBuilder.DropTable(
                name: "Subcategorias");

            migrationBuilder.DropTable(
                name: "Dificultades");

            migrationBuilder.DropTable(
                name: "Categorias");
        }
    }
}
