using Entidades.Indumentaria;
using System;
using System.Windows.Forms;

namespace Cordoba.Rodrigo.PrimerParcial
{
    public partial class FrmAgregar : Form
    {
        private FrmInicio inicio;

        public FrmAgregar(FrmInicio inicio)
        {
            InitializeComponent();
            this.inicio = inicio;
            this.FormClosed += FrmAgregar_FormClosed;
            cmbMaterial.Items.AddRange(Enum.GetNames(typeof(EMaterial)));
        }

        private void FrmAgregar_FormClosed(object sender, FormClosedEventArgs e)
        {
            inicio.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int cantidad;
            if (int.TryParse(textBoxCantidad.Text, out cantidad))
            {
                if (cmbMaterial.SelectedItem != null && Enum.TryParse(cmbMaterial.SelectedItem.ToString(), out EMaterial material))
                {
                    Indumentaria prenda = null;
                    if (rdbRemera.Checked)
                    {
                        prenda = new Remera(cantidad, material);
                    }
                    else if (radioButton1.Checked) // Cambia 'radioButton1' por el nombre correcto
                    {
                        prenda = new Pantalon(cantidad, material);
                    }
                    else if (rdbCampera.Checked)
                    {
                        prenda = new Campera(cantidad, material);
                    }

                    if (prenda != null)
                    {
                        inicio.AgregarPrenda(prenda); // Llama al método de instancia
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
                MessageBox.Show("Ingrese una cantidad válida.");
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
    }
}
