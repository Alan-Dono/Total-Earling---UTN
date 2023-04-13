using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace TP3DonoAlan
{
    internal class Persona
    {   // Atributos: nombre, sueldo, sexo, peso y altura. 
        private String nombre;
        private double sueldo;
        private String sexo;
        private double peso;
        private double altura;
        private String email;

        // Constructor
        public Persona (String nombre, double sueldo, String sexo, double peso, double altura)
        {
            this.nombre = nombre;
            this.sueldo = sueldo;
            this.sexo = sexo;
            this.peso = peso;
            this.altura = altura;
            this.email = CrearEmail(this.nombre);
        }

        // Getters 
        public String getNombre()
        {
            return nombre;
        }
        public double getSueldo()
        {
            return sueldo;  
        }
        public string getSexo()
        {
            return sexo;
        }

        public double getPeso()
        { 
            return peso;
        } 
        public double getAltura()
        {
            return altura;        }


        // Metodo para crear el email
         private String CrearEmail(String nombre)
        {
            String email = nombre + "@superempresa.com";
            return email;
        }

        // Metodo para mostrar todos los datos de la persona
        public void personaToString()
        {
            Console.WriteLine("-Nombre: " + nombre);
            Console.WriteLine("-Email: " + email);
            Console.WriteLine("-Sueldo: " + sueldo.ToString());
            Console.WriteLine("-Sexo: " + sexo);
            Console.WriteLine("-Peso " +  peso.ToString());
            Console.WriteLine("-Altura: " +  altura.ToString());
        }
    }
}
