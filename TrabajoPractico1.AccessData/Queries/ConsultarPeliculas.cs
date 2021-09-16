using System.Linq;
using System.Collections.Generic;
using TrabajoPractico1.Domain.Entities;


namespace TrabajoPractico1.AccessData.Queries
{
    
    public class ConsultarPeliculas
    {
        public IList<Peliculas> mostrarPeliculas()
        {
            using (var saraza = new CineDbContext() ) {
                var x = saraza.Peliculas.ToList();
                return x;
            }

        }
    }
}

