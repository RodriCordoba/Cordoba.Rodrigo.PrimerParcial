using Entidades.Indumentaria;
using System;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace Cordoba.Rodrigo.PrimerParcial
{
    /// <summary>
    /// Clase que representa el formulario para modificar una prenda.
    /// </summary>
    public partial class FrmModificar : frmBaseIndumentaria
    {
        private FrmInicio inicio;
        private Indumentaria prendaSeleccionada;

        /// <summary>
        /// Constructor de la clase FrmModificar.
        /// </summary>
        /// <param name="inicio">Instancia del formulario de inicio.</param>
        /// <param name="prenda">Prenda a modificar.</param>
        public FrmModificar(FrmInicio inicio, Indumentaria prenda)
        {
            InitializeComponent();
            this.inicio = inicio;
            this.prendaSeleccionada = prenda;
            this.FormClosed += FrmModificar_FormClosed;

            cmbMaterial.DataSource = Enum.GetValues(typeof(EMaterial));
            cmbMaterial.SelectedItem = prenda.TipoMaterial;

            textBox2.Text = prenda.Cantidad.ToString();
            textBoxCodigo.Text = prenda.Codigo;

            ConfigurarControlesEspecificos(prenda);
            DesmarcarRadioButton();
        }

        /// <summary>
        /// Desmarca todos los botones de radio.
        /// </summary>
        private void DesmarcarRadioButton()
        {
            rdbCapucha.Checked = false;
            rdbBermuda.Checked = false;
            rdbEstampado.Checked = false;
        }

        /// <summary>
        /// Método invocado cuando se cierra el formulario.
        /// </summary>
        /// <param name="sender">Objeto que generó el evento.</param>
        /// <param name="e">Argumentos del evento.</param>
        private void FrmModificar_FormClosed(object sender, FormClosedEventArgs e)
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
            try
            {
                string nuevoCodigo = textBoxCodigo.Text;

                if (inicio.ListaIndumentaria.Any(p => p.Codigo == nuevoCodigo && p != prendaSeleccionada))
                {
                    throw new Inventario<Indumentaria>.CodigoDuplicadoException("Ya existe una prenda con ese código.");
                }

                prendaSeleccionada.SetCantidad(int.Parse(textBox2.Text));
                prendaSeleccionada.SetTipoMaterial((EMaterial)cmbMaterial.SelectedItem);
                prendaSeleccionada.SetCodigo(nuevoCodigo);

                GuardarValoresEspecificos();

                int resultado = ModificarIndumentaria(prendaSeleccionada);
                if (resultado > 0)
                {
                    inicio.ActualizarPrenda(prendaSeleccionada);
                    MessageBox.Show("Prenda modificada con éxito.");
                }
                else
                {
                    MessageBox.Show("No se pudo modificar la prenda en la base de datos.");
                }

                this.Close();
                inicio.Show();
            }
            catch (Inventario<Indumentaria>.CodigoDuplicadoException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error: {ex.Message}");
            }
        }

        /// <summary>
        /// Configura los controles específicos de la prenda seleccionada.
        /// </summary>
        /// <param name="prenda">Prenda a configurar.</param>
        private void ConfigurarControlesEspecificos(Indumentaria prenda)
        {
            rdbCapucha.Visible = false;
            rdbBermuda.Visible = false;
            rdbEstampado.Visible = false;

            if (prenda is Campera)
            {
                rdbCapucha.Visible = true;
                rdbCapucha.Checked = ((Campera)prenda).TieneCapucha;
            }
            else if (prenda is Pantalon)
            {
                rdbBermuda.Visible = true;
                rdbBermuda.Checked = ((Pantalon)prenda).EsBermuda;
            }
            else if (prenda is Remera)
            {
                rdbEstampado.Visible = true;
                rdbEstampado.Checked = ((Remera)prenda).TieneEstampado;
            }
        }

        /// <summary>
        /// Guarda los valores específicos de la prenda seleccionada.
        /// </summary>
        private void GuardarValoresEspecificos()
        {
            if (prendaSeleccionada is Campera)
            {
                ((Campera)prendaSeleccionada).TieneCapucha = rdbCapucha.Checked;
            }
            else if (prendaSeleccionada is Pantalon)
            {
                ((Pantalon)prendaSeleccionada).EsBermuda = rdbBermuda.Checked;
            }
            else if (prendaSeleccionada is Remera)
            {
                ((Remera)prendaSeleccionada).TieneEstampado = rdbEstampado.Checked;
            }
        }

        /// <summary>
        /// Método estático para modificar una prenda en la base de datos.
        /// </summary>
        /// <param name="indumentaria">Prenda a modificar.</param>
        /// <returns>Número de filas afectadas.</returns>
        public static int ModificarIndumentaria(Indumentaria indumentaria)
        {
            int resultado = 0;
            using (SqlConnection conexion = BDGeneral.ObtenerConexion())
            {
                string query = "UPDATE Indumentaria SET Codigo = @codigo, Cantidad = @cantidad, TipoMaterial = @tipoMaterial, CaracteristicaPropia = @caracteristicaPropia WHERE Codigo = @codigoOriginal";
                SqlCommand comando = new SqlCommand(query, conexion);

                comando.Parameters.AddWithValue("@codigo", indumentaria.Codigo);
                comando.Parameters.AddWithValue("@cantidad", indumentaria.Cantidad);
                comando.Parameters.AddWithValue("@tipoMaterial", indumentaria.TipoMaterial.ToString());

                if (indumentaria is Campera)
                {
                    comando.Parameters.AddWithValue("@caracteristicaPropia", ((Campera)indumentaria).TieneCapucha);
                }
                else if (indumentaria is Pantalon)
                {
                    comando.Parameters.AddWithValue("@caracteristicaPropia", ((Pantalon)indumentaria).EsBermuda);
                }
                else if (indumentaria is Remera)
                {
                    comando.Parameters.AddWithValue("@caracteristicaPropia", ((Remera)indumentaria).TieneEstampado);
                }

                comando.Parameters.AddWithValue("@codigoOriginal", indumentaria.Codigo);

                resultado = comando.ExecuteNonQuery();
                conexion.Close();
            }
            return resultado;
        }

        private void RadioButton_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
        }

        private void cmbMaterial_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
    }
}
