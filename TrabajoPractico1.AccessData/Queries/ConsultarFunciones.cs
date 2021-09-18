﻿using System.Linq;
using System.Collections.Generic;
using TrabajoPractico1.Domain.Entities;

namespace TrabajoPractico1.AccessData.Queries
{
    public class ConsultasDeFunciones
    {
        public IList<Funciones> buscarFuncionesPorID(int peliID)
        {
            using (var cine = new CineDbContext())
            {
                var selecccion = cine.Funciones
                    .Where(Funcion => Funcion.PeliculaId == peliID)
                    .ToList();

                return selecccion;
            }

        }
    }
}