using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
namespace TPFinalDonoAlan.Model
{
    public class Empleado
    {
        // Atributos

        private int _id;
        private string _name;
        private string _documento;
        private int _edad;
        private bool _esCasado;
        private double _salario;

        // Propiedades

        public int Id
        {
            get => _id;
            set => _id = value;
        }

        [Required(ErrorMessage = "El campo Nombre es requerido")]
        [StringLength(20, ErrorMessage = "El campo Nombre debe tener como máximo 20 caracteres")]
        [RegularExpression("^[a-zA-Z]+$", ErrorMessage = "El campo Nombre solo permite letras")]
        public string Name
        {
            get => _name;
            set => _name = value;
        }

        [Required(ErrorMessage = "El campo Documento es requerido")]
        [RegularExpression("^[0-9]{8}$", ErrorMessage = "El campo Documento debe tener 8 caracteres numéricos")]
        public string Documento
        {
            get => _documento;
            set => _documento = value;
        }

        [Required(ErrorMessage = "El campo Edad es requerido")]
        [Range(18, 65, ErrorMessage = "El campo Edad debe estar entre 18 y 65")]
        public int Edad
        {
            get => _edad;
            set => _edad = value;
        }

        public bool EsCasado
        {
            get => _esCasado;
            set => _esCasado = value;
        }

        [Range(0, 9000000, ErrorMessage = "El campo Salario debe estar entre 0 y 9000000")]
        public double Salario
        {
            get => _salario;
            set => _salario = value;
        }
    }
}

