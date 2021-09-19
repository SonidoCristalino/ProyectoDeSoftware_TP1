using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TrabajoPractico1.AccessData.Migrations
{
    public partial class cargaTickets : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Tickets",
                columns: new[] { "FuncionId", "TicketId", "Usuario" },
                values: new object[,]
                {
                    { 1, new Guid("9a35f09f-69a9-4abe-8933-7e434e211348"), "Emiliano" },
                    { 1, new Guid("7023eb05-8507-4123-8656-b5d6022bd0ba"), "Marcelo" },
                    { 1, new Guid("84b69ed9-ed94-413d-9846-517e42172f9c"), "Beatriz" },
                    { 1, new Guid("32a5679b-64f1-4e9e-8516-b43e70a2b3f1"), "Mailen" },
                    { 1, new Guid("591d7cd3-3857-4759-b296-afdae22439e3"), "Melisa" },
                    { 2, new Guid("9367fb41-d859-4877-a374-5e55699f1a38"), "Maria" },
                    { 3, new Guid("39bff1b0-a309-4497-9669-39d662d2921e"), "Florencia" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "FuncionId", "TicketId" },
                keyValues: new object[] { 1, new Guid("32a5679b-64f1-4e9e-8516-b43e70a2b3f1") });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "FuncionId", "TicketId" },
                keyValues: new object[] { 3, new Guid("39bff1b0-a309-4497-9669-39d662d2921e") });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "FuncionId", "TicketId" },
                keyValues: new object[] { 1, new Guid("591d7cd3-3857-4759-b296-afdae22439e3") });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "FuncionId", "TicketId" },
                keyValues: new object[] { 1, new Guid("7023eb05-8507-4123-8656-b5d6022bd0ba") });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "FuncionId", "TicketId" },
                keyValues: new object[] { 1, new Guid("84b69ed9-ed94-413d-9846-517e42172f9c") });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "FuncionId", "TicketId" },
                keyValues: new object[] { 2, new Guid("9367fb41-d859-4877-a374-5e55699f1a38") });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumns: new[] { "FuncionId", "TicketId" },
                keyValues: new object[] { 1, new Guid("9a35f09f-69a9-4abe-8933-7e434e211348") });
        }
    }
}
