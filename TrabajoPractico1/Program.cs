﻿using System;
using TrabajoPractico1.AccessData;

namespace TrabajoPractico1
{
    class Program
    {
        static void Main(string[] args)
        {
            
            int opcion = 0;

            Console.WriteLine("");
            Console.WriteLine("\t\t\t*******************************************");
            Console.WriteLine("\t\t\t ¡Bienvenido a la cartelera del Cine UNAJ! \n");
            Console.WriteLine("\t\t\t*******************************************");

            try
            {
                Menu menu = new Menu(opcion);
            }
            catch (FormatException)
            {

                Console.WriteLine("\n¡ERROR!: Se ingresó mal el dato, por favor intente nuevamente en otra ocasión. \n");
                return;
            }

        }
    }
}
