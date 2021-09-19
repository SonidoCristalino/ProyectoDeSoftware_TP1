using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
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

        TrabajoPractico1.AccessData.Commands.TicketsABM TicketsABM =
            new AccessData.Commands.TicketsABM();

        public Menu(int valor)
        {
            opcion = valor;

            this.menuPrincipal(opcion);
        }

        public void menuPrincipal(int opcion)
        {

            while (opcion != 5)
            {
                Console.WriteLine("");
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
                        this.opcion_Nro1();
                        break;
                    
                    case 2:
                        
                        Console.Clear();
                        this.opcion_Nro2();
                        break;

                    case 3:
                        
                        Console.Clear();
                        this.opcion_Nro3();
                        break;
                    
                    case 4:

                        this.opcion_Nro4();
                        break;
                    
                    case 5:
                        //Console.Write("Su opción es: " + opcion);
                        break;
                    default:
                        Console.WriteLine("ERROR: Opción inválida. Apriete cualquier número y vuelva a intentarlo");
                        break;
                }

            }
        }

        public void opcion_Nro1()
        {
            
            Console.WriteLine("");
            Console.WriteLine("\t\t\t*******************************************");
            Console.WriteLine("\t\t\t* La cartelera disponible es la siguiente:*");
            Console.WriteLine("\t\t\t*******************************************\n");

            foreach (var pelicula in consultarPelicula.buscarTodasLasPeliculas())
            {
                Console.WriteLine("\tPelicula nº " + pelicula.PeliculaId + ": " + pelicula.Titulo);
            }

        }

        public void opcion_Nro2()
        {
            int id_funcion = 0;

            this.opcion_Nro1();
            
            Console.WriteLine("");
            Console.Write("Ingrese el número de la película para ver sus funciones: ");
            opcion = Convert.ToInt32(Console.ReadLine());

            bool hayFunciones = consultasDeFunciones.BuscarFuncionesPorPeliculaID(opcion).Any();

            if (hayFunciones)
            {

                //Ver si no habría que separarla en un método a parte a esta vista
                Console.WriteLine("");
                Console.WriteLine("\t\t\t************************************************");
                Console.WriteLine("\t\t\t* Las funciones disponibles para esa opción son:*");
                Console.WriteLine("\t\t\t*************************************************\n");

                foreach (var funcion in consultasDeFunciones.BuscarFuncionesPorPeliculaID(opcion))
                {
                    Console.WriteLine("\tFunción nº:\t{0}", funcion.PeliculaId);
                    Console.WriteLine("\tSala nº:\t" + funcion.SalaId);
                    Console.WriteLine("\tDía:\t\t{0:d}", funcion.Fecha);
                    Console.WriteLine("\tHorario:\t" + funcion.Horario.ToString(@"hh\:mm"));
                    id_funcion = funcion.FuncionId;
                }

            }
            else
            {
                Console.WriteLine("");
                Console.WriteLine("No hay funciones disponibles para la película seleccionada. Por favor intente con otra opción\n");
            }
           
        }

        //public void opcion_Nro3(int idFuncion)
        public void opcion_Nro3()
        {
            
            int salaID = 0;
            int capacidad = 0;
            int TicketXFuncion= 0;

            this.opcion_Nro1();

            Console.Write("Ingrese la Función a la que quiere asistir: ");
            opcion = Convert.ToInt32(Console.ReadLine());

            //Se obtiene la cantidad de tickets generados por Función
            TicketXFuncion = ConsultasDeTickets.buscarTicketPorFuncion(opcion).Count;

            //Obtenemos el ID de la Sala asociada a la Función
            salaID = consultasDeFunciones.ObtenerFuncionPorID(opcion).SalaId;
            
            //Se lee la capacidad asociada a la Sala
            capacidad = ConsultasDeSalas.buscarSalaPorID(salaID).Capacidad;

            //Comparamos para ver si es posible obtener un nuevo ticket
            if (TicketXFuncion < capacidad)
            {
                Console.Write("\nIngrese su nombre para generar su nuevo ticket: ");
                string nombreUsuario = Console.ReadLine();

                //Creamos un nuevo ticket
                TicketsABM.AltaTicket(Guid.NewGuid(), opcion, nombreUsuario);
            }
            else
            {
                Console.WriteLine("La Función está completa. Intente en otro momento.");
            }

        }

        public void opcion_Nro4()
        {
            //Ver si no habría que separarla en un método a parte a esta vista
            Console.WriteLine("");
            Console.WriteLine("\t\t\t************************************************");
            Console.WriteLine("\t\t\t* Las funciones disponibles son las siguientes:*");
            Console.WriteLine("\t\t\t************************************************\n");

            foreach (var funcion in consultasDeFunciones.ObtenerTodasLasFunciones())
            {
                Console.WriteLine("\tFunción nº:\t{0}", funcion.PeliculaId);
                Console.WriteLine("\tSala nº:\t" + funcion.SalaId);
                Console.WriteLine("\tDía:\t\t{0:d}", funcion.Fecha);
                Console.WriteLine("\tHorario:\t" + funcion.Horario.ToString(@"hh\:mm"));
                Console.WriteLine("");
            }
            
            Console.WriteLine("");
            Console.Write("¿Por cuál Función desea consultar los tickets?: ");
            opcion = Convert.ToInt32(Console.ReadLine());

            Console.Clear();
            Console.WriteLine("La lista de tickets según la función {0} es la siguiente", opcion);
            Console.WriteLine("");
            foreach (var ticket in ConsultasDeTickets.buscarTicketPorFuncion(opcion))
            {
                Console.WriteLine("\tNº de Ticket:\t{0}", ticket.TicketId);
                Console.WriteLine("\tFunción nº:\t" + ticket.FuncionId);
                Console.WriteLine("\tA nombre de:\t" + ticket.Usuario);
                Console.WriteLine("");
            }


        }
    }
}
