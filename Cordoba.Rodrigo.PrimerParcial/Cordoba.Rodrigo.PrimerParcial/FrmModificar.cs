using Entidades.Indumentaria;
using System;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace Cordoba.Rodrigo.PrimerParcial
{
    public partial class FrmModificar : frmBaseIndumentaria
    {
        private FrmInicio inicio;
        private Indumentaria prendaSeleccionada;

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

        private void DesmarcarRadioButton()
        {
            rdbCapucha.Checked = false;
            rdbBermuda.Checked = false;
            rdbEstampado.Checked = false;
        }

        private void FrmModificar_FormClosed(object sender, FormClosedEventArgs e)
        {
            inicio.Show();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
            inicio.Show();
        }

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
