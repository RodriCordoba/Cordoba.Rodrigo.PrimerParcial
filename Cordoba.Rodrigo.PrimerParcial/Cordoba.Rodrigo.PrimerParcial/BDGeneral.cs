using System;
using System.Data.SqlClient;

namespace Cordoba.Rodrigo.PrimerParcial
{
    public class BDGeneral
    {
        public static SqlConnection ObtenerConexion()
        {
            SqlConnection conexion = new SqlConnection("Server=rodri\\SQLEXPRESS;Database=BDindumentaria;User Id=sa;Password=rodri;");
            conexion.Open();
            return conexion;
        }

        public static void ProbarConexion()
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection("Server=rodri\\SQLEXPRESS;Database=BDindumentaria;User Id=sa;Password=rodri;"))
                {
                    conexion.Open();
                    Console.WriteLine("Conexión exitosa");
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Error de SQL: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error inesperado: {ex.Message}");
            }
        }
    }
}
