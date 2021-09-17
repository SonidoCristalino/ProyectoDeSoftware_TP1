using System;
using TrabajoPractico1.AccessData;

namespace TrabajoPractico1
{
    class Program
    {
        static void Main(string[] args)
        {
            TrabajoPractico1.AccessData.Queries.ConsultasDePeliculas consultarPelicula = new TrabajoPractico1.AccessData.Queries.ConsultasDePeliculas();

            Console.WriteLine("La información de la película ingresada es la siguiente:");
            foreach (var x in consultarPelicula.buscarPelicula(1))
            {
                Console.WriteLine("Título: \t" + x.Titulo);
                Console.WriteLine("Poster: \t" + x.Poster);
                Console.WriteLine("Sinopsis \t" + x.Sinopsis);
                Console.WriteLine("Trailer: \t" + x.Trailer);
            }



            //Console.WriteLine("Ingrese un numero entre 1 y 2: ");
            //int key = int.Parse(Console.ReadLine());

            //foreach (var x in consultar.buscarPelicula(key))
            //{
            //    Console.WriteLine("La pelicula es " + x.Titulo);
            //}

            //Console.WriteLine("Se muestran las funciones que tengan un mismo ID: \n");
            //foreach (var x in consultar.mostrarFuncion(1))
            //{
            //    Console.WriteLine("La pelicula es " + x.PeliculaId + " Y la sala es: " + x.Fecha);
            //}
        }
    }
}
