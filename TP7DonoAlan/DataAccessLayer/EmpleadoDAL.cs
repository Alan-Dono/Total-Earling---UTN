using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmpleadosEntity;
using System.Configuration;
using System.Net;

namespace DataAccessLayer
{
    using System.Data;
    using System.Data.SqlClient;

    public class EmpleadoDAL
    {

        public static List<Empleado> ListarClientes(string NombreApellido)
        {

            List<Empleado> list = new List<Empleado>();

            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConexionEmpleadosDB"].ToString()))
            {
                conn.Open();

                string sql = @"ListarUsuario";

                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = NombreApellido;

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    list.Add(ObtenerCliente(reader));
                }
            }

            return list;


        }

        public static Empleado ObtenerCliente(SqlDataReader reader)
        {
            Empleado cliente = new Empleado();
            cliente.Id = Convert.ToInt32(reader["Id"]);
            cliente.Nombre = Convert.ToString(reader["NombreCompleto"]);
            cliente.Documento = Convert.ToString(reader["DNI"]);
            cliente.Edad = Convert.ToInt32(reader["Edad"]);
            cliente.EstadoCivil = Convert.ToBoolean(reader["Casado"]);
            cliente.Salario = Convert.ToDouble(reader["Salario"]);
            return cliente;
        }
        public static Empleado ABMCliente(Empleado cliente)
        {
            Empleado Cliente = cliente;

            try
            {

                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConexionEmpleadosDB"].ToString()))
                {
                    conn.Open();
                    string sql = string.Empty;
                    /*       if (cliente.Id > 0)
                           {
                               sql = @"MODIFICARCLIENTE";
                           }
                           else*/
                    sql = @"AltaUsuario";


                    SqlCommand cmd = new SqlCommand(sql, conn);

                    cmd.CommandType = CommandType.StoredProcedure;

                    if (cliente.Id > 0)
                    {
                        cmd.Parameters.Add("@Id", SqlDbType.Int).Value = cliente.Id;
                    }
                    cmd.Parameters.Add("@NombreCompleto", SqlDbType.VarChar).Value = cliente.Nombre;
                    cmd.Parameters.Add("@DNI", SqlDbType.VarChar).Value = cliente.Documento;
                    cmd.Parameters.Add("@Edad", SqlDbType.Int).Value = cliente.Edad;
                    cmd.Parameters.Add("@Casado", SqlDbType.Bit).Value = cliente.EstadoCivil;
                    cmd.Parameters.Add("@Salario", SqlDbType.Decimal).Value = cliente.Salario;
                    cmd.ExecuteNonQuery();
                    return Cliente;
                }
            }
            catch (Exception Ex)
            {
                return Cliente;

            }
        }


        public static void DeleteCliente(int id)
        {

            try
            {

                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Cnn"].ToString()))
                {
                    conn.Open();
                    string sql = @"ELIMINARCLIENTE";

                    SqlCommand cmd = new SqlCommand(sql, conn);

                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add("@Id", SqlDbType.Int).Value = id;

                    cmd.ExecuteNonQuery();

                }



            }
            catch (Exception Ex)
            {

            }
        }

        public static List<Empleado> ListarClientes()
        {
            List<Empleado> list = new List<Empleado>();

            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConexionEmpleadosDB"].ToString()))
            {
                conn.Open();
                string sql = @"ListarUsuario";
                                SqlCommand cmd = new SqlCommand(sql, conn);
                           cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(ObtenerCliente(reader));
                }
            }
            return list;
        }
    }
}