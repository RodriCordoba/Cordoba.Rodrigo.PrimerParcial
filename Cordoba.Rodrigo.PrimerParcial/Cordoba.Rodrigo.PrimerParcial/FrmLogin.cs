using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Windows.Forms;

namespace Cordoba.Rodrigo.PrimerParcial
{
    /// <summary>
    /// Clase que representa el formulario de inicio de sesión.
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
                    empleados = new List<Empleado>();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los empleados desde el archivo JSON: " + ex.Message);
                empleados = new List<Empleado>();
            }
        }

        /// <summary>
        /// Método invocado al hacer clic en el botón de inicio de sesión.
        /// </summary>
        /// <param name="sender">Objeto que generó el evento.</param>
        /// <param name="e">Argumentos del evento.</param>
        private void button1_Click(object sender, EventArgs e)
        {
            string correo = txtUsuario.Text;
            string contraseña = txtContraseña.Text;

            bool credencialesValidas = false;
            Empleado empleadoValido = null;
            foreach (Empleado empleado in empleados)
            {
                if (string.Equals(empleado.Correo, correo, StringComparison.OrdinalIgnoreCase) &&
                    string.Equals(empleado.Clave, contraseña))
                {
                    credencialesValidas = true;
                    empleadoValido = empleado;
                    break;
                }
            }

            if (credencialesValidas)
            {
                string nombreOperador = empleadoValido.Nombre;
                string puesto = empleadoValido.Perfil;
                MessageBox.Show("Inicio de sesión exitoso!");
                FrmInicio formInicio = new FrmInicio(nombreOperador, puesto);
                formInicio.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Correo electrónico o contraseña incorrectos. Por favor, intente nuevamente.");
            }
        }
    }
}
