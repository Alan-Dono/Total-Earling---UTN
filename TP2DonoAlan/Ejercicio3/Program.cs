using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Ingrese el valor del producto para calcular su precio con iva: ");
            String aux = Console.ReadLine();
            double producto = Convert.ToDouble(aux);
            double productoConIva = CalcularIVA(producto);
            Console.WriteLine("El precio final con IVA es:  " + productoConIva);
            Console.ReadLine();
        }
        static double CalcularIVA(double producto)
        {
            double productoConIva = producto * 0.21 + producto;
            return productoConIva;
        }
    }
}

