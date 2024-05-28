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
    public partial class FrmEliminar : Form
    {
        private FrmInicio inicio;
        public bool Confirmado { get; private set; }
        public FrmEliminar(FrmInicio inicio, string elemento)
        {
            InitializeComponent();
            this.inicio = inicio;
            this.FormClosed += FrmAgregar_FormClosed;
            Confirmado = false;
            lblConfirmar.Text = $"¿Esta seguro que desea eliminar la prenda seleccionada? \n{elemento}";
        }
        private void FrmAgregar_FormClosed(object sender, FormClosedEventArgs e)
        {
            inicio.Show();
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Confirmado = false;
            this.Close();
            inicio.Show();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Confirmado = true;
            this.Close();
        }
    }
}
