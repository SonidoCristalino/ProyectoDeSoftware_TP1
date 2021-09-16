using Microsoft.EntityFrameworkCore.Migrations;

namespace TrabajoPractico1.AccessData.Migrations
{
    public partial class segundapelicula : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Peliculas",
                columns: new[] { "PeliculaId", "Poster", "Sinopsis", "Titulo", "Trailer" },
                values: new object[] { 2, "Poster2", "Sinopsis2", "Pelicula_2", "Trailer2" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Peliculas",
                keyColumn: "PeliculaId",
                keyValue: 2);
        }
    }
}
