﻿using TrabajoPractico1.Domain.Entities;
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
                new Peliculas { PeliculaId = 1, Titulo = "El Señor de los Anillos: la Comunidad del Anillo",    Poster = "Poster1", Sinopsis = "Sinopsis1", Trailer = "Trailer1" },
                new Peliculas { PeliculaId = 2, Titulo = "El Señor de los Anillos: las dos torres",             Poster = "Poster2", Sinopsis = "Sinopsis2", Trailer = "Trailer2" },
                new Peliculas { PeliculaId = 3, Titulo = "El Señor de los Anillos: el retorno del Rey",         Poster = "Poster3", Sinopsis = "Sinopsis3", Trailer = "Trailer3" },
                new Peliculas { PeliculaId = 4, Titulo = "Spider-Man",                                          Poster = "Poster4", Sinopsis = "Sinopsis4", Trailer = "Trailer4" },
                new Peliculas { PeliculaId = 5, Titulo = "Spider-Man 2",                                        Poster = "Poster5", Sinopsis = "Sinopsis5", Trailer = "Trailer5" },
                new Peliculas { PeliculaId = 6, Titulo = "Spider-Man 3",                                        Poster = "Poster6", Sinopsis = "Sinopsis6", Trailer = "Trailer6" },
                new Peliculas { PeliculaId = 7, Titulo = "The Amazing Spider-Man",                              Poster = "Poster7", Sinopsis = "Sinopsis7", Trailer = "Trailer7" },
                new Peliculas { PeliculaId = 8, Titulo = "Spider-Man: Un nuevo universo",                       Poster = "Poster8", Sinopsis = "Sinopsis8", Trailer = "Trailer8" }
            );

            modelBuilder.Entity<Funciones>().HasData(
                new Funciones { FuncionId = 1, PeliculaId = 1, SalaId = 1, Fecha = Convert.ToDateTime("2021-09-06"), Horario = new TimeSpan(10,30,00)},
                new Funciones { FuncionId = 2, PeliculaId = 2, SalaId = 2, Fecha = Convert.ToDateTime("2021-09-12"), Horario = new TimeSpan(12, 30, 00)},
                new Funciones { FuncionId = 3, PeliculaId = 5, SalaId = 3, Fecha = Convert.ToDateTime("2021-09-15"), Horario = new TimeSpan(09, 15, 00) }
            ); ;

        }
    }
}