using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TP6DonoAlan.Model;

namespace TP6DonoAlan.Controllers
{
    internal class LibroController
    {
        private  List<Libro> libros = new List<Libro>();
        private static LibroController instance;
        private LibroController() { }
        public static LibroController GetInstance()// Singleton 
        {
            if (instance == null)
            {
                instance = new LibroController();
            }

            return instance;
        }

        public void crearLibro(string name, string autor, string genero, int paginas, bool isPrivado, double preio)
        {
            Libro libro = new Libro(name, autor, genero, paginas, isPrivado, preio);
            libros.Add(libro);
        }

        public List<Libro> getLibros() { return libros; }
    }

}
