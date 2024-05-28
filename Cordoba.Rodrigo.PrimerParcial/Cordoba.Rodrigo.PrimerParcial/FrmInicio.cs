using Entidades.Indumentaria;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Cordoba.Rodrigo.PrimerParcial
{
    public partial class FrmInicio : Form
    {
        private List<Indumentaria> listaIndumentaria;

        public FrmInicio(string nombreOperador)
        {
            InitializeComponent();
            this.IsMdiContainer = true;
            FrmInicio_Load();
            labelOperador.Text = "Operador: " + nombreOperador;
            listaIndumentaria = new List<Indumentaria>();
        }

        private void FrmInicio_Load()
        {
            string fechaActual = DateTime.Today.ToString("dd/MM/yyyy");
            labelFecha.Text = "Fecha: " + fechaActual;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmModificar modificar = new FrmModificar(this);
            modificar.Show();
            this.Hide();
        }

        private void cerrarSesionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmLogin sesion = new FrmLogin();
            sesion.Show();
            this.Close();
        }

        private void cerrarProgramaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ActualizarLista();
            FrmAgregar agregar = new FrmAgregar(this);
            agregar.Show();
            this.Hide();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (listInd.SelectedItem != null)
            {
                Indumentaria prendaSeleccionada = (Indumentaria)listInd.SelectedItem;
                string descripcionPrenda = prendaSeleccionada.ToString();

                ActualizarLista();

                FrmEliminar frmEliminar = new FrmEliminar(this, descripcionPrenda);
                frmEliminar.ShowDialog();

                if (frmEliminar.Confirmado)
                {
                    listaIndumentaria.Remove(prendaSeleccionada);
                    ActualizarLista();
                    MessageBox.Show("Prenda eliminada con éxito.");
                }
            }
            else
            {
                MessageBox.Show("Seleccione una prenda para eliminar.");
            }
        }

        public void AgregarPrenda(Indumentaria prenda)
        {

            listaIndumentaria.Add(prenda);
            ActualizarLista();
        }
        private void ActualizarLista()
        {
            listInd.DataSource = null;
            listInd.DataSource = listaIndumentaria;
        }
        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
        private void labelFecha_Click(object sender, EventArgs e)
        {

        }
        private void labelOperador_Click(object sender, EventArgs e)
        {

        }
    }
}

