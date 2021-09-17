using System;
using System.Collections.Generic;

namespace TrabajoPractico1.Domain.Entities
{
    public class Funciones
    {
        public int FuncionId { get; set; }
        public int PeliculaId { get; set; }
        public int SalaId { get; set; }
        public DateTime Fecha { get; set; }
        public TimeSpan Horario { get; set; }
        public Peliculas Peliculas { get; set; }
        public Salas Salas{ get; set; }
        public virtual IList<Tickets> Tickets { get; set; }
    }
}
