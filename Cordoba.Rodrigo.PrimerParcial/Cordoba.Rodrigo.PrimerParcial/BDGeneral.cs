using System;
using System.Data.SqlClient;

namespace Cordoba.Rodrigo.PrimerParcial
{
    /// <summary>
    /// Clase que proporciona métodos para gestionar la conexión a la base de datos.
    /// </summary>
    public class BDGeneral
    {
        /// <summary>
        /// Obtiene una conexión abierta a la base de datos.
        /// </summary>
        /// <returns>Una instancia de <see cref="SqlConnection"/> con la conexión abierta.</returns>
        public static SqlConnection ObtenerConexion()
        {
            SqlConnection conexion = new SqlConnection("Server=rodri\\SQLEXPRESS;Database=BDindumentaria;User Id=sa;Password=rodri;");
            conexion.Open();
            return conexion;
        }

        /// <summary>
        /// Prueba la conexión a la base de datos.
        /// </summary>
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
