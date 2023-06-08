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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dgvPersonal.AutoGenerateColumns = false;
            dgvPersonal.DataSource = EmpleadoBLL.ListarClientes();
            desHabilitarComponentes();

        }
        private void habilitarComponentes()
        {
            txtDocumento.Enabled = true;
            txtEdad.Enabled = true;
            txtNombre.Enabled = true;
            txtSalario.Enabled = true;
            rbCasado.Enabled = true;
            rbSoltero.Enabled = true;
            btnCancel.Enabled = true;
            btnGuardar.Enabled = true;
            btnNuevoEmpleado.Enabled = false;
            label1.Enabled = true;
            label2.Enabled = true;  
            label3.Enabled = true;  
            label4.Enabled = true;  
        }
        private void desHabilitarComponentes()
        {
            txtDocumento.Enabled = false;
            txtEdad.Enabled = false;
            txtNombre.Enabled = false;
            txtSalario.Enabled = false;
            rbCasado.Enabled = false;
            rbSoltero.Enabled = false;
            btnCancel.Enabled = false;
            btnGuardar.Enabled = false;
            btnNuevoEmpleado.Enabled = true;
            label1.Enabled = false;
            label2.Enabled = false;
            label3.Enabled = false;
            label4.Enabled = false;
        }
        private void limpiarComponentes()
        {
            txtDocumento.Clear();
            txtEdad.Clear();
            txtNombre.Clear();
            txtSalario.Clear();
            rbCasado.Checked = false;
            rbSoltero.Checked = false;
        }
        private void dgvPersonal_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        { 
            if (e.ColumnIndex >= 0 && e.RowIndex >= 0) // Verifica que no sea la fila de encabezado
            {
                if (dgvPersonal.Columns[e.ColumnIndex].Name == "casado") // Reemplaza "TU_NOMBRE_DE_COLUMN" con el nombre de la columna correspondiente
                {
                    if (e.Value != null)
                    {
                        if (bool.TryParse(e.Value.ToString(), out bool estadoCivil))
                        {
                            e.Paint(e.CellBounds, DataGridViewPaintParts.All & ~DataGridViewPaintParts.ContentForeground);

                            string texto = estadoCivil ? "Casado/a" : "Soltero/a";
                            using (SolidBrush brush = new SolidBrush(e.CellStyle.ForeColor))
                            {
                                e.Graphics.DrawString(texto, e.CellStyle.Font, brush, e.CellBounds.X + 2, e.CellBounds.Y + 2);
                            }
                            e.Handled = true;
                        }
                    }
                }
            }
        }

        private void btnNuevoEmpleado_Click(object sender, EventArgs e)
        {
            btnNuevoEmpleado.Enabled = false;
            habilitarComponentes();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            btnNuevoEmpleado.Enabled = true;
            desHabilitarComponentes();
            limpiarComponentes();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Empleado user = new Empleado();
            user.Nombre = txtNombre.Text;
            user.Documento = txtDocumento.Text;
            user.Edad = Convert.ToInt32(txtEdad.Text);
            user.EstadoCivil = radiobutonSelected();
            user.Salario = Convert.ToDouble(txtSalario.Text);
            EmpleadoBLL.ABMCliente(user);
            limpiarComponentes();
            desHabilitarComponentes();
            dgvPersonal.AutoGenerateColumns = false;
            dgvPersonal.DataSource = null;
            dgvPersonal.DataSource = EmpleadoBLL.ListarClientes();
        }
        private bool radiobutonSelected()
        {
            if (rbCasado.Checked)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
