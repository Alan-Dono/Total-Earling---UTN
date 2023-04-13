using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int aux = 0; // Declaramos la variable de contador
            while(aux <= 100) // Mientras sea menor o igual a 100 va a iterar
            {
                if (aux % 2 != 0) // Si su resto de dividir entre 2 es distinto de 0, entonces imprimiemos el numero
                {
                    Console.Write(aux + "  ");
                }
                aux++;
            }
            Console.ReadLine();
        }
    }
}
