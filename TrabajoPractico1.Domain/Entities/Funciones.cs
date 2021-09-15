using System;
using System.Collections.Generic;
using System.Text;

namespace TrabajoPractico1.Domain.Entities
{
    public class Funciones
    {
        public int FuncionId { get; set; }
        public int PeliculaId { get; set; }
        public int SalaId { get; set; }
        public DateTime Fecha { get; set; }
        public TimeSpan Horario { get; set; }
        public Peliculas PeliculasNavigator { get; set; }
        public Salas SalasNavigator { get; set; }
        public IList<Tickets> TicketsNavigator { get; set; }
    }
}
