using Entidades.Indumentaria;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cordoba.Rodrigo.PrimerParcial
{
    /// <summary>
    /// Clase que representa el formulario para modificar una prenda de indumentaria.
    /// </summary>
    public partial class FrmModificar : Form
    {
        private FrmInicio inicio;
        private Indumentaria prendaSeleccionada;
        /// <summary>
        /// Constructor de la clase FrmModificar.
        /// </summary>
        /// <param name="inicio">Instancia del formulario de inicio.</param>
        /// <param name="prenda">Prenda de indumentaria que se desea modificar.</param>
        public FrmModificar(FrmInicio inicio, Indumentaria prenda)
        {
            InitializeComponent();
            this.inicio = inicio;
            this.prendaSeleccionada = prenda;
            this.FormClosed += FrmAgregar_FormClosed;

            cmbMaterial.DataSource = Enum.GetValues(typeof(EMaterial));
            cmbMaterial.SelectedItem = prenda.TipoMaterial;

            textBox2.Text = prenda.Cantidad.ToString();
            textBoxCodigo.Text = prenda.Codigo;
        }
        private void FrmAgregar_FormClosed(object sender, FormClosedEventArgs e)
        {
            inicio.Show();
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
            inicio.Show();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmbMaterial_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            prendaSeleccionada.SetCantidad(int.Parse(textBox2.Text));
            prendaSeleccionada.SetTipoMaterial((EMaterial)cmbMaterial.SelectedItem);
            prendaSeleccionada.SetCodigo(textBoxCodigo.Text);

            inicio.ActualizarPrenda(prendaSeleccionada);

            this.Close();
            inicio.Show();
        }
    }
}
