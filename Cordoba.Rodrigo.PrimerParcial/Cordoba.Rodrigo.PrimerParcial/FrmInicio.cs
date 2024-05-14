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
    public partial class FrmInicio : Form
    {
        private string nombreOperador;
        public FrmInicio(string nombreOperador)
        {
            InitializeComponent();
            FrmInicio_Load(null, EventArgs.Empty);
            this.nombreOperador = nombreOperador;
            labelOperador.Text = "Operador: " + nombreOperador;
        }

        private void FrmInicio_Load(object sender, EventArgs e)
        {
            string nombreOperador = "Nombre del Operador";
            labelOperador.Text = "Operador: " + nombreOperador;

            MessageBox.Show("Nombre del operador: " + nombreOperador);

            string fechaActual = DateTime.Today.ToString("dd/MM/yyyy");
            labelFecha.Text = "Fecha: " + fechaActual;

            MessageBox.Show("Fecha actual: " + fechaActual);
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
