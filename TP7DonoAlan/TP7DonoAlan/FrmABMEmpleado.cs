using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLogicLayer;
using EmpleadosEntity;

namespace TP7DonoAlan
{
    public partial class FrmABMEmpleado : Form
    {
        public FrmABMEmpleado()
        {
            InitializeComponent();
        }
        private Empleado user = new Empleado();
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Empleado user = new Empleado();
            user.Nombre = txtNombre.Text;
            user.Edad = Convert.ToInt32(txtEdad.Text);
            user.Documento = txtDocumento.Text;
            user.EsCasado = Convert.ToBoolean(rbCasado.Checked ? "True" : "False");
            user.Salario = Convert.ToDouble(txtSalario.Text);
            EmpleadoBLL.ABMCliente(user);
        }
    }
}
