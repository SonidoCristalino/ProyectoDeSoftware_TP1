using System.Collections.Generic;

namespace TrabajoPractico1.Domain.Entities
{
    public class Salas
    {
        public int SalaId { get; set; }
        public int Capacidad { get; set; }
        public IList<Funciones> Funciones { get; set; }
    }
}
