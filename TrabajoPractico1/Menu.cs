using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using TrabajoPractico1.Domain.Entities;
using System.Globalization;
using Microsoft.EntityFrameworkCore;

namespace TrabajoPractico1
{
    public class Menu
    {

        private int opcion;
        private int rangoPeliculas;
        private int rangoSalas;


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
            rangoPeliculas = consultarPelicula.buscarTodasLasPeliculas().Count();
            rangoSalas = ConsultasDeSalas.buscarTodasLasSalas().Count();

            this.menuPrincipal(opcion);
        }

        public void menuPrincipal(int opcion)
        {

            while (opcion != 6)
            {
                Console.WriteLine("");
                Console.WriteLine("Elija una opción:");
                Console.WriteLine("\t1. Ver las películas disponibles en cartelera y su información. ");
                Console.WriteLine("\t2. Ver las funciones disponibles para una película. ");
                Console.WriteLine("\t3. Crear una nueva función.");
                Console.WriteLine("\t4. Obtener un ticket para una función.");
                Console.WriteLine("\t5. Ver la disponibilidad de tickets para las funciones. ");
                Console.WriteLine("\t6. Salir del menú.\n");
                Console.Write("Su opción es: ");
                opcion = Convert.ToInt32(Console.ReadLine());

                switch (opcion)
                {
                    case 1:

                        Console.Clear();
                        this.ListarPeliculasDisponibles();
                        break;
                    
                    case 2:
                        
                        Console.Clear();
                        this.ListarFuncionesDisponibles();
                        break;

                    case 3:

                        Console.Clear();
                        this.CrearFunciones();
                        //Console.WriteLine("Usted está creando una función\n");
                        break;

                    case 4:
                        
                        Console.Clear();
                        this.ObtenerTicketParaFuncion();
                        break;
                    
                    case 5:

                        Console.Clear();
                        this.ListarDisponibilidadTickets();
                        break;
                    
                    case 6:
                        break;

                    default:
                        Console.WriteLine("\n\tERROR: Opción inválida. Intentelo de nuevo.");
                        break;
                }

            }
        }

        public void ListarPeliculasDisponibles()
        {

            this.VistaDeCartelera();

            Console.WriteLine("");
            Console.Write("Ingrese el número de la Película para ver su información: ");
            opcion = Convert.ToInt32(Console.ReadLine());

            if (!(this.validarIngreso(opcion, rangoPeliculas)))
            {
                return;
            }

            this.VistaDePeliculas(opcion);

        }

        public void ListarFuncionesDisponibles()
        {

            this.VistaDeCartelera();

            Console.WriteLine("");
            Console.Write("Ingrese el número de la Película para ver sus funciones: ");
            opcion = Convert.ToInt32(Console.ReadLine());

            if (!(this.validarIngreso(opcion, rangoPeliculas)))
            {
                return;
            }

            bool hayFunciones = consultasDeFunciones.BuscarFuncionesPorPeliculaID(opcion).Any();

            if (hayFunciones)
            {
                this.VistaDeFunciones(opcion);
            }else
            {
                Console.WriteLine("");
                Console.WriteLine("No hay funciones disponibles para la película seleccionada. Por favor intente con otra opción.\n");
            }
           
        }

