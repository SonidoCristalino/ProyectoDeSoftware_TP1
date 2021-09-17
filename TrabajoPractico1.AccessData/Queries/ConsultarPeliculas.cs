using System.Linq;
using System.Collections.Generic;
using TrabajoPractico1.Domain.Entities;


namespace TrabajoPractico1.AccessData.Queries
{
    
    public class Consultas
    {
        public IList<Peliculas> mostrarPeliculas(int peliID)
        {
            using (var saraza = new CineDbContext() ) {
                
                var x = saraza.Peliculas.Where(
                    algo => algo.PeliculaId == peliID
                    ).ToList();
                
                return x;
            }

        }

        public IList<Peliculas> mostrarTodasLasPeliculas()
        {
            using (var saraza = new CineDbContext())
            {

                var x = saraza.Peliculas.ToList();

                return x;
            }

        }

        public IList<Funciones> mostrarFuncion(int peliculaID)
        {
            using (var saraza = new CineDbContext())
            {
                //Busca la función de una película cuyo titulo se pase por parametro

                var x = saraza.Funciones
                    .Where(
                        funcion => funcion.PeliculaId.Equals(peliculaID))
                    .ToList();

                return x;
            }

        }

    }
}

