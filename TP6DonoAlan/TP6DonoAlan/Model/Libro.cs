using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP6DonoAlan.Model
{
    internal class Libro
    {
        private string _name;
        private string _autor;
        private string _genero;
        private int _paginas;
        private bool _isPrivado { get;}
        private double _precio;

        public Libro(string name, string autor, string genero, int paginas, bool isPrivado, double preio)
        {
            _name = name;
            _autor = autor;
            _genero = genero;
            _paginas = paginas;
            _isPrivado = isPrivado;
            _precio = preio;
        }

        public override string ToString()
        {
            if (this._isPrivado)
            {
                return _name + " - " + _autor + " - " + _genero + " - " + _paginas + " - Importado - " + _precio;
            }
            else
            {
                return _name + " - " + _autor + " - " + _genero + " - " + _paginas + " -  Nacional - " + _precio;
            }
        }
    }
}
