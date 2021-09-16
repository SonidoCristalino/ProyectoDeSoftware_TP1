using System;
using TrabajoPractico1.AccessData;

namespace TrabajoPractico1
{
    class Program
    {
        static void Main(string[] args)
        {
            TrabajoPractico1.AccessData.Queries.ConsultarPeliculas consultar = new TrabajoPractico1.AccessData.Queries.ConsultarPeliculas();
            foreach (var x in consultar.mostrarPeliculas())
            {
                Console.WriteLine("La pelicula es " + x.Titulo);

            }
            
        }
    }
}
