using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Ingrese el valor del producto para calcular su precio con iva: "); // Pedimos informacion al usuario
            String aux = Console.ReadLine(); // Guardamos el String en una variable
            double producto = Convert.ToDouble(aux); // Lo transformamos a double para porder hacer caluclos
            double productoConIva = (producto * 0.21 + producto); // Hacemos el calculo del precio final y lo guardando en la nueva variable
            double iva = producto * 0.21; // Hacemos el calulo del valor de iva del producto y lo guardamos en la nueva variable
            Console.Clear();
            Console.WriteLine("Precio de IVA       Preio final\n\n");
            Console.WriteLine("      " + iva + "                " + productoConIva);// Mostramos el precio del producto con y sin IVA
            Console.ReadLine();
            
        }
    }
}
