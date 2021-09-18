using System;
using System.Collections.Generic;
using System.Text;
using TrabajoPractico1.Domain.Entities;

namespace TrabajoPractico1
{
    class Menu
    {

        private int opcion;
        private int contador = 1;

        TrabajoPractico1.AccessData.Queries.ConsultasDePeliculas consultarPelicula =
                new TrabajoPractico1.AccessData.Queries.ConsultasDePeliculas();

        TrabajoPractico1.AccessData.Queries.ConsultasDeFunciones consultasDeFunciones =
            new AccessData.Queries.ConsultasDeFunciones();

        public Menu(int valor)
        {
            opcion = valor;

            //sería mejor trabajar todas las películas por ID y listo, para no estar con un contador
            //contador = consultarPelicula.contarPeliculas();
            this.menuPrincipal(opcion);
        }

        public void menuPrincipal(int opcion)
        {

            while (opcion != 5)
            {
                
                Console.WriteLine("Elija una opción:");
                Console.WriteLine("\t1. Ver los títulos disponibles. ");
                Console.WriteLine("\t2. Ver las funciones disponibles para un título. ");
                Console.WriteLine("\t3. Obtener un título para una función.");
                Console.WriteLine("\t4. Ver la disponibilidad de tickets para las funciones. ");
                Console.WriteLine("\t5. Salir del menú. ");
                Console.Write("Su opción es: ");
                opcion = Convert.ToInt32(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        this.opcion_Nro1();
                        break;
                    
                    case 2:
                        this.opcion_Nro1();
                        this.opcion_Nro2();
                        break;

                    case 3:
                        Console.Write("Su opción es: " + opcion);
                        break;
                    case 4:
                        Console.Write("Su opción es: " + opcion);
                        break;
                    case 5:
                        Console.Write("Su opción es: " + opcion);
                        break;
                    default:
                        Console.WriteLine("ERROR: Opción inválida. Apriete cualquier número y vuelva a intentarlo");
                        break;
                }

            }
        }

        public void opcion_Nro1()
        {
            
            Console.Clear();
            Console.WriteLine("");
            Console.WriteLine("\t\t\t*******************************************");
            Console.WriteLine("\t\t\t* La cartelera disponible es la siguiente:*");
            Console.WriteLine("\t\t\t*******************************************\n");
            foreach (var pelicula in consultarPelicula.buscarTodasLasPeliculas())
            {
                Console.WriteLine("\tPelicula nº " + pelicula.PeliculaId + ": " + pelicula.Titulo);
            }
            Console.WriteLine("");

        }

        public void opcion_Nro2()
        {
            
            Console.Write("Ingrese la película para ver sus funciones: ");
            opcion = Convert.ToInt32(Console.ReadLine());
            
            if (opcion < 1 || opcion > contador)
            {

                Console.WriteLine("ERROR: Opción inválida. Apriete cualquier número para continuar");
                opcion = 1;

            } else
            {

                Console.WriteLine("");
                Console.WriteLine("\t\t\t************************************************");
                Console.WriteLine("\t\t\t* Las funciones disponibles para esa opción son:*");
                Console.WriteLine("\t\t\t*************************************************\n");
                foreach (var funcion in consultasDeFunciones.buscarFuncionesPorID(opcion))
                {
                    Console.WriteLine("\tFunción nº:\t{0}", funcion.PeliculaId);
                    Console.WriteLine("\tSala nº:\t" + funcion.SalaId);
                    Console.WriteLine("\tDía:\t\t{0:d}", funcion.Fecha);
                    Console.WriteLine("\tHorario:\t", funcion.Horario.ToString("hh"));
                }
                Console.WriteLine("");

            }

        }
    }
}
