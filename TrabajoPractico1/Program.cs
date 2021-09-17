using System;
using TrabajoPractico1.AccessData;

namespace TrabajoPractico1
{
    class Program
    {
        static void Main(string[] args)
        {
            TrabajoPractico1.AccessData.Queries.Consultas consultar = new TrabajoPractico1.AccessData.Queries.Consultas();

            Console.WriteLine("La cartelera es \n");
            foreach (var x in consultar.mostrarTodasLasPeliculas())
            {
                Console.WriteLine(x.Titulo + "\n");
            }

            Console.WriteLine("Ingrese un numero entre 1 y 2: ");
            int key = int.Parse(Console.ReadLine());

            foreach (var x in consultar.mostrarPeliculas(key))
            {
                Console.WriteLine("La pelicula es " + x.Titulo);
            }

            Console.WriteLine("Se muestran las funciones que tengan un mismo ID: \n");
            foreach (var x in consultar.mostrarFuncion(1))
            {
                Console.WriteLine("La pelicula es " + x.PeliculaId + " Y la sala es: " + x.Fecha);
            }
        }
    }
}
