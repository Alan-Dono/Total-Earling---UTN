using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpleadosEntity
{
    public class Empleado
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Documento { get; set; }
        public int Edad { get; set; }
        public bool EstadoCivil { get; set; }
        public double Salario { get; set; }
    }

}
