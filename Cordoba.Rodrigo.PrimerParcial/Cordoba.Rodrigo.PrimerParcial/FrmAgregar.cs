using Entidades.Indumentaria;
using System;
using System.Windows.Forms;

namespace Cordoba.Rodrigo.PrimerParcial
{
    /// <summary>
    /// Clase que representa el formulario para agregar una nueva prenda de indumentaria.
    /// </summary>
    public partial class FrmAgregar : Form
    {
        private FrmInicio inicio;

        /// <summary>
        /// Constructor de la clase FrmAgregar.
        /// </summary>
        /// <param name="inicio">Instancia del formulario de inicio.</param>
        public FrmAgregar(FrmInicio inicio)
        {
            InitializeComponent();
            this.inicio = inicio;
            this.FormClosed += FrmAgregar_FormClosed;
            cmbMaterial.Items.AddRange(Enum.GetNames(typeof(EMaterial)));

            rdbCapucha.Visible = false;
            rdbChupin.Visible = false;
            rdbEstampado.Visible = false;

            rdbCampera.CheckedChanged += RadioButton_CheckedChanged;
            radioButton1.CheckedChanged += RadioButton_CheckedChanged;
            rdbRemera.CheckedChanged += RadioButton_CheckedChanged;
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
                rdbChupin.Visible = false;
                rdbEstampado.Visible = false;
            }
            else if (radioButton1.Checked)
            {
                rdbCapucha.Visible = false;
                rdbChupin.Visible = true;
                rdbEstampado.Visible = false;
            }
            else if (rdbRemera.Checked)
            {
                rdbCapucha.Visible = false;
                rdbChupin.Visible = false;
                rdbEstampado.Visible = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
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
                        prenda = new Pantalon(codigo, cantidad, material, rdbChupin.Checked);
                    }
                    else if (rdbCampera.Checked)
                    {
                        prenda = new Campera(codigo, cantidad, material, rdbCampera.Checked);
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
