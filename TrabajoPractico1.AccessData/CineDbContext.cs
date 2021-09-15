using Microsoft.EntityFrameworkCore;
using TrabajoPractico1.Domain.Entities;

namespace TrabajoPractico1.AccessData
{
    public class CineDbContext : DbContext
    {
        public CineDbContext(DbContextOptions<CineDbContext> options)
            : base(options)
        {
        }

        public DbSet<Peliculas> Peliculas { get; set; }
        public DbSet<Funciones> Funciones { get; set; }
        public DbSet<Salas> Salas { get; set; }
        public DbSet<Tickets> Tickets { get; set; }


    }
}