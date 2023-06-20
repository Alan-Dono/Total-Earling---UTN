using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPFinalDonoAlan.Model;
using System.Windows.Forms;

namespace TPFinalDonoAlan.Controller
{
    public class EmpleadoController
    {
        private static EmpleadoController instance;
        private EmpleadoController() { }

        public static EmpleadoController getInstance()
        {
            if (instance == null)
            {
                instance = new EmpleadoController();
            }
            return instance;
        }

        public List<Empleado> getListEmpleados()
        {
            List<Empleado> empleados = new List<Empleado>();
            try
            {
                using (SqlConnection myConexion = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConexion"].ToString()))
                {
                    myConexion.Open();
                    string query = @"ListarEmpleados";
                    SqlCommand comando = new SqlCommand(query, myConexion);
                    comando.CommandType = CommandType.StoredProcedure;
                    SqlDataReader leer = comando.ExecuteReader();
                    while (leer.Read())
                    {
                        empleados.Add(getEmpleado(leer));
                    }
                    leer.Close();
                }
            }
            catch (Exception ex)
            {
                // Mostrar un MessageBox de error en caso de excepción
                MessageBox.Show("Ocurrió un error al obtener la lista de empleados: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return empleados;
        }

        public Empleado getEmpleado(SqlDataReader reader)
        {
            Empleado empleado = new Empleado();
            empleado.Id = Convert.ToInt32(reader["Id"]);
            empleado.Name = Convert.ToString(reader["NombreCompleto"]);
            empleado.Documento = Convert.ToString(reader["DNI"]);
            empleado.Edad = Convert.ToInt32(reader["Edad"]);
            empleado.EsCasado = Convert.ToBoolean(reader["Casado"]);
            empleado.Salario = Convert.ToDouble(reader["Salario"]);
            return empleado;
        }
        public void modificarEmpleado(int id, string nombre, string documento, int edad, bool esCasado, double salario)
        {
            // Mostrar un MessageBox de confirmación al usuario
            DialogResult result = MessageBox.Show("¿Estás seguro de que deseas guardar los cambios?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                try
                {
                    using (SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConexion"].ToString()))
                    {
                        conexion.Open();
                        string query = @"UpdateEmpleado";
                        SqlCommand comando = new SqlCommand(query, conexion);
                        comando.CommandType = CommandType.StoredProcedure;
                        comando.Parameters.Add("@id", SqlDbType.Int).Value = id;
                        comando.Parameters.Add("@NombreCompleto", SqlDbType.VarChar).Value = nombre;
                        comando.Parameters.Add("@DNI", SqlDbType.VarChar).Value = documento;
                        comando.Parameters.Add("@Edad", SqlDbType.Int).Value = edad;
                        comando.Parameters.Add("@Casado", SqlDbType.Bit).Value = esCasado;
                        comando.Parameters.Add("@Salario", SqlDbType.Decimal).Value = salario;
                        comando.ExecuteNonQuery();
                    }
                    // Mostrar un MessageBox informativo después de guardar los cambios
                    MessageBox.Show("Los cambios se guardaron correctamente.", "Guardado exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    // Mostrar un MessageBox de error en caso de excepción
                    MessageBox.Show("Ocurrió un error al guardar los cambios: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        public void insertarEmpleado(string nombre, string documento, int edad, bool esCasado, double salario)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConexion"].ToString()))
                {
                    conexion.Open();
                    string query = @"AltaEmpleado";
                    SqlCommand comando = new SqlCommand(query, conexion);
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.Add("@NombreCompleto", SqlDbType.VarChar).Value = nombre;
                    comando.Parameters.Add("@DNI", SqlDbType.VarChar).Value = documento;
                    comando.Parameters.Add("@Edad", SqlDbType.Int).Value = edad;
                    comando.Parameters.Add("@Casado", SqlDbType.Bit).Value = esCasado;
                    comando.Parameters.Add("@Salario", SqlDbType.Decimal).Value = salario;
                    comando.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                // Mostrar un MessageBox de error en caso de excepción
                MessageBox.Show("Ocurrió un error al insertar el empleado: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void eliminarEmpleado(int id)
        {
            try
            {
                // Mostrar un MessageBox de confirmación al usuario
                DialogResult result = MessageBox.Show("¿Estás seguro de que deseas eliminar este empleado?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    using (SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConexion"].ToString()))
                    {
                        conexion.Open();
                        string query = @"DeleteEmpleado";
                        SqlCommand comando = new SqlCommand(query, conexion);
                        comando.CommandType = CommandType.StoredProcedure;
                        comando.Parameters.Add("@id", SqlDbType.Int).Value = id;
                        comando.ExecuteNonQuery();
                    }
                    // Mostrar un MessageBox informativo después de eliminar el empleado
                    MessageBox.Show("El empleado ha sido eliminado correctamente.", "Eliminación exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                // Mostrar un MessageBox de error en caso de excepción
                MessageBox.Show("Ocurrió un error al eliminar el empleado: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


    }
}


