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
                values: new object[,]
                {
                    { 1, new DateTime(2021, 9, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 10, 30, 0, 0), 1, null, 1, null },
                    { 2, new DateTime(2021, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 12, 30, 0, 0), 2, null, 2, null },
                    { 3, new DateTime(2021, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 9, 15, 0, 0), 5, null, 3, null }
                });

            migrationBuilder.InsertData(
                table: "Peliculas",
                columns: new[] { "PeliculaId", "Poster", "Sinopsis", "Titulo", "Trailer" },
                values: new object[,]
                {
                    { 12, "https://vignette.wikia.nocookie.net/cine/images/3/3a/Men_In_Black_3_Hombres_de_negro_III.jpg/revision/latest?cb=20200928234544", "Cuando el MIB recibe la información de que el Agente K podría morir a manos de un alienígena, lo que cambiaría la historia para siempre, el Agente J es enviado a los años 60 para evitarlo. Tercera entrega de la popular saga Men in Black.", "Hombres de negro III", "https://www.youtube.com/watch?v=IyaFEBI_L24" },
                    { 11, "https://image.tmdb.org/t/p/original/zX1Hi0j7Yn4jv2eDHyIMlHP8lDb.jpg", "Cuatro años después la precuela, el agente K ha vuelto a una vida normal, mientras que el agente J sigue persiguiendo alienígenas. Pero cuando la integridad de la Tierra vuelve a estar en peligro, J volverá a recurrir a K como en los viejos tiempos.", "Hombres de negro II", "https://www.youtube.com/watch?v=tBsDWiL3-DA" },
                    { 10, "https://tupersonajefavorito.com/wp-content/uploads/2018/05/hombres_de_negro_1997_6-1.jpg", "Durante años los extraterrestres han vivido en la Tierra, mezclados con los seres humanos, sin que nadie lo supiese. Dos de estos agentes (uno veterano y otro recién incorporado), descubren a un terrorista galáctico que pretende acabar con la Humanidad.", "Hombres de negro", "https://www.youtube.com/watch?v=1Q4mhYF9aQQ" },
                    { 9, "https://vignette1.wikia.nocookie.net/bttf/images/6/68/Backfu3.jpg/revision/latest/scale-to-width-down/2000?cb=20150928161225", "Doc, el amigo de Marty, ha retrocedido al año 1885, la época del salvaje oeste. Marty descubre una vieja tumba en la que lee que Doc murió en 1885 y, sin pensárselo dos veces, irá a rescatar a su amigo.", "Volver al futuro Parte III", "https://www.youtube.com/watch?v=3C8c3EoEfw4" },
                    { 8, "https://hellhorror.com/images/inTheaters/origs/Back-to-the-Future-Part-II-1989-poster.jpg", "Marty McFly deberá viajar al futuro para solucionar un problema con la ley que tendrá uno de sus futuros hijos. En la tremenda vorágine futurista, la presencia de tales viajeros temporales causará un efecto mayor que el que iban a arreglar.", "Volver al futuro Parte II", "https://www.youtube.com/watch?v=MdENmefJRpw" },
                    { 7, "https://resizing.flixster.com/JABjnn-KhoEu2-4aS3XNAyGzeGk=/ems.ZW1zLXByZC1hc3NldHMvbW92aWVzLzJiYTdhYWRiLWE2ZmItNGU4ZS05ZmNlLWFjNTBlMjM2MDQ3MS53ZWJw", "El adolescente Marty McFly es amigo de Doc, un científico al que todos toman por loco. Cuando Doc crea una máquina para viajar en el tiempo, un error fortuito hace que Marty llegue a 1955, año en el que sus futuros padres aún no se habían conocido.", "Volver al futuro", "https://www.youtube.com/watch?v=qvsgGtivCgs" },
                    { 6, "https://content6.flixster.com/movie/11/16/52/11165292_800.jpg", "TParker ha conseguido por fin el equilibrio entre su devoción por Mary Jane y sus deberes como superhéroe. Pero, su traje se vuelve negro y adquiere nuevos poderes; también él se transforma, mostrando el lado más oscuro y vengativo de su personalidad.", "Spider-Man 3", "https://www.youtube.com/watch?v=wPosLpgMtTY" },
                    { 5, "https://miro.medium.com/max/5400/1*48-cBwQm1IZIcDslBCNZMA.jpeg", "Luego de años Peter Parker dejó a Mary Jane Watson, su gran amor, y asumiendo sus responsabilidades como Spider-Man. Peter debe afrontar nuevos desafíos mientras lucha contra  la maldición de sus poderes equilibrando sus dos identidades.", "Spider-Man 2", "https://www.youtube.com/watch?v=1s9Yln0YwCw" },
                    { 4, "https://cartelesmix.es/cartelesdecine/wp-content/uploads/2017/12/spiderman02003.jpg", "Peter Parker, vive con su tía May y su tío Ben. Debido a su retraimiento no es un chico muy popular en el instituto. Un día le muerde una araña que ha sido modificada genéticamente; para descubrir luego que posee la fuerza y la agilidad de ese insecto.", "Spider-Man", "https://www.youtube.com/watch?v=_yhFofFZGcc" },
                    { 3, "https://www.prospectosdecine.com/public/images/especial/1547220469_2004-el-senor-de-los-anillos-el-retorno-del-rey-e.jpg", "Frodo Baggins y Samwise Gamgee son guiados por Gollum a Minas Morgul donde son testigos de que el Rey de la Ira de Angmar conduce a una multitud de Orcos para expulsar a  Faramir de las últimas protecciones de Gondor a lo largo del río Anduin", "El Señor de los Anillos: El retorno del Rey", "https://www.youtube.com/watch?v=cUuz3-QCg58" },
                    { 2, "https://vignette4.wikia.nocookie.net/bibliotecadelatierramedia/images/a/ae/Lasdostorres.jpg/revision/latest?cb=20130713130743&path-prefix=es", "Frodo y Sam continuan su periplo hacia el Monte del Destino, en Mordor, con el objetivo de destruir el Anillo Único. Mientras, Aragorn, Gimli y Legolas siguen muy de cerca a los orcos para liberar a sus amigos hobbit Merry y Pippin.", "El Señor de los Anillos: Las dos torres", "https://www.youtube.com/watch?v=Y7k6FpH5n50" },
                    { 1, "http://static-1.ivoox.com/audios/9/3/6/8/641501138639_XXL.jpg", "En la adormecida e idílica Comarca, un joven hobbit recibe un encargo: custodiar el Anillo Único y emprender el viaje para su destrucción en las Grietas del Destino", "El Señor de los Anillos: La Comunidad del Anillo", "https://www.youtube.com/watch?v=iFOucwxKRFE" }
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

            migrationBuilder.InsertData(
                table: "Tickets",
                columns: new[] { "FuncionId", "TicketId", "Usuario" },
                values: new object[,]
                {
                    { 1, new Guid("fb901567-d641-464f-a810-47655e188346"), "Emiliano" },
                    { 1, new Guid("ecda2144-6ac8-4bb0-917f-f790d65e9720"), "Marcelo" },
                    { 1, new Guid("71e6fdc3-3550-432b-853b-69924e5b4cc4"), "Beatriz" },
                    { 1, new Guid("deb839bb-ece1-4cc0-865d-9cffeb0faa10"), "Mailen" },
                    { 1, new Guid("a325ffd6-c840-4337-b171-8ea8cda586a3"), "Melisa" },
                    { 2, new Guid("01c494a3-e28b-4486-9c67-a753ea779438"), "Maria" },
                    { 3, new Guid("3f7375b0-0dd3-4d95-8078-2d32594be5c2"), "Florencia" }
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
