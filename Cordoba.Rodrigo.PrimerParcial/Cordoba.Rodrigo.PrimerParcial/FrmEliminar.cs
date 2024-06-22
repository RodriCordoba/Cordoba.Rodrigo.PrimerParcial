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
    /// Clase que representa el formulario de confirmación de eliminación de una prenda.
    /// </summary>
    public partial class FrmEliminar : frmBaseIndumentaria
    {
        private FrmInicio inicio;
        /// <summary>
        /// Indica si la eliminación ha sido confirmada.
        /// </summary>
        public bool Confirmado { get; private set; }
        /// <summary>
        /// Constructor de la clase FrmEliminar.
        /// </summary>
        /// <param name="inicio">Instancia del formulario de inicio.</param>
        /// <param name="elemento">Elemento a ser eliminado.</param>
        public FrmEliminar(FrmInicio inicio, string elemento)
        {
            InitializeComponent();
            this.inicio = inicio;
            this.FormClosed += FrmAgregar_FormClosed;
            Confirmado = false;
            lblConfirmar.Text = $"¿Esta seguro que desea eliminar la prenda seleccionada? \n{elemento}";
        }
        /// <summary>
        /// Método invocado cuando se cierra el formulario.
        /// </summary>
        /// <param name="sender">Objeto que generó el evento.</param>
        /// <param name="e">Argumentos del evento.</param>
        private void FrmAgregar_FormClosed(object sender, FormClosedEventArgs e)
        {
            inicio.Show();
        }
        /// <summary>
        /// Método invocado al hacer clic en el botón "Cancelar".
        /// </summary>
        /// <param name="sender">Objeto que generó el evento.</param>
        /// <param name="e">Argumentos del evento.</param>
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Confirmado = false;
            this.Close();
            inicio.Show();
        }
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            Confirmado = true;
            this.Close();
        }
    }
}
