using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TPFinalDonoAlan.Controller;
using TPFinalDonoAlan.Model;

namespace TPFinalDonoAlan.View
{
    public partial class FrmUIDatos : Form
    {
        EmpleadoController controller = EmpleadoController.getInstance();
        public FrmUIDatos()
        {
            InitializeComponent();    
        }

        private void FrmUIDatos_Load(object sender, EventArgs e)
        {
            dgvDatos.AutoGenerateColumns = false;
            LimpiarYAgregarEmpleados(controller.getListEmpleados());
            desHabilitarComponentes();
        }
        private bool esCasado()
        {
            bool esCasado = false;
            if (cbCasadi.SelectedItem.ToString() == "Casado/a") 
            {
                esCasado = true;
            }
            return esCasado;
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Empleado empleado = new Empleado
            {
                Name = txtNombre.Text,
                Documento = txtDocumento.Text,
                Edad = Convert.ToInt32(txtEdad.Text),
                EsCasado = esCasado(),
                Salario = Convert.ToDouble(txtSalario.Text)
            };

            ValidationContext context = new ValidationContext(empleado, serviceProvider: null, items: null);
            List<ValidationResult> results = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(empleado, context, results, validateAllProperties: true);

            if (isValid)
            {
                if (lblId.Text == string.Empty)
                {
                    controller.insertarEmpleado(empleado.Name, empleado.Documento, empleado.Edad, empleado.EsCasado, empleado.Salario);
                }
                else
                {
                    int id = Convert.ToInt32(lblId.Text);
                    controller.modificarEmpleado(id, empleado.Name, empleado.Documento, empleado.Edad, empleado.EsCasado, empleado.Salario);
                }

                LimpiarYAgregarEmpleados(controller.getListEmpleados());
                limpiarComponentes();
                desHabilitarComponentes();
            }
            else
            {
                // Mostrar los mensajes de error de validación
                foreach (ValidationResult result in results)
                {
                    MessageBox.Show(result.ErrorMessage, "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void desHabilitarComponentes()
        {
            txtSalario.Enabled = false;
            txtEdad.Enabled = false;
            txtNombre.Enabled = false;
            txtDocumento.Enabled = false;
            cbCasadi.Enabled = false;
            btnCancelar.Enabled = false;
            btnGuardar.Enabled = false;
            lblCbox.Enabled = false;
            lblDni.Enabled = false; 
            lblSalario.Enabled = false;
            lblEdad.Enabled = false;
            lblNombre.Enabled = false;
            btnModificar.Enabled = true;
            btnNuevo.Enabled = true;
            btnEliminar.Enabled = true;
        }
        private void habilitarComponentes()
        {
            txtSalario.Enabled = true;
            txtEdad.Enabled = true;
            txtNombre.Enabled = true;
            txtDocumento.Enabled = true;
            cbCasadi.Enabled = true;
            btnCancelar.Enabled = true;
            btnGuardar.Enabled = true;
            lblCbox.Enabled = true;
            lblDni.Enabled = true;
            lblSalario.Enabled = true;
            lblEdad.Enabled = true;
            lblNombre.Enabled = true;
            btnModificar.Enabled = false;
            btnNuevo.Enabled = false;
            btnEliminar.Enabled = false;
            lblId.Text = string.Empty;
        }
        private void limpiarComponentes()
        {
            txtDocumento.Clear();
            txtSalario.Clear();
            txtEdad.Clear();
            txtNombre.Clear();
            cbCasadi.Text = " Selecione";
            
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            habilitarComponentes();
        }
        private void LimpiarYAgregarEmpleados(List<Empleado> empleados)
        {
            dgvDatos.Rows.Clear(); // Limpiar todas las filas existentes
            foreach (Empleado empleado in empleados)
            {
                bool existe = dgvDatos.Rows.Cast<DataGridViewRow>().Any(row =>
                    Convert.ToInt32(row.Cells[0].Value) == empleado.Id);
                if (!existe)
                {
                    DataGridViewRow fila = new DataGridViewRow();
                    fila.CreateCells(dgvDatos);
                    fila.Cells[0].Value = empleado.Id;
                    fila.Cells[1].Value = empleado.Name;
                    fila.Cells[2].Value = empleado.Documento;
                    fila.Cells[3].Value = empleado.Edad;
                    fila.Cells[4].Value = empleado.EsCasado;
                    fila.Cells[5].Value = empleado.Salario;
                    dgvDatos.Rows.Add(fila);
                }
            }
        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            string filtro = txtFilter.Text.Trim().ToLower();
            List<Empleado> empleadosFiltrados = controller.getListEmpleados().Where(empleado =>
                empleado.Name.ToLower().Contains(filtro) ||
                empleado.Documento.ToLower().Contains(filtro)
            ).ToList();

            LimpiarYAgregarEmpleados(empleadosFiltrados);
        }

        private string esSoltero(DataGridViewRow  filaSeleccionada)
        {
            bool estado = Convert.ToBoolean(filaSeleccionada.Cells["EstadoCivil"].Value);
            if (estado)
            {
                return "Casado/a";
            }
            else
            {
                return "Soltero/a";
            }
        }
               
        private void btnModificar_Click(object sender, EventArgs e)
            {
            if (dgvDatos.SelectedRows.Count > 0) // Verificar si hay alguna fila seleccionada
            {
                habilitarComponentes();
                DataGridViewRow filaSeleccionada = dgvDatos.SelectedRows[0];
                // Obtener los valores de las celdas de la fila seleccionada
                lblId.Text = Convert.ToString(filaSeleccionada.Cells["Id"].Value);
                txtNombre.Text = Convert.ToString(filaSeleccionada.Cells["Name"].Value);
                txtDocumento.Text = Convert.ToString(filaSeleccionada.Cells["Documento"].Value);
                txtEdad.Text = Convert.ToString(filaSeleccionada.Cells["Edad"].Value);
                cbCasadi.SelectedItem = esSoltero(filaSeleccionada);
                txtSalario.Text = Convert.ToString(filaSeleccionada.Cells["Salario"].Value);
            }
            else
            {
                MessageBox.Show("No se ha seleccionado ninguna fila.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            DataGridViewRow filaSeleccionada = dgvDatos.SelectedRows[0];
            controller.eliminarEmpleado(Convert.ToInt32(filaSeleccionada.Cells["Id"].Value));
            LimpiarYAgregarEmpleados(controller.getListEmpleados());
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            limpiarComponentes();
            desHabilitarComponentes();
        }

        private void dgvDatos_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex >= 0 && e.RowIndex >= 0) // Verifica que no sea la fila de encabezado
            {
                if (dgvDatos.Columns[e.ColumnIndex].Name == "EstadoCivil") 
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
    }
}
