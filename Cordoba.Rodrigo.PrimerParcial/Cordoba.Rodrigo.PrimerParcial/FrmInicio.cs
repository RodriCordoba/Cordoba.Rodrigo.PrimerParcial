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
            listaIndumentaria = new List<Indumentaria>();
            FrmInicio_Load();
            labelOperador.Text = "Operador: " + nombreOperador;
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
            FrmAgregar agregar = new FrmAgregar(this);
            agregar.Show();
            this.Hide();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            FrmEliminar eliminar = new FrmEliminar(this);
            eliminar.Show();
            this.Hide();
        }

        public void AgregarPrenda(Indumentaria prenda)
        {
            listaIndumentaria.Add(prenda);
            listInd.Items.Add(prenda.ToString());
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
