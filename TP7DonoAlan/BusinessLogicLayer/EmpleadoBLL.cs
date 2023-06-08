using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using EmpleadosEntity;

namespace BusinessLogicLayer
{
    public class EmpleadoBLL
    {
        public static List<Empleado> ListarClientes()
        {
            return EmpleadoDAL.ListarClientes();
        }

        public static Empleado ABMCliente(Empleado user)
        {
            return EmpleadoDAL.ABMCliente(user);
        }
       
    }
}
