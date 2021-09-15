using System;
using System.Collections.Generic;
using System.Text;

namespace TrabajoPractico1.Domain.Entities
{
    public class Salas
    {
        public int SalaId { get; set; }
        public int Capacidad { get; set; }
        public IList<Funciones> FuncionesNavigator { get; set; }
    }
}
