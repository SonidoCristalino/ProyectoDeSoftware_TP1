using Microsoft.EntityFrameworkCore.Migrations;

namespace TrabajoPractico1.AccessData.Migrations
{
    public partial class InicioBD_1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Peliculas",
                keyColumn: "PeliculaId",
                keyValue: 1,
                column: "Titulo",
                value: "El Señor de los Anillos: la Comunidad del Anillo");

            migrationBuilder.UpdateData(
                table: "Peliculas",
                keyColumn: "PeliculaId",
                keyValue: 2,
                column: "Titulo",
                value: "El Señor de los Anillos: las dos torres");

            migrationBuilder.InsertData(
                table: "Peliculas",
                columns: new[] { "PeliculaId", "Poster", "Sinopsis", "Titulo", "Trailer" },
                values: new object[,]
                {
                    { 3, "Poster3", "Sinopsis3", "El Señor de los Anillos: el retorno del Rey", "Trailer3" },
                    { 4, "Poster4", "Sinopsis4", "Spider-Man", "Trailer4" },
                    { 5, "Poster5", "Sinopsis5", "Spider-Man 2", "Trailer5" },
                    { 6, "Poster6", "Sinopsis6", "Spider-Man 3", "Trailer6" },
                    { 7, "Poster7", "Sinopsis7", "The Amazing Spider-Man", "Trailer7" },
                    { 8, "Poster8", "Sinopsis8", "Spider-Man: Un nuevo universo", "Trailer8" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Peliculas",
                keyColumn: "PeliculaId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Peliculas",
                keyColumn: "PeliculaId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Peliculas",
                keyColumn: "PeliculaId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Peliculas",
                keyColumn: "PeliculaId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Peliculas",
                keyColumn: "PeliculaId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Peliculas",
                keyColumn: "PeliculaId",
                keyValue: 8);

            migrationBuilder.UpdateData(
                table: "Peliculas",
                keyColumn: "PeliculaId",
                keyValue: 1,
                column: "Titulo",
                value: "Pelicula_1");

            migrationBuilder.UpdateData(
                table: "Peliculas",
                keyColumn: "PeliculaId",
                keyValue: 2,
                column: "Titulo",
                value: "Pelicula_2");
        }
    }
}