        public void ObtenerTicketParaFuncion()
        {
            
            int salaID = 0;
            int capacidad = 0;
            int TicketXFuncion= 0;

            this.VistaDeFunciones(0);

            Console.WriteLine("");
            Console.Write("Ingrese el número de Función a la que quiere asistir: ");
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

                //Creamos el contexto para generar un nuevo Ticket
                TrabajoPractico1.AccessData.Commands.TicketsABM nuevoTicket =
                    new AccessData.Commands.TicketsABM();
             
                var cine = new TrabajoPractico1.AccessData.CineDbContext();

                //Creamos el ticket
                Guid nuevoTicketID = Guid.NewGuid();
                cine.Tickets.Add(nuevoTicket.AltaTicket(nuevoTicketID, opcion, nombreUsuario));
                cine.SaveChanges();

                Console.Clear();
                Console.WriteLine("\n¡El ticket se ha creado exitosamente!\n");
                Console.WriteLine("\tDetalle:");
                Console.WriteLine("\t\tNúmero de ticket:\t{0}", nuevoTicketID.ToString());
                Console.WriteLine("\t\tAsociado al nombre:\t{0}", nombreUsuario);

            }else
            {
                Console.WriteLine("\n\tLa Función se encuentra AGOTADA. Intente en otro momento o con otra Función.");
            }

        }

        public void ListarDisponibilidadTickets()
        {
            this.VistaDeFunciones(0);
            
            Console.WriteLine("");
            Console.Write("Ingrese el número de Función para consultar el detalle de sus Tickets: ");
            opcion = Convert.ToInt32(Console.ReadLine());

            int rangoFunciones = consultasDeFunciones.ObtenerTodasLasFunciones().Count();

            if (!(this.validarIngreso(opcion, rangoFunciones)))
            {
                return;
            }

            this.VistaDeTicket(opcion);

        }

        public void CrearFunciones()
        {

            this.VistaDeCartelera();
            this.VistaDeSalas();

            Console.Write("Con los datos descriptos anteriormente, ingrese el Número de PELÍCULA deseado: ");
            int peliculaID = int.Parse(Console.ReadLine());
            if ( !(this.validarIngreso(peliculaID, rangoPeliculas)) )
            {
                return;
            }

            Console.Write("Ingrese el Núermo de SALA donde quiere proyectar la película: ");
            int salaID = int.Parse(Console.ReadLine());
            if (!(this.validarIngreso(salaID, rangoSalas)))
            {
                return;
            }

            Console.Write("\tIngrese la fecha de la función (AAAA/MM/DD): ");
            DateTime fechaFuncion = Convert.ToDateTime(Console.ReadLine());

            Console.Write("\tIngrese la hora para la Nueva Función (Ej: HH): ");
            int horaFuncion = int.Parse(Console.ReadLine());

            Console.Write("\tIngrese los minutos para la Nueva Función (Ej: MM): ");
            int minutosFuncion = int.Parse(Console.ReadLine());

            //Calculamos el tiempo necesario para poder realizar la consulta 
            TimeSpan duracion = new TimeSpan(2, 30, 0);
            TimeSpan inicioNuevaFuncion = new TimeSpan(horaFuncion, minutosFuncion, 00);
            TimeSpan finFuncionNueva = inicioNuevaFuncion.Add(duracion);

            bool solapamientoDeFunciones = false;

            foreach (var funcion in consultasDeFunciones.
                ObtenerFuncionesPorFecha(salaID, fechaFuncion))
            {
                TimeSpan horarioFin = funcion.Horario.Add(duracion);

                if ((inicioNuevaFuncion >= funcion.Horario && inicioNuevaFuncion <= horarioFin)
                    || (finFuncionNueva >= funcion.Horario && finFuncionNueva <= horarioFin))
                {
                    solapamientoDeFunciones = true;
                }
            }

            if (solapamientoDeFunciones)
            {
                Console.Write("\n\t¡Existe un solapamiento con otras funciones. IMPOSIBLE de generarla!\n");
            }
            else
            {

                //Creamos el contexto para generar un nuevo Ticket y luego lo creamos
                TrabajoPractico1.AccessData.Commands.FuncionesABM nuevaFuncion =
                    new AccessData.Commands.FuncionesABM();

                var cine = new TrabajoPractico1.AccessData.CineDbContext();

                cine.Funciones.Add(nuevaFuncion.AltaFunciones(peliculaID, salaID, fechaFuncion, inicioNuevaFuncion));
                try
                {
                    cine.SaveChanges();
                }
                catch (DbUpdateException e)
                {
                    Console.Write("\n\tERROR: Se ingresó un valor inválido. La función NO ha sido creada.\n");
                    return;
                }

                Console.Write("\n\t¡Función generada con EXITO!\n");
                Console.Write("\n\t¡Detalle de la nueva Función: !\n");
                Console.Write("\n\t\tPelícula nº...... {0}", peliculaID);
                Console.Write("\n\t\tSala nº.......... {0}", salaID);
                Console.Write("\n\t\tFecha............ {0:dd}/{0:MM}/{0:yyyy}", fechaFuncion);
                Console.Write("\n\t\tHorario.......... {0:hh}:{0:mm}hs\n", inicioNuevaFuncion);

            }
        }

        public void VistaDeCartelera()
        {
            Console.WriteLine("");
            Console.WriteLine("\t\t\t********************************************");
            Console.WriteLine("\t\t\t* La cartelera disponible es la siguiente: *");
            Console.WriteLine("\t\t\t********************************************\n");

            foreach (var pelicula in consultarPelicula.buscarTodasLasPeliculas())
            {
                Console.WriteLine("\tPelicula nº " + pelicula.PeliculaId + ": " + pelicula.Titulo);
            }
        }

        public void VistaDePeliculas(int peliculaID)
        {

            Console.WriteLine("");
            Console.WriteLine("\t\t\t**************************************************");
            Console.WriteLine("\t\t\t* La información de la pelicula seleccionada es: *");
            Console.WriteLine("\t\t\t**************************************************\n");

            Peliculas PeliculaInfo = consultarPelicula.buscarPeliculaPorId(peliculaID);
            
            Console.WriteLine("\tPelícula nº:......... {0} - {1}", PeliculaInfo.PeliculaId, PeliculaInfo.Titulo);
            Console.WriteLine("\tPoster:.............. {0}", PeliculaInfo.Poster);
            Console.WriteLine("\tSinopsis............. {0}", PeliculaInfo.Sinopsis);
            Console.WriteLine("\tLink Trailer:........ {0}", PeliculaInfo.Trailer);
            Console.WriteLine("");

        }
        
        public void VistaDeFunciones(int funcionID)
        {
            //Si es 0 lista todas, caso contrario lista la/s funcion/es que tengan esa película

            Console.WriteLine("");
            Console.WriteLine("\t\t\t*************************************************");
            Console.WriteLine("\t\t\t* Las funciones disponibles son las siguientes: *");
            Console.WriteLine("\t\t\t*************************************************\n");

            if (funcionID == 0)
            {

                foreach (var funcion in consultasDeFunciones.ObtenerTodasLasFunciones())
                {
                    int CantTicketsFuncion = ConsultasDeTickets.buscarTicketPorFuncion(funcion.FuncionId).Count();
                    int capacidadSala = ConsultasDeSalas.buscarSalaPorID(funcion.SalaId).Capacidad;
                    string nombrePelicula = consultarPelicula.buscarPeliculaPorId(funcion.PeliculaId).Titulo;
                    string mensajeAgotado = "";

                    if (CantTicketsFuncion == capacidadSala)
                    {
                        mensajeAgotado = " (¡¡FUNCIÓN AGOTADA!!)";
                    }

                    Console.WriteLine("\tFunción nº:.......... {0}", funcion.FuncionId);
                    Console.WriteLine("\tPelícula nº:......... {0} - {1}", funcion.PeliculaId, nombrePelicula);
                    Console.WriteLine("\tTickets Vendidos:.... {0}{1}", CantTicketsFuncion, mensajeAgotado);
                    Console.WriteLine("\tSala nº:............. {0}", funcion.SalaId);
                    Console.WriteLine("\tCapacidad............ {0} personas", capacidadSala);
                    Console.WriteLine("\tDía:................. {0:d}", funcion.Fecha);
                    Console.WriteLine("\tHorario:............. {0} hs.", funcion.Horario.ToString(@"hh\:mm"));
                    Console.WriteLine("");
                }

            }else
            {

                foreach (var funcion in consultasDeFunciones.BuscarFuncionesPorPeliculaID(funcionID))
                {
                    int CantTicketsFuncion = ConsultasDeTickets.buscarTicketPorFuncion(funcion.FuncionId).Count();
                    int capacidadSala = ConsultasDeSalas.buscarSalaPorID(funcion.SalaId).Capacidad;
                    string nombrePelicula = consultarPelicula.buscarPeliculaPorId(funcion.PeliculaId).Titulo;
                    string mensajeAgotado = "";

                    if (CantTicketsFuncion == capacidadSala)
                    {
                        mensajeAgotado = " (¡¡FUNCIÓN AGOTADA!!)";
                    }

                    Console.WriteLine("\tFunción nº:.......... {0}", funcion.FuncionId);
                    Console.WriteLine("\tPelícula nº:......... {0} - {1}", funcion.PeliculaId, nombrePelicula);
                    Console.WriteLine("\tTickets Vendidos:.... {0}{1}", CantTicketsFuncion, mensajeAgotado);
                    Console.WriteLine("\tSala nº:............. {0}", funcion.SalaId);
                    Console.WriteLine("\tCapacidad............ {0} personas", capacidadSala);
                    Console.WriteLine("\tDía:................. {0:d}", funcion.Fecha);
                    Console.WriteLine("\tHorario:............. {0} hs.", funcion.Horario.ToString(@"hh\:mm"));
                    Console.WriteLine("");
                }

            }
        }

        public void VistaDeTicket(int ticketID)
        {
            Console.Clear();
            Console.WriteLine("");
            Console.WriteLine("La lista de tickets según la Función nº {0} es la siguiente:", ticketID);
            Console.WriteLine("");

            foreach (var ticket in ConsultasDeTickets.buscarTicketPorFuncion(ticketID))
            {
                Console.WriteLine("\tNº de Ticket:\t{0}", ticket.TicketId);
                Console.WriteLine("\tFunción nº:\t" + ticket.FuncionId);
                Console.WriteLine("\tA nombre de:\t" + ticket.Usuario);
                Console.WriteLine("");
            }
        }

        public void VistaDeSalas()
        {
            Console.WriteLine("");
            Console.WriteLine("\t\t\t*********************************************");
            Console.WriteLine("\t\t\t* Las Salas disponibles son las siguientes: *");
            Console.WriteLine("\t\t\t*********************************************\n");

            foreach (var salas in ConsultasDeSalas.buscarTodasLasSalas())
            {
                Console.WriteLine("\tSala Nº...... {0}", salas.SalaId);
                Console.WriteLine("\tCapacidad.... {0} personas\n", salas.Capacidad);
            }
        }

        public bool validarIngreso(int dato, int rangoDeValores)
        {
            if (!(dato >= 1 && dato <= rangoDeValores))
            {
                Console.Write("\n\tERROR: El rango ingresado NO es válido. Intentelo en otra ocasión.\n");
                return false;
            }
            else
            {
                return true;
           }
        }


    }
}
