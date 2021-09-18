using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TrabajoPractico1.AccessData.Migrations
{
    public partial class addFunciones : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Funciones",
                columns: new[] { "FuncionId", "Fecha", "Horario", "PeliculaId", "PeliculasPeliculaId", "SalaId", "SalasSalaId" },
                values: new object[] { 2, new DateTime(2021, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 12, 30, 0, 0), 2, null, 2, null });

            migrationBuilder.InsertData(
                table: "Funciones",
                columns: new[] { "FuncionId", "Fecha", "Horario", "PeliculaId", "PeliculasPeliculaId", "SalaId", "SalasSalaId" },
                values: new object[] { 3, new DateTime(2021, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 9, 15, 0, 0), 5, null, 3, null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Funciones",
                keyColumn: "FuncionId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Funciones",
                keyColumn: "FuncionId",
                keyValue: 3);
        }
    }
}
