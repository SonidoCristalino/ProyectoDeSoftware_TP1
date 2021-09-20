using System.Linq;
using System.Collections.Generic;
using TrabajoPractico1.Domain.Entities;

namespace TrabajoPractico1.AccessData.Queries
{
    public class ConsultasDePeliculas
    {
        public Peliculas buscarPeliculaPorId(int peliID)
        {
            using ( var cine = new CineDbContext() ) 
            {
                var selecccion = cine.Peliculas
                    .Where(pelicula => pelicula.PeliculaId == peliID)
                    .ToList();
                
                return selecccion.First();
            }

        }

        public IList<Peliculas> buscarTodasLasPeliculas()
        {
            using (var cine= new CineDbContext())
            {

                var seleccion = cine.Peliculas.ToList();

                return seleccion;
            }

        }

        public IList<Peliculas> buscarPeliculaPorNombre(string nombre)
        {
            using (var cine = new CineDbContext())
            {

                var seleccion = cine.Peliculas
                        .Where(pelicula => pelicula.Titulo.ToLower().Contains(nombre.ToLower()))
                        .ToList();

                return seleccion;
            }

        }

    }
}

