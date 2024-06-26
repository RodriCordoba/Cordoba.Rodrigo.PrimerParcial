using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Cordoba.Rodrigo.PrimerParcial
{
    public class BDGeneral
    {
        public static SqlConnection ObtenerConexion()
        {
            SqlConnection conexion = new SqlConnection("Persist Security Info=False;User ID=sa;Initial Catalog=BDindumentaria;Data Source=rodri\\SQLEXPRESS\r\n");
            conexion.Open();

            return conexion;
        }
    }
}
