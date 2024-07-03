using Entidades.Indumentaria;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Cordoba.Rodrigo.PrimerParcial
{
    /// <summary>
    /// Clase que representa el formulario de confirmación de eliminación de una prenda.
    /// </summary>
    public partial class FrmEliminar : frmBaseIndumentaria
    {
        private FrmInicio inicio;

        /// <summary>
        /// Indica si la eliminación ha sido confirmada.
        /// </summary>
        public bool Confirmado { get; private set; }

        /// <summary>
        /// Constructor de la clase FrmEliminar.
        /// </summary>
        /// <param name="inicio">Instancia del formulario de inicio.</param>
        /// <param name="elemento">Elemento a ser eliminado.</param>
        public FrmEliminar(FrmInicio inicio, string elemento)
        {
            InitializeComponent();
            this.inicio = inicio;
            this.FormClosed += FrmEliminar_FormClosed;
            Confirmado = false;
            lblConfirmar.Text = $"¿Está seguro que desea eliminar la prenda seleccionada? \n{elemento}";
        }

        /// <summary>
        /// Método invocado cuando se cierra el formulario.
        /// </summary>
        /// <param name="sender">Objeto que generó el evento.</param>
        /// <param name="e">Argumentos del evento.</param>
        private void FrmEliminar_FormClosed(object sender, FormClosedEventArgs e)
        {
            inicio.Show();
        }

        /// <summary>
        /// Método invocado al hacer clic en el botón "Cancelar".
        /// </summary>
        /// <param name="sender">Objeto que generó el evento.</param>
        /// <param name="e">Argumentos del evento.</param>
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Confirmado = false;
            this.Close();
            inicio.Show();
        }

        /// <summary>
        /// Método invocado al hacer clic en el botón "Aceptar".
        /// </summary>
        /// <param name="sender">Objeto que generó el evento.</param>
        /// <param name="e">Argumentos del evento.</param>
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            Confirmado = true;
            this.Close();
        }

        /// <summary>
        /// Método estático para eliminar una prenda de la base de datos.
        /// </summary>
        /// <param name="codigo">Código de la prenda a eliminar.</param>
        /// <returns>Número de filas afectadas.</returns>
        public static int EliminarIndumentariaPorCodigo(string codigo)
        {
            int retorno = 0;

            try
            {
                using (SqlConnection conexion = BDGeneral.ObtenerConexion())
                {
                    string query = "DELETE FROM Indumentaria WHERE Codigo = @codigo";
                    SqlCommand comando = new SqlCommand(query, conexion);
                    comando.Parameters.AddWithValue("@codigo", codigo);

                    retorno = comando.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Error al ejecutar la consulta: {ex.Message}");
                MessageBox.Show($"Error al ejecutar la consulta: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error inesperado: {ex.Message}");
                MessageBox.Show($"Error inesperado: {ex.Message}");
            }

            return retorno;
        }
    }
}
