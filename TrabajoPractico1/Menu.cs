﻿using System;
using System.Collections.Generic;
using System.Text;
using TrabajoPractico1.Domain.Entities;

namespace TrabajoPractico1
{
    class Menu
    {

        private int opcion;

        TrabajoPractico1.AccessData.Queries.ConsultasDePeliculas consultarPelicula =
            new TrabajoPractico1.AccessData.Queries.ConsultasDePeliculas();

        TrabajoPractico1.AccessData.Queries.ConsultasDeFunciones consultasDeFunciones =
            new AccessData.Queries.ConsultasDeFunciones();

        TrabajoPractico1.AccessData.Queries.ConsultasDeSalas ConsultasDeSalas =
            new AccessData.Queries.ConsultasDeSalas();

        TrabajoPractico1.AccessData.Queries.ConsultasDeTickets ConsultasDeTickets =
            new AccessData.Queries.ConsultasDeTickets();

        public Menu(int valor)
        {
            opcion = valor;

            this.menuPrincipal(opcion);
        }

        public void menuPrincipal(int opcion)
        {

            while (opcion != 5)
            {
                
                Console.WriteLine("Elija una opción:");
                Console.WriteLine("\t1. Ver las películas disponibles en cartelera. ");
                Console.WriteLine("\t2. Ver las funciones disponibles para una película. ");
                Console.WriteLine("\t3. Obtener un ticket para una función.");
                Console.WriteLine("\t4. Ver la disponibilidad de tickets para las funciones. ");
                Console.WriteLine("\t5. Salir del menú. ");
                Console.Write("Su opción es: ");
                opcion = Convert.ToInt32(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("");
                        Console.WriteLine("\t\t\t*******************************************");
                        Console.WriteLine("\t\t\t* La cartelera disponible es la siguiente:*");
                        Console.WriteLine("\t\t\t*******************************************\n");
                        this.opcion_Nro1();
                        break;
                    
                    case 2:
                        this.opcion_Nro2();
                        break;

                    case 3:
                        this.opcion_Nro1();
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
            
            //Console.Clear();
            //Console.WriteLine("");
            //Console.WriteLine("\t\t\t*******************************************");
            //Console.WriteLine("\t\t\t* La cartelera disponible es la siguiente:*");
            //Console.WriteLine("\t\t\t*******************************************\n");
            foreach (var pelicula in consultarPelicula.buscarTodasLasPeliculas())
            {
                Console.WriteLine("\tPelicula nº " + pelicula.PeliculaId + ": " + pelicula.Titulo);
            }
            Console.WriteLine("");

        }

        public void opcion_Nro2()
        {
            int id_funcion = 0;
          //int id_pelicula = 0;

            this.opcion_Nro1();

            Console.Write("Ingrese la película para ver sus funciones: ");
            opcion = Convert.ToInt32(Console.ReadLine());
            
            Console.WriteLine("");
            Console.WriteLine("\t\t\t************************************************");
            Console.WriteLine("\t\t\t* Las funciones disponibles para esa opción son:*");
            Console.WriteLine("\t\t\t*************************************************\n");
            foreach (var funcion in consultasDeFunciones.buscarFuncionesPorPeliculaID(opcion))
            {
                Console.WriteLine("\tFunción nº:\t{0}", funcion.PeliculaId);
                Console.WriteLine("\tSala nº:\t" + funcion.SalaId);
                Console.WriteLine("\tDía:\t\t{0:d}", funcion.Fecha);
                Console.WriteLine("\tHorario:\t" + funcion.Horario.ToString(@"hh\:mm"));
                id_funcion = funcion.FuncionId;
                //id_pelicula = funcion.PeliculaId;
            }
            Console.WriteLine("");
            Console.WriteLine("¿Desea sacar un ticket para esta función?(S/N)");
            opcion = Convert.ToInt32(Console.ReadLine());

            if (opcion == 'S' || opcion == 's')
            {
                //this.opcion_Nro3(id_funcion);
            }
            //else
            //{

            //}

        }

        public void opcion_Nro3(int idFuncion)
        {
            
            int funcionID = 1;
            int capacidad = 0;
            int TicketXFuncion= 0;

            //Para obtener un ticket hay que: 
            //1. Contar los tickets que hay asociados a la función

            Console.Write("Ingrese la Función a la que quiere asistir: ");
            opcion = Convert.ToInt32(Console.ReadLine());

            //Se lee la capacidad asociada a la sala de la Función
            capacidad = ConsultasDeSalas.buscarSalaPorID(opcion).Capacidad;
            
            //Se obtiene la cantidad de tickets generados por Función
            TicketXFuncion = ConsultasDeTickets.buscarTicketPorFuncion(funcionID).Count;

            //Comparamos para ver si es posible obtener un nuevo ticket
            if (TicketXFuncion < capacidad)
            {
                //Creamos un nuevo ticket
            }
            else
            {
                Console.WriteLine("La Función está completa. Intente en otro momento.");
            }

        }
    }
}
