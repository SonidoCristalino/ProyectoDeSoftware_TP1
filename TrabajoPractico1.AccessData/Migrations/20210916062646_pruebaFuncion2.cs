using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TrabajoPractico1.AccessData.Migrations
{
    public partial class pruebaFuncion2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Funciones",
                columns: new[] { "FuncionId", "Fecha", "Horario", "PeliculaId", "PeliculasPeliculaId", "SalaId", "SalasSalaId" },
                values: new object[] { 1, new DateTime(2021, 9, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(10), 1, null, 1, null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Funciones",
                keyColumn: "FuncionId",
                keyValue: 1);
        }
    }
}
