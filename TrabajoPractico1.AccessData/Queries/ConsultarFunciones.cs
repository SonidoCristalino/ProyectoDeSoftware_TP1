using System.Linq;
using System.Collections.Generic;
using TrabajoPractico1.Domain.Entities;

namespace TrabajoPractico1.AccessData.Queries
{
    public class ConsultasDeFunciones
    {
        public IList<Funciones> BuscarFuncionesPorPeliculaID(int peliID)
        {
            using (var cine = new CineDbContext())
            {
                var selecccion = cine.Funciones
                    .Where(Funcion => Funcion.PeliculaId == peliID)
                    .ToList();

                return selecccion;
            }

        }

        public IList<Funciones> BuscarFuncionesPorID(int funcionID)
        {
            using (var cine = new CineDbContext())
            {
                var selecccion = cine.Funciones
                    .Where(Funcion => Funcion.FuncionId == funcionID)
                    .ToList();

                return selecccion;
            }

        }

        public Funciones ObtenerFuncionPorID(int funcionID)
        {
            using (var cine = new CineDbContext())
            {
                var seleccion = cine.Funciones
                    .Where(Funcion => Funcion.FuncionId == funcionID);

                return seleccion.First();
            }

        }
        public IList<Funciones> ObtenerTodasLasFunciones()
        {
            using (var cine = new CineDbContext())
            {
                var seleccion = cine.Funciones.ToList();

                return seleccion;
            }

        }
    }
}
