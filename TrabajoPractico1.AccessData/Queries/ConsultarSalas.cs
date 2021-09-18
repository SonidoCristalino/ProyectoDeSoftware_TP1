using System.Linq;
using System.Collections.Generic;
using TrabajoPractico1.Domain.Entities;

namespace TrabajoPractico1.AccessData.Queries
{
    public class ConsultasDeSalas
    {
        public IList<Salas> buscarSalaSPorID(int salasID)
        {
            using (var cine = new CineDbContext())
            {
                var selecccion = cine.Salas
                    .Where(Sala => Sala.SalaId == salasID)
                    .ToList();

                return selecccion;
            }

        }

        public Salas buscarSalaPorID(int salaID)
        {
            using (var cine = new CineDbContext())
            {
                var seleccion = cine.Salas
                    .Where(Sala => Sala.SalaId == salaID);

                return seleccion.FirstOrDefault();

            }
        }
    }
}
