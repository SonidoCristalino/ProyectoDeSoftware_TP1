using TrabajoPractico1.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace TrabajoPractico1.AccessData
{
    public class CineDbContext : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=EZE2-LLN-B01434\SQLEXPRESS;Database=TrabajoPractico1;Trusted_Connection=True;");
        }

        public DbSet<Peliculas> Peliculas { get; set; }
        public DbSet<Funciones> Funciones { get; set; }
        public DbSet<Salas> Salas { get; set; }
        public DbSet<Tickets> Tickets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Peliculas>(entity =>
            {
                entity.ToTable("Peliculas");
                entity.HasKey(Pelicula => Pelicula.PeliculaId);
                entity.Property(Pelicula => Pelicula.Titulo).HasMaxLength(50).IsRequired();
                entity.Property(Pelicula => Pelicula.Poster).HasMaxLength(255).IsRequired();
                entity.Property(Pelicula => Pelicula.Sinopsis).HasMaxLength(255).IsRequired();
                entity.Property(Pelicula => Pelicula.Trailer).HasMaxLength(255).IsRequired();

            });

            modelBuilder.Entity<Funciones>(entity =>
            {
                entity.ToTable("Funciones");
                entity.HasKey(Funciones=> Funciones.FuncionId);
                entity.Property(Funciones=> Funciones.PeliculaId).HasMaxLength(50).IsRequired();
                entity.Property(Funciones=> Funciones.SalaId).HasMaxLength(50).IsRequired();
                entity.Property(Funciones=> Funciones.Fecha).IsRequired();
                entity.Property(Funciones=> Funciones.Horario).IsRequired();

                entity.HasOne(Pelicula => Pelicula.Peliculas).WithMany(Funciones=> Funciones.Funciones);
                entity.HasOne(Salas=> Salas.Salas).WithMany(Funciones=> Funciones.Funciones);
            });

            modelBuilder.Entity<Salas>(entity =>
            {
                entity.ToTable("Salas");
                entity.HasKey(Salas=> Salas.SalaId);
                entity.Property(Salas=> Salas.Capacidad).HasMaxLength(35).IsRequired();

            });

            modelBuilder.Entity<Tickets>(entity =>
            {
                entity.ToTable("Tickets");

                entity.HasKey(compuesta => new { compuesta.TicketId, compuesta.FuncionId });
                entity.Property(Tickets => Tickets.Usuario).HasMaxLength(50).IsRequired();
                entity.Property(Tickets => Tickets.FuncionId).IsRequired();

                entity.HasOne(Funciones=> Funciones.Funciones).WithMany(Tickets => Tickets.Tickets);

            });

            modelBuilder.Entity<Salas>().HasData(
               new Salas { SalaId = 1, Capacidad = 5 },
               new Salas { SalaId = 2, Capacidad = 15 },
               new Salas { SalaId = 3, Capacidad = 35 }
            );

            modelBuilder.Entity<Peliculas>().HasData(
                new Peliculas { PeliculaId = 1, Titulo  = "El Señor de los Anillos: La Comunidad del Anillo",   Poster = "http://static-1.ivoox.com/audios/9/3/6/8/641501138639_XXL.jpg",                                                                                       Sinopsis = "En la adormecida e idílica Comarca, un joven hobbit recibe un encargo: custodiar el Anillo Único y emprender el viaje para su destrucción en las Grietas del Destino",                                                                                          Trailer = "https://www.youtube.com/watch?v=iFOucwxKRFE" },
                new Peliculas { PeliculaId = 2, Titulo  = "El Señor de los Anillos: Las dos torres",            Poster = "https://vignette4.wikia.nocookie.net/bibliotecadelatierramedia/images/a/ae/Lasdostorres.jpg/revision/latest?cb=20130713130743&path-prefix=es",        Sinopsis = "Frodo y Sam continuan su periplo hacia el Monte del Destino, en Mordor, con el objetivo de destruir el Anillo Único. Mientras, Aragorn, Gimli y Legolas siguen muy de cerca a los orcos para liberar a sus amigos hobbit Merry y Pippin.",                      Trailer = "https://www.youtube.com/watch?v=Y7k6FpH5n50" },
                new Peliculas { PeliculaId = 3, Titulo  = "El Señor de los Anillos: El retorno del Rey",        Poster = "https://www.prospectosdecine.com/public/images/especial/1547220469_2004-el-senor-de-los-anillos-el-retorno-del-rey-e.jpg",                            Sinopsis = "Frodo Baggins y Samwise Gamgee son guiados por Gollum a Minas Morgul donde son testigos de que el Rey de la Ira de Angmar conduce a una multitud de Orcos para expulsar a  Faramir de las últimas protecciones de Gondor a lo largo del río Anduin",            Trailer = "https://www.youtube.com/watch?v=cUuz3-QCg58" },
                new Peliculas { PeliculaId = 4, Titulo  = "Spider-Man",                                         Poster = "https://cartelesmix.es/cartelesdecine/wp-content/uploads/2017/12/spiderman02003.jpg",                                                                 Sinopsis = "Peter Parker, vive con su tía May y su tío Ben. Debido a su retraimiento no es un chico muy popular en el instituto. Un día le muerde una araña que ha sido modificada genéticamente; para descubrir luego que posee la fuerza y la agilidad de ese insecto.",  Trailer = "https://www.youtube.com/watch?v=_yhFofFZGcc" },
                new Peliculas { PeliculaId = 5, Titulo  = "Spider-Man 2",                                       Poster = "https://miro.medium.com/max/5400/1*48-cBwQm1IZIcDslBCNZMA.jpeg",                                                                                      Sinopsis = "Luego de años Peter Parker dejó a Mary Jane Watson, su gran amor, y asumiendo sus responsabilidades como Spider-Man. Peter debe afrontar nuevos desafíos mientras lucha contra  la maldición de sus poderes equilibrando sus dos identidades.",                 Trailer = "https://www.youtube.com/watch?v=1s9Yln0YwCw" },
                new Peliculas { PeliculaId = 6, Titulo  = "Spider-Man 3",                                       Poster = "https://content6.flixster.com/movie/11/16/52/11165292_800.jpg",                                                                                       Sinopsis = "TParker ha conseguido por fin el equilibrio entre su devoción por Mary Jane y sus deberes como superhéroe. Pero, su traje se vuelve negro y adquiere nuevos poderes; también él se transforma, mostrando el lado más oscuro y vengativo de su personalidad.",   Trailer = "https://www.youtube.com/watch?v=wPosLpgMtTY" },
                new Peliculas { PeliculaId = 7, Titulo  = "Volver al futuro",                                   Poster = "https://resizing.flixster.com/JABjnn-KhoEu2-4aS3XNAyGzeGk=/ems.ZW1zLXByZC1hc3NldHMvbW92aWVzLzJiYTdhYWRiLWE2ZmItNGU4ZS05ZmNlLWFjNTBlMjM2MDQ3MS53ZWJw", Sinopsis = "El adolescente Marty McFly es amigo de Doc, un científico al que todos toman por loco. Cuando Doc crea una máquina para viajar en el tiempo, un error fortuito hace que Marty llegue a 1955, año en el que sus futuros padres aún no se habían conocido.",      Trailer = "https://www.youtube.com/watch?v=qvsgGtivCgs" },
                new Peliculas { PeliculaId = 8, Titulo  = "Volver al futuro Parte II",                          Poster = "https://hellhorror.com/images/inTheaters/origs/Back-to-the-Future-Part-II-1989-poster.jpg",                                                           Sinopsis = "Marty McFly deberá viajar al futuro para solucionar un problema con la ley que tendrá uno de sus futuros hijos. En la tremenda vorágine futurista, la presencia de tales viajeros temporales causará un efecto mayor que el que iban a arreglar.",              Trailer = "https://www.youtube.com/watch?v=MdENmefJRpw" },
                new Peliculas { PeliculaId = 9, Titulo  = "Volver al futuro Parte III",                         Poster = "https://vignette1.wikia.nocookie.net/bttf/images/6/68/Backfu3.jpg/revision/latest/scale-to-width-down/2000?cb=20150928161225",                        Sinopsis = "Doc, el amigo de Marty, ha retrocedido al año 1885, la época del salvaje oeste. Marty descubre una vieja tumba en la que lee que Doc murió en 1885 y, sin pensárselo dos veces, irá a rescatar a su amigo.",                                                    Trailer = "https://www.youtube.com/watch?v=3C8c3EoEfw4" },
                new Peliculas { PeliculaId = 10, Titulo  = "Hombres de negro",                                  Poster = "https://tupersonajefavorito.com/wp-content/uploads/2018/05/hombres_de_negro_1997_6-1.jpg",                                                            Sinopsis = "Durante años los extraterrestres han vivido en la Tierra, mezclados con los seres humanos, sin que nadie lo supiese. Dos de estos agentes (uno veterano y otro recién incorporado), descubren a un terrorista galáctico que pretende acabar con la Humanidad.", Trailer = "https://www.youtube.com/watch?v=1Q4mhYF9aQQ" },
                new Peliculas { PeliculaId = 11, Titulo  = "Hombres de negro II",                               Poster = "https://image.tmdb.org/t/p/original/zX1Hi0j7Yn4jv2eDHyIMlHP8lDb.jpg",                                                                                 Sinopsis = "Cuatro años después la precuela, el agente K ha vuelto a una vida normal, mientras que el agente J sigue persiguiendo alienígenas. Pero cuando la integridad de la Tierra vuelve a estar en peligro, J volverá a recurrir a K como en los viejos tiempos.",     Trailer = "https://www.youtube.com/watch?v=tBsDWiL3-DA" },
                new Peliculas { PeliculaId = 12, Titulo  = "Hombres de negro III",                              Poster = "https://vignette.wikia.nocookie.net/cine/images/3/3a/Men_In_Black_3_Hombres_de_negro_III.jpg/revision/latest?cb=20200928234544",                      Sinopsis = "Cuando el MIB recibe la información de que el Agente K podría morir a manos de un alienígena, lo que cambiaría la historia para siempre, el Agente J es enviado a los años 60 para evitarlo. Tercera entrega de la popular saga Men in Black.",                 Trailer = "https://www.youtube.com/watch?v=IyaFEBI_L24" }

            );

            //======================================================= Datos cargados para Testing =======================================================

            modelBuilder.Entity<Funciones>().HasData(
                new Funciones { FuncionId = 1, PeliculaId = 1, SalaId = 1, Fecha = Convert.ToDateTime("2021-09-06"), Horario = new TimeSpan(10,30,00)},
                new Funciones { FuncionId = 2, PeliculaId = 2, SalaId = 2, Fecha = Convert.ToDateTime("2021-09-12"), Horario = new TimeSpan(12, 30, 00)},
                new Funciones { FuncionId = 3, PeliculaId = 5, SalaId = 3, Fecha = Convert.ToDateTime("2021-09-15"), Horario = new TimeSpan(09, 15, 00) }
            );

            modelBuilder.Entity<Tickets>().HasData(
                new Tickets { FuncionId = 1, TicketId = Guid.NewGuid(), Usuario = "Emiliano" },
                new Tickets { FuncionId = 1, TicketId = Guid.NewGuid(), Usuario = "Marcelo" },
                new Tickets { FuncionId = 1, TicketId = Guid.NewGuid(), Usuario = "Beatriz" },
                new Tickets { FuncionId = 1, TicketId = Guid.NewGuid(), Usuario = "Mailen" },
                new Tickets { FuncionId = 1, TicketId = Guid.NewGuid(), Usuario = "Melisa" },
                new Tickets { FuncionId = 2, TicketId = Guid.NewGuid(), Usuario = "Maria" },
                new Tickets { FuncionId = 3, TicketId = Guid.NewGuid(), Usuario = "Florencia" }
            );


            ;

        }
    }
}