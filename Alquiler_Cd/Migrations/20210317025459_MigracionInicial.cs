using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Luisde_Prestamos_Cd.Migrations
{
    public partial class MigracionInicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodigoTitulo = table.Column<int>(type: "int", nullable: false),
                    NoCd = table.Column<int>(type: "int", nullable: false),
                    Condicion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ubicacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Estado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cds", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Correo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NroDNI = table.Column<int>(type: "int", nullable: false),
                    FechaNacimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaInscripcion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TemaInteres = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Estado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Alquileres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    noAlquiler = table.Column<int>(type: "int", nullable: false),
                    fechaAlquiler = table.Column<DateTime>(type: "datetime2", nullable: false),
                    valorAlquiler = table.Column<double>(type: "float", nullable: false),
                    ClienteId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alquileres", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Alquileres_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DetalleAlquileres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Item = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CodigoTitulo = table.Column<int>(type: "int", nullable: false),
                    DiasPrestamo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaDevolucion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AlquilerId = table.Column<int>(type: "int", nullable: false),
                    CdId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetalleAlquileres", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DetalleAlquileres_Alquileres_AlquilerId",
                        column: x => x.AlquilerId,
                        principalTable: "Alquileres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DetalleAlquileres_Cds_CdId",
                        column: x => x.CdId,
                        principalTable: "Cds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sanciones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NoSancion = table.Column<int>(type: "int", nullable: false),
                    TipoSancion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NoDiasSancion = table.Column<int>(type: "int", nullable: false),
                    AlquilerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sanciones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sanciones_Alquileres_AlquilerId",
                        column: x => x.AlquilerId,
                        principalTable: "Alquileres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Alquileres_ClienteId",
                table: "Alquileres",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleAlquileres_AlquilerId",
                table: "DetalleAlquileres",
                column: "AlquilerId");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleAlquileres_CdId",
                table: "DetalleAlquileres",
                column: "CdId");

            migrationBuilder.CreateIndex(
                name: "IX_Sanciones_AlquilerId",
                table: "Sanciones",
                column: "AlquilerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DetalleAlquileres");

            migrationBuilder.DropTable(
                name: "Sanciones");

            migrationBuilder.DropTable(
                name: "Cds");

            migrationBuilder.DropTable(
                name: "Alquileres");

            migrationBuilder.DropTable(
                name: "Clientes");
        }
    }
}
