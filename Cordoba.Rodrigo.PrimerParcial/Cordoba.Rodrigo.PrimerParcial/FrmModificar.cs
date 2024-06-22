using Entidades.Indumentaria;
using System;
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
            prendaSeleccionada.SetCantidad(int.Parse(textBox2.Text));
            prendaSeleccionada.SetTipoMaterial((EMaterial)cmbMaterial.SelectedItem);
            prendaSeleccionada.SetCodigo(textBoxCodigo.Text);

            GuardarValoresEspecificos();

            inicio.ActualizarPrenda(prendaSeleccionada);

            this.Close();
            inicio.Show();
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
