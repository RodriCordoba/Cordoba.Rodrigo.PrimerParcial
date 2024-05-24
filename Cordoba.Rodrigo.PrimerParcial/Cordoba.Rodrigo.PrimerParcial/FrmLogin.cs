using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Windows.Forms;

namespace Cordoba.Rodrigo.PrimerParcial
{
    public partial class FrmLogin : Form
    {
        private List<Empleado> empleados;

        public FrmLogin()
        {
            InitializeComponent();
            CargarEmpleadosDesdeJSON();
        }

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

        private void button1_Click(object sender, EventArgs e)
        {
            string correo = txtUsuario.Text;
            string contraseña = txtContraseña.Text;

            bool credencialesValidas = false;
            foreach (Empleado empleado in empleados)
            {
                if (string.Equals(empleado.Correo, correo, StringComparison.OrdinalIgnoreCase) &&
                    string.Equals(empleado.Clave, contraseña))
                {
                    credencialesValidas = true;
                    break;
                }
            }

            if (credencialesValidas)
            {
                string nombreOperador = empleados.Find(emp => emp.Correo.Equals(correo, StringComparison.OrdinalIgnoreCase)).Nombre;
                MessageBox.Show("Inicio de sesión exitoso!");
                FrmInicio formInicio = new FrmInicio(nombreOperador);
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
