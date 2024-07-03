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
    /// Representa un formulario para la indumentaria base.
    /// </summary>
    public partial class frmBaseIndumentaria : Form
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="frmBaseIndumentaria"/>.
        /// </summary>
        public frmBaseIndumentaria()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Maneja el evento de clic en el botón Aceptar.
        /// </summary>
        /// <param name="sender">El origen del evento.</param>
        /// <param name="e">Datos del evento.</param>
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            // Agregar lógica para lo que sucede cuando se hace clic en el botón Aceptar.
        }

        /// <summary>
        /// Maneja el evento de clic en el botón Cancelar.
        /// </summary>
        /// <param name="sender">El origen del evento.</param>
        /// <param name="e">Datos del evento.</param>
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
