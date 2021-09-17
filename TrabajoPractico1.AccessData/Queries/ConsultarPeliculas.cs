using System.Linq;
using System.Collections.Generic;
using TrabajoPractico1.Domain.Entities;


namespace TrabajoPractico1.AccessData.Queries
{
    
    public class ConsultasDePeliculas
    {
        public IList<Peliculas> buscarPelicula(int peliID)
        {
            using ( var contex = new CineDbContext() ) 
            {
                var selecccion = contex.Peliculas
                    .Where(id => id.PeliculaId == peliID)
                    .ToList();
                
                return selecccion;
            }

        }

        public IList<Peliculas> mostrarTodasLasPeliculas()
        {
            using (var context= new CineDbContext())
            {

                var seleccion = context.Peliculas.ToList();

                return seleccion;
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

