using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Libreria.Backend.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Autors",
                columns: table => new
                {
                    AutorId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(type: "text", nullable: false),
                    FhNacimiento = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Ciudad = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Autors", x => x.AutorId);
                });

            migrationBuilder.CreateTable(
                name: "Libros",
                columns: table => new
                {
                    LibroID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Titulo = table.Column<string>(type: "text", nullable: false),
                    Anio = table.Column<int>(type: "integer", nullable: false),
                    Genero = table.Column<string>(type: "text", nullable: true),
                    Editorial = table.Column<string>(type: "text", nullable: true),
                    Paginas = table.Column<int>(type: "integer", nullable: false),
                    AutorID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Libros", x => x.LibroID);
                    table.ForeignKey(
                        name: "FK_Libros_Autors_AutorID",
                        column: x => x.AutorID,
                        principalTable: "Autors",
                        principalColumn: "AutorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Libros_AutorID",
                table: "Libros",
                column: "AutorID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Libros");

            migrationBuilder.DropTable(
                name: "Autors");
        }
    }
}
