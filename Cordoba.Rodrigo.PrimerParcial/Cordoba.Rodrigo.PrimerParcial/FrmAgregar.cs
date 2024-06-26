using Entidades.Indumentaria;
using System;
using System.Data.SqlClient;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;

namespace Cordoba.Rodrigo.PrimerParcial
{
    public partial class FrmAgregar : frmBaseIndumentaria
    {
        private FrmInicio inicio;

        public FrmAgregar(FrmInicio inicio)
        {
            InitializeComponent();
            this.inicio = inicio;
            this.FormClosed += FrmAgregar_FormClosed;
            cmbMaterial.Items.AddRange(Enum.GetNames(typeof(EMaterial)));

            rdbCapucha.Visible = false;
            rdbBermuda.Visible = false;
            rdbEstampado.Visible = false;

            rdbCampera.CheckedChanged += RadioButton_CheckedChanged;
            radioButton1.CheckedChanged += RadioButton_CheckedChanged;
            rdbRemera.CheckedChanged += RadioButton_CheckedChanged;
        }

        public static int AgregarIndumentaria(Indumentaria indumentaria)
        {
            int retorno = 0;

            using (SqlConnection conexion = BDGeneral.ObtenerConexion())
            {
                string query = "insert into Indumentaria (codigo, cantidad, tipoMaterial, caracteristicaPropia, Prenda) values()";
                SqlCommand comando = new SqlCommand();

            }
            return retorno;
        }
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            int cantidad;
            string codigo;


            if (int.TryParse(textBoxCantidad.Text, out cantidad) && !string.IsNullOrEmpty(txtCodigo.Text))
            {
                codigo = txtCodigo.Text;

                EMaterial material;
                if (Enum.TryParse(cmbMaterial.SelectedItem.ToString(), out material))
                {
                    Indumentaria prenda = null;
                    if (rdbRemera.Checked)
                    {
                        prenda = new Remera(codigo, cantidad, material, rdbEstampado.Checked);
                    }
                    else if (radioButton1.Checked)
                    {
                        prenda = new Pantalon(codigo, cantidad, material, rdbBermuda.Checked);
                    }
                    else if (rdbCampera.Checked)
                    {
                        prenda = new Campera(codigo, cantidad, material, rdbCapucha.Checked);
                    }

                    if (prenda != null)
                    {
                        inicio.AgregarPrenda(prenda);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Seleccione un tipo de prenda.");
                    }
                }
                else
                {
                    MessageBox.Show("Seleccione un material válido.");
                }
            }
            else
            {
                MessageBox.Show("Ingrese una cantidad válida y un código no vacío.");
            }
        }

        private void FrmAgregar_FormClosed(object sender, FormClosedEventArgs e)
        {
            inicio.Show();
        }

        private void RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbCampera.Checked)
            {
                rdbCapucha.Visible = true;
                rdbBermuda.Visible = false;
                rdbEstampado.Visible = false;
            }
            else if (radioButton1.Checked)
            {
                rdbCapucha.Visible = false;
                rdbBermuda.Visible = true;
                rdbEstampado.Visible = false;
            }
            else if (rdbRemera.Checked)
            {
                rdbCapucha.Visible = false;
                rdbBermuda.Visible = false;
                rdbEstampado.Visible = true;
            }
            else
            {
                rdbCapucha.Visible = false;
                rdbBermuda.Visible = false;
                rdbEstampado.Visible = false;
            }
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
            inicio.Show();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void FrmAgregar_Load(object sender, EventArgs e)
        {
        }
    }
}
