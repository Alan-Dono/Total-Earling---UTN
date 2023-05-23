using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TP6DonoAlan.Controllers;
using TP6DonoAlan.Model;

namespace TP6DonoAlan
{
    public partial class Form1 : Form
    {
        LibroController controller = LibroController.GetInstance();
        public Form1()
        {
            InitializeComponent(); 
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            controller.crearLibro(txtName.Text, txtAutor.Text, cbGenero.Text, Convert.ToInt32(txtPaginas.Text), chkBoxSi.Checked, Convert.ToDouble(txtPrecio.Text));
            limpiarCampos();
            mostrar();
        }

       private void limpiarCampos()
        {
            txtAutor.Text = "";
            txtName.Text = "";
            txtPrecio.Text = "";
            txtPaginas.Text = "";
            cbGenero.SelectedIndex = -1;
            chkBoxSi.Checked = false;
        }
        private void mostrar()
        {
            lboxDatos.Items.Clear();
            foreach(var objet in controller.getLibros())
            {
                lboxDatos.Items.Add(objet.ToString());
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            limpiarCampos();
        }
    }
}
