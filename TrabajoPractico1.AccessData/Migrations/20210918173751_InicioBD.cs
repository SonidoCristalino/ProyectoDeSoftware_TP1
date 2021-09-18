using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TrabajoPractico1.AccessData.Migrations
{
    public partial class InicioBD : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Peliculas",
                columns: table => new
                {
                    PeliculaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Poster = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Sinopsis = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Trailer = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Peliculas", x => x.PeliculaId);
                });

            migrationBuilder.CreateTable(
                name: "Salas",
                columns: table => new
                {
                    SalaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Capacidad = table.Column<int>(type: "int", maxLength: 35, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Salas", x => x.SalaId);
                });

            migrationBuilder.CreateTable(
                name: "Funciones",
                columns: table => new
                {
                    FuncionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PeliculaId = table.Column<int>(type: "int", maxLength: 50, nullable: false),
                    SalaId = table.Column<int>(type: "int", maxLength: 50, nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Horario = table.Column<TimeSpan>(type: "time", nullable: false),
                    PeliculasPeliculaId = table.Column<int>(type: "int", nullable: true),
                    SalasSalaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funciones", x => x.FuncionId);
                    table.ForeignKey(
                        name: "FK_Funciones_Peliculas_PeliculasPeliculaId",
                        column: x => x.PeliculasPeliculaId,
                        principalTable: "Peliculas",
                        principalColumn: "PeliculaId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Funciones_Salas_SalasSalaId",
                        column: x => x.SalasSalaId,
                        principalTable: "Salas",
                        principalColumn: "SalaId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    TicketId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FuncionId = table.Column<int>(type: "int", nullable: false),
                    Usuario = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => new { x.TicketId, x.FuncionId });
                    table.ForeignKey(
                        name: "FK_Tickets_Funciones_FuncionId",
                        column: x => x.FuncionId,
                        principalTable: "Funciones",
                        principalColumn: "FuncionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Funciones",
                columns: new[] { "FuncionId", "Fecha", "Horario", "PeliculaId", "PeliculasPeliculaId", "SalaId", "SalasSalaId" },
                values: new object[] { 1, new DateTime(2021, 9, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 10, 30, 0, 0), 1, null, 1, null });

            migrationBuilder.InsertData(
                table: "Peliculas",
                columns: new[] { "PeliculaId", "Poster", "Sinopsis", "Titulo", "Trailer" },
                values: new object[,]
                {
                    { 1, "Poster1", "Sinopsis1", "El Señor de los Anillos: la Comunidad del Anillo", "Trailer1" },
                    { 2, "Poster2", "Sinopsis2", "El Señor de los Anillos: las dos torres", "Trailer2" },
                    { 3, "Poster3", "Sinopsis3", "El Señor de los Anillos: el retorno del Rey", "Trailer3" },
                    { 4, "Poster4", "Sinopsis4", "Spider-Man", "Trailer4" },
                    { 5, "Poster5", "Sinopsis5", "Spider-Man 2", "Trailer5" },
                    { 6, "Poster6", "Sinopsis6", "Spider-Man 3", "Trailer6" },
                    { 7, "Poster7", "Sinopsis7", "The Amazing Spider-Man", "Trailer7" },
                    { 8, "Poster8", "Sinopsis8", "Spider-Man: Un nuevo universo", "Trailer8" }
                });

            migrationBuilder.InsertData(
                table: "Salas",
                columns: new[] { "SalaId", "Capacidad" },
                values: new object[,]
                {
                    { 1, 5 },
                    { 2, 15 },
                    { 3, 35 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Funciones_PeliculasPeliculaId",
                table: "Funciones",
                column: "PeliculasPeliculaId");

            migrationBuilder.CreateIndex(
                name: "IX_Funciones_SalasSalaId",
                table: "Funciones",
                column: "SalasSalaId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_FuncionId",
                table: "Tickets",
                column: "FuncionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.DropTable(
                name: "Funciones");

            migrationBuilder.DropTable(
                name: "Peliculas");

            migrationBuilder.DropTable(
                name: "Salas");
        }
    }
}
