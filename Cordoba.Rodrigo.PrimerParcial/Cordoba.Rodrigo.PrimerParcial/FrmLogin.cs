using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Windows.Forms;

namespace Cordoba.Rodrigo.PrimerParcial
{
    /// <summary>
    /// Clase que representa el formulario de inicio de sesi�n.
    /// </summary>
    public partial class FrmLogin : Form
    {
        private List<Empleado> empleados;
        /// <summary>
        /// Constructor de la clase FrmLogin.
        /// </summary>
        public FrmLogin()
        {
            InitializeComponent();
            CargarEmpleadosDesdeJSON();
        }
        /// <summary>
        /// Carga los empleados desde un archivo JSON.
        /// </summary>
        private void CargarEmpleadosDesdeJSON()
        {
            try
            {
                string rutaArchivo = @"MOCK_DATA.json";
                if (File.Exists(rutaArchivo))
                {
                    string json = File.ReadAllText(rutaArchivo);
                    empleados = JsonSerializer.Deserialize<List<Empleado>>(json);
                }
                else
                {
                    MessageBox.Show("El archivo JSON no existe en la ruta especificada.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los empleados desde el archivo JSON: " + ex.Message);
            }
        }
        /// <summary>
        /// M�todo invocado al hacer clic en el bot�n de inicio de sesi�n.
        /// </summary>
        /// <param name="sender">Objeto que gener� el evento.</param>
        /// <param name="e">Argumentos del evento.</param>
        private void button1_Click(object sender, EventArgs e)
        {
            string correo = txtUsuario.Text;
            string contrase�a = txtContrase�a.Text;

            bool credencialesValidas = false;
            foreach (Empleado empleado in empleados)
            {
                if (string.Equals(empleado.Correo, correo, StringComparison.OrdinalIgnoreCase) &&
                    string.Equals(empleado.Clave, contrase�a))
                {
                    credencialesValidas = true;
                    break;
                }
            }

            if (credencialesValidas)
            {
                string nombreOperador = empleados.Find(emp => emp.Correo.Equals(correo, StringComparison.OrdinalIgnoreCase)).Nombre;
                string puesto = empleados.Find(emp => emp.Correo.Equals(correo, StringComparison.OrdinalIgnoreCase)).Perfil;
                MessageBox.Show("Inicio de sesi�n exitoso!");
                FrmInicio formInicio = new FrmInicio(nombreOperador, puesto);
                formInicio.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Correo electr�nico o contrase�a incorrectos. Por favor, intente nuevamente.");
            }
        }

    }
}
