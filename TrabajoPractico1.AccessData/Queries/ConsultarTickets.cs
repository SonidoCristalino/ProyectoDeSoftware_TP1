using System.Linq;
using System.Collections.Generic;
using TrabajoPractico1.Domain.Entities;

namespace TrabajoPractico1.AccessData.Queries
{
    public class ConsultasDeTickets
    {
        public IList<Tickets> buscarTicketPorFuncion(int funcionId)
        {
            using (var cine = new CineDbContext())
            {
                var selecccion = cine.Tickets
                    .Where(Ticket => Ticket.FuncionId == funcionId)
                    .ToList();

                return selecccion;
            }

        }
    }
}
