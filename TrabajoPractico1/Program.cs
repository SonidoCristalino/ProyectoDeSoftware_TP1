using System;
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
            Console.WriteLine("\t\t\t******************************************* \n");

            try
            {
                Menu menu = new Menu(opcion);
            }
            catch (Exception valor)
            {
                Console.WriteLine(valor.ToString());
                throw;
            }

        }
    }
}
