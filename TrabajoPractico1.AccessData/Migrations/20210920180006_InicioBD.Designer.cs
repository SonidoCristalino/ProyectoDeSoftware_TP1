﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TrabajoPractico1.AccessData;

namespace TrabajoPractico1.AccessData.Migrations
{
    [DbContext(typeof(CineDbContext))]
    [Migration("20210920180006_InicioBD")]
    partial class InicioBD
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TrabajoPractico1.Domain.Entities.Funciones", b =>
                {
                    b.Property<int>("FuncionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<TimeSpan>("Horario")
                        .HasColumnType("time");

                    b.Property<int>("PeliculaId")
                        .HasMaxLength(50)
                        .HasColumnType("int");

                    b.Property<int?>("PeliculasPeliculaId")
                        .HasColumnType("int");

                    b.Property<int>("SalaId")
                        .HasMaxLength(50)
                        .HasColumnType("int");

                    b.Property<int?>("SalasSalaId")
                        .HasColumnType("int");

                    b.HasKey("FuncionId");

                    b.HasIndex("PeliculasPeliculaId");

                    b.HasIndex("SalasSalaId");

                    b.ToTable("Funciones");

                    b.HasData(
                        new
                        {
                            FuncionId = 1,
                            Fecha = new DateTime(2021, 9, 6, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Horario = new TimeSpan(0, 10, 30, 0, 0),
                            PeliculaId = 1,
                            SalaId = 1
                        },
                        new
                        {
                            FuncionId = 2,
                            Fecha = new DateTime(2021, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Horario = new TimeSpan(0, 12, 30, 0, 0),
                            PeliculaId = 2,
                            SalaId = 2
                        },
                        new
                        {
                            FuncionId = 3,
                            Fecha = new DateTime(2021, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Horario = new TimeSpan(0, 9, 15, 0, 0),
                            PeliculaId = 5,
                            SalaId = 3
                        });
                });

            modelBuilder.Entity("TrabajoPractico1.Domain.Entities.Peliculas", b =>
                {
                    b.Property<int>("PeliculaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Poster")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Sinopsis")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Trailer")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("PeliculaId");

                    b.ToTable("Peliculas");

                    b.HasData(
                        new
                        {
                            PeliculaId = 1,
                            Poster = "http://static-1.ivoox.com/audios/9/3/6/8/641501138639_XXL.jpg",
                            Sinopsis = "En la adormecida e idílica Comarca, un joven hobbit recibe un encargo: custodiar el Anillo Único y emprender el viaje para su destrucción en las Grietas del Destino",
                            Titulo = "El Señor de los Anillos: La Comunidad del Anillo",
                            Trailer = "https://www.youtube.com/watch?v=iFOucwxKRFE"
                        },
                        new
                        {
                            PeliculaId = 2,
                            Poster = "https://vignette4.wikia.nocookie.net/bibliotecadelatierramedia/images/a/ae/Lasdostorres.jpg/revision/latest?cb=20130713130743&path-prefix=es",
                            Sinopsis = "Frodo y Sam continuan su periplo hacia el Monte del Destino, en Mordor, con el objetivo de destruir el Anillo Único. Mientras, Aragorn, Gimli y Legolas siguen muy de cerca a los orcos para liberar a sus amigos hobbit Merry y Pippin.",
                            Titulo = "El Señor de los Anillos: Las dos torres",
                            Trailer = "https://www.youtube.com/watch?v=Y7k6FpH5n50"
                        },
                        new
                        {
                            PeliculaId = 3,
                            Poster = "https://www.prospectosdecine.com/public/images/especial/1547220469_2004-el-senor-de-los-anillos-el-retorno-del-rey-e.jpg",
                            Sinopsis = "Frodo Baggins y Samwise Gamgee son guiados por Gollum a Minas Morgul donde son testigos de que el Rey de la Ira de Angmar conduce a una multitud de Orcos para expulsar a  Faramir de las últimas protecciones de Gondor a lo largo del río Anduin",
                            Titulo = "El Señor de los Anillos: El retorno del Rey",
                            Trailer = "https://www.youtube.com/watch?v=cUuz3-QCg58"
                        },
                        new
                        {
                            PeliculaId = 4,
                            Poster = "https://cartelesmix.es/cartelesdecine/wp-content/uploads/2017/12/spiderman02003.jpg",
                            Sinopsis = "Peter Parker, vive con su tía May y su tío Ben. Debido a su retraimiento no es un chico muy popular en el instituto. Un día le muerde una araña que ha sido modificada genéticamente; para descubrir luego que posee la fuerza y la agilidad de ese insecto.",
                            Titulo = "Spider-Man",
                            Trailer = "https://www.youtube.com/watch?v=_yhFofFZGcc"
                        },
                        new
                        {
                            PeliculaId = 5,
                            Poster = "https://miro.medium.com/max/5400/1*48-cBwQm1IZIcDslBCNZMA.jpeg",
                            Sinopsis = "Luego de años Peter Parker dejó a Mary Jane Watson, su gran amor, y asumiendo sus responsabilidades como Spider-Man. Peter debe afrontar nuevos desafíos mientras lucha contra  la maldición de sus poderes equilibrando sus dos identidades.",
                            Titulo = "Spider-Man 2",
                            Trailer = "https://www.youtube.com/watch?v=1s9Yln0YwCw"
                        },
                        new
                        {
                            PeliculaId = 6,
                            Poster = "https://content6.flixster.com/movie/11/16/52/11165292_800.jpg",
                            Sinopsis = "TParker ha conseguido por fin el equilibrio entre su devoción por Mary Jane y sus deberes como superhéroe. Pero, su traje se vuelve negro y adquiere nuevos poderes; también él se transforma, mostrando el lado más oscuro y vengativo de su personalidad.",
                            Titulo = "Spider-Man 3",
                            Trailer = "https://www.youtube.com/watch?v=wPosLpgMtTY"
                        },
                        new
                        {
                            PeliculaId = 7,
                            Poster = "https://resizing.flixster.com/JABjnn-KhoEu2-4aS3XNAyGzeGk=/ems.ZW1zLXByZC1hc3NldHMvbW92aWVzLzJiYTdhYWRiLWE2ZmItNGU4ZS05ZmNlLWFjNTBlMjM2MDQ3MS53ZWJw",
                            Sinopsis = "El adolescente Marty McFly es amigo de Doc, un científico al que todos toman por loco. Cuando Doc crea una máquina para viajar en el tiempo, un error fortuito hace que Marty llegue a 1955, año en el que sus futuros padres aún no se habían conocido.",
                            Titulo = "Volver al futuro",
                            Trailer = "https://www.youtube.com/watch?v=qvsgGtivCgs"
                        },
                        new
                        {
                            PeliculaId = 8,
                            Poster = "https://hellhorror.com/images/inTheaters/origs/Back-to-the-Future-Part-II-1989-poster.jpg",
                            Sinopsis = "Marty McFly deberá viajar al futuro para solucionar un problema con la ley que tendrá uno de sus futuros hijos. En la tremenda vorágine futurista, la presencia de tales viajeros temporales causará un efecto mayor que el que iban a arreglar.",
                            Titulo = "Volver al futuro Parte II",
                            Trailer = "https://www.youtube.com/watch?v=MdENmefJRpw"
                        },
                        new
                        {
                            PeliculaId = 9,
                            Poster = "https://vignette1.wikia.nocookie.net/bttf/images/6/68/Backfu3.jpg/revision/latest/scale-to-width-down/2000?cb=20150928161225",
                            Sinopsis = "Doc, el amigo de Marty, ha retrocedido al año 1885, la época del salvaje oeste. Marty descubre una vieja tumba en la que lee que Doc murió en 1885 y, sin pensárselo dos veces, irá a rescatar a su amigo.",
                            Titulo = "Volver al futuro Parte III",
                            Trailer = "https://www.youtube.com/watch?v=3C8c3EoEfw4"
                        },
                        new
                        {
                            PeliculaId = 10,
                            Poster = "https://tupersonajefavorito.com/wp-content/uploads/2018/05/hombres_de_negro_1997_6-1.jpg",
                            Sinopsis = "Durante años los extraterrestres han vivido en la Tierra, mezclados con los seres humanos, sin que nadie lo supiese. Dos de estos agentes (uno veterano y otro recién incorporado), descubren a un terrorista galáctico que pretende acabar con la Humanidad.",
                            Titulo = "Hombres de negro",
                            Trailer = "https://www.youtube.com/watch?v=1Q4mhYF9aQQ"
                        },
                        new
                        {
                            PeliculaId = 11,
                            Poster = "https://image.tmdb.org/t/p/original/zX1Hi0j7Yn4jv2eDHyIMlHP8lDb.jpg",
                            Sinopsis = "Cuatro años después la precuela, el agente K ha vuelto a una vida normal, mientras que el agente J sigue persiguiendo alienígenas. Pero cuando la integridad de la Tierra vuelve a estar en peligro, J volverá a recurrir a K como en los viejos tiempos.",
                            Titulo = "Hombres de negro II",
                            Trailer = "https://www.youtube.com/watch?v=tBsDWiL3-DA"
                        },
                        new
                        {
                            PeliculaId = 12,
                            Poster = "https://vignette.wikia.nocookie.net/cine/images/3/3a/Men_In_Black_3_Hombres_de_negro_III.jpg/revision/latest?cb=20200928234544",
                            Sinopsis = "Cuando el MIB recibe la información de que el Agente K podría morir a manos de un alienígena, lo que cambiaría la historia para siempre, el Agente J es enviado a los años 60 para evitarlo. Tercera entrega de la popular saga Men in Black.",
                            Titulo = "Hombres de negro III",
                            Trailer = "https://www.youtube.com/watch?v=IyaFEBI_L24"
                        });
                });

            modelBuilder.Entity("TrabajoPractico1.Domain.Entities.Salas", b =>
                {
                    b.Property<int>("SalaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Capacidad")
                        .HasMaxLength(35)
                        .HasColumnType("int");

                    b.HasKey("SalaId");

                    b.ToTable("Salas");

                    b.HasData(
                        new
                        {
                            SalaId = 1,
                            Capacidad = 5
                        },
                        new
                        {
                            SalaId = 2,
                            Capacidad = 15
                        },
                        new
                        {
                            SalaId = 3,
                            Capacidad = 35
                        });
                });

            modelBuilder.Entity("TrabajoPractico1.Domain.Entities.Tickets", b =>
                {
                    b.Property<Guid>("TicketId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("FuncionId")
                        .HasColumnType("int");

                    b.Property<string>("Usuario")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("TicketId", "FuncionId");

                    b.HasIndex("FuncionId");

                    b.ToTable("Tickets");

                    b.HasData(
                        new
                        {
                            TicketId = new Guid("fb901567-d641-464f-a810-47655e188346"),
                            FuncionId = 1,
                            Usuario = "Emiliano"
                        },
                        new
                        {
                            TicketId = new Guid("ecda2144-6ac8-4bb0-917f-f790d65e9720"),
                            FuncionId = 1,
                            Usuario = "Marcelo"
                        },
                        new
                        {
                            TicketId = new Guid("71e6fdc3-3550-432b-853b-69924e5b4cc4"),
                            FuncionId = 1,
                            Usuario = "Beatriz"
                        },
                        new
                        {
                            TicketId = new Guid("deb839bb-ece1-4cc0-865d-9cffeb0faa10"),
                            FuncionId = 1,
                            Usuario = "Mailen"
                        },
                        new
                        {
                            TicketId = new Guid("a325ffd6-c840-4337-b171-8ea8cda586a3"),
                            FuncionId = 1,
                            Usuario = "Melisa"
                        },
                        new
                        {
                            TicketId = new Guid("01c494a3-e28b-4486-9c67-a753ea779438"),
                            FuncionId = 2,
                            Usuario = "Maria"
                        },
                        new
                        {
                            TicketId = new Guid("3f7375b0-0dd3-4d95-8078-2d32594be5c2"),
                            FuncionId = 3,
                            Usuario = "Florencia"
                        });
                });

            modelBuilder.Entity("TrabajoPractico1.Domain.Entities.Funciones", b =>
                {
                    b.HasOne("TrabajoPractico1.Domain.Entities.Peliculas", "Peliculas")
                        .WithMany("Funciones")
                        .HasForeignKey("PeliculasPeliculaId");

                    b.HasOne("TrabajoPractico1.Domain.Entities.Salas", "Salas")
                        .WithMany("Funciones")
                        .HasForeignKey("SalasSalaId");

                    b.Navigation("Peliculas");

                    b.Navigation("Salas");
                });

            modelBuilder.Entity("TrabajoPractico1.Domain.Entities.Tickets", b =>
                {
                    b.HasOne("TrabajoPractico1.Domain.Entities.Funciones", "Funciones")
                        .WithMany("Tickets")
                        .HasForeignKey("FuncionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Funciones");
                });

            modelBuilder.Entity("TrabajoPractico1.Domain.Entities.Funciones", b =>
                {
                    b.Navigation("Tickets");
                });

            modelBuilder.Entity("TrabajoPractico1.Domain.Entities.Peliculas", b =>
                {
                    b.Navigation("Funciones");
                });

            modelBuilder.Entity("TrabajoPractico1.Domain.Entities.Salas", b =>
                {
                    b.Navigation("Funciones");
                });
#pragma warning restore 612, 618
        }
    }
}