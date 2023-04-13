using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TP3DonoAlan
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\n\n\t\t\t\t...Vamos a crear un objeto Persona...\n\n\t\t\t\t...A continuacion, ingrese los datos...");
            Persona p1 = crearPersona();
            Console.Clear();
            p1.personaToString();
            Console.ReadKey();
        }


        // Funcion para crear una persona
        static Persona crearPersona()
        {   // Variables que solo existen en la funcion
            String nombre, sexo;
            double sueldo, peso, altura; 

            // Logica 
            Console.WriteLine("Nombre: ");
            nombre = Console.ReadLine();
            Console.WriteLine("Sueldo: ");
            sueldo = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Sexo: ");
            sexo = Console.ReadLine();
            Console.WriteLine("Peso: ");
            peso = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Altura: ");
            altura = Convert.ToDouble(Console.ReadLine());

            // Una vez que tenemos los datos creamos un objeto Persona con sus atributos como lo definimos en el constructor
            Persona nuevaPersona = new Persona(nombre, sueldo, sexo, peso, altura); 
            
            // Devolvemos un objeto Persona
            return nuevaPersona;
        }
    }
}
