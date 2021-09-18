using System;
using TrabajoPractico1.Domain.Entities;
using System.Text;

namespace TrabajoPractico1.AccessData.Commands
{
    public class TicketsABM
    {
        public Tickets AltaTicket(Guid ticketID, int funcionID, string usuario)
        {
            var ticket = new Tickets();

            ticket.TicketId = Guid.NewGuid();
            ticket.FuncionId = funcionID;
            ticket.Usuario = usuario;

            return ticket;
        }
    }
}
