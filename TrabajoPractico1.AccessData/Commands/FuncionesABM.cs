using System;
using TrabajoPractico1.Domain.Entities;
using System.Text;

namespace TrabajoPractico1.AccessData.Commands
{
    public class FuncionesABM
    {
        public Funciones AltaFunciones(int peliculaID, int salaID, DateTime fecha, TimeSpan horario)
        {
            var nuevaFuncion = new Funciones();
            
            nuevaFuncion.PeliculaId = peliculaID;
            nuevaFuncion.SalaId = salaID;
            nuevaFuncion.Fecha = fecha;
            nuevaFuncion.Horario = horario;

            return nuevaFuncion;

        }
    }
}
