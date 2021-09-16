using TrabajoPractico1.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace TrabajoPractico1.AccessData
{
    public class CineDbContext : DbContext
    {
        //public CineDbContext(DbContextOptions<CineDbContext> options)
        //    : base(options)
        //{
        //}

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
                new Peliculas { PeliculaId = 1, Titulo = "Pelicula_1", Poster ="Poster1", Sinopsis = "Sinopsis1", Trailer="Trailer1" },
                new Peliculas { PeliculaId = 2, Titulo = "Pelicula_2", Poster = "Poster2", Sinopsis = "Sinopsis2", Trailer = "Trailer2" }
            );

            modelBuilder.Entity<Funciones>().HasData(
                new Funciones { PeliculaId = 1, SalaId = 1, Fecha = Convert.ToDateTime("2021-09-06"), Horario = new TimeSpan(1) }
            );

        }
    }
}