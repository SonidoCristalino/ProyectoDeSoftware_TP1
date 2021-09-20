using System.Linq;
using System.Collections.Generic;
using TrabajoPractico1.Domain.Entities;

namespace TrabajoPractico1.AccessData.Queries
{
    public class ConsultasDeSalas
    {

        public Salas buscarSalaPorID(int salaID)
        {
            using (var cine = new CineDbContext())
            {
                var seleccion = cine.Salas
                    .Where(Sala => Sala.SalaId == salaID);

                return seleccion.FirstOrDefault();

            }
        }

        public IList<Salas> buscarTodasLasSalas()
        {
            using (var cine = new CineDbContext())
            {

                var seleccion = cine.Salas.ToList();

                return seleccion;
            }

        }
    }
}
