using Entidades.Indumentaria;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Cordoba.Rodrigo.PrimerParcial
{
    /// <summary>
    /// Delegado para el evento cuando se actualiza la hora.
    /// </summary>
    /// <param name="sender">El origen del evento.</param>
    /// <param name="horaActualizada">La hora actualizada como una cadena.</param>
    public delegate void HoraActualizadaEventHandler(object sender, string horaActualizada);

    /// <summary>
    /// Clase principal del formulario para la aplicación.
    /// </summary>
    public partial class FrmInicio : Form
    {
        /// <summary>
        /// Evento que se dispara cuando se actualiza la hora.
        /// </summary>
        public event HoraActualizadaEventHandler HoraActualizada;

        /// <summary>
        /// Lista de prendas de vestir.
        /// </summary>
        private List<Indumentaria> listaIndumentaria;

        /// <summary>
        /// Temporizador para actualizar la hora actual.
        /// </summary>
        private System.Windows.Forms.Timer timer;

        /// <summary>
        /// Obtiene la lista de prendas de vestir.
        /// </summary>
        public List<Indumentaria> ListaIndumentaria
        {
            get { return listaIndumentaria; }
        }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="FrmInicio"/>.
        /// </summary>
        /// <param name="nombreOperador">Nombre del operador.</param>
        /// <param name="puesto">Puesto del operador.</param>
        public FrmInicio(string nombreOperador, string puesto)
        {
            InitializeComponent();
            this.IsMdiContainer = true;
            FrmInicio_Load();
            labelOperador.Text = "Operador: " + nombreOperador + " Puesto: " + puesto;

            if (puesto == "supervisor")
            {
                btnEliminar.Enabled = false;
                btnEliminar.Hide();
            }
            else if (puesto == "vendedor")
            {
                btnEliminar.Enabled = false;
                btnEliminar.Hide();
                button2.Enabled = false;
                button2.Hide();
                button1.Enabled = false;
                button1.Hide();
            }

            listaIndumentaria = new List<Indumentaria>();
            ActualizarListaDesdeDB();
            InicializarReloj();
        }

        /// <summary>
        /// Carga la configuración inicial del formulario.
        /// </summary>
        private void FrmInicio_Load()
        {
            string fechaActual = DateTime.Today.ToString("dd/MM/yyyy");
            labelFecha.Text = "Fecha: " + fechaActual;
        }

        /// <summary>
        /// Inicializa el reloj para actualizar la hora actual.
        /// </summary>
        private void InicializarReloj()
        {
            ToolStripStatusLabel toolStripStatusLblHora = new ToolStripStatusLabel();
            statusStrip1.Items.Add(toolStripStatusLblHora);

            timer = new System.Windows.Forms.Timer();
            timer.Interval = 1000;

            timer.Tick += (sender, e) =>
            {
                string horaActual = DateTime.Now.ToString("HH:mm:ss");
                OnHoraActualizada(horaActual);
            };

            HoraActualizada += (sender, horaActualizada) =>
            {
                toolStripStatusLblHora.Text = horaActualizada;
            };

            timer.Start();
        }

        /// <summary>
        /// Dispara el evento HoraActualizada.
        /// </summary>
        /// <param name="horaActualizada">La hora actualizada como una cadena.</param>
        protected virtual void OnHoraActualizada(string horaActualizada)
        {
            HoraActualizada?.Invoke(this, horaActualizada);
        }

        /// <summary>
        /// Maneja el evento de clic para modificar una prenda de vestir.
        /// </summary>
        /// <param name="sender">El origen del evento.</param>
        /// <param name="e">Datos del evento.</param>
        private void button2_Click(object sender, EventArgs e)
        {
            if (listInd.SelectedItem != null)
            {
                Indumentaria prendaSeleccionada = (Indumentaria)listInd.SelectedItem;
                FrmModificar modificar = new FrmModificar(this, prendaSeleccionada);
                modificar.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Seleccione una prenda para modificar.");
            }
        }

        /// <summary>
        /// Maneja el evento de clic para cerrar la sesión.
        /// </summary>
        /// <param name="sender">El origen del evento.</param>
        /// <param name="e">Datos del evento.</param>
        private void cerrarSesionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmLogin sesion = new FrmLogin();
            sesion.Show();
            this.Close();
        }

        /// <summary>
        /// Maneja el evento de clic para cerrar el programa.
        /// </summary>
        /// <param name="sender">El origen del evento.</param>
        /// <param name="e">Datos del evento.</param>
        private void cerrarProgramaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// Maneja el evento de clic para agregar una nueva prenda de vestir.
        /// </summary>
        /// <param name="sender">El origen del evento.</param>
        /// <param name="e">Datos del evento.</param>
        private void button1_Click(object sender, EventArgs e)
        {
            FrmAgregar agregar = new FrmAgregar(this);
            agregar.Show();
            this.Hide();
        }

        /// <summary>
        /// Maneja el evento de clic para eliminar una prenda de vestir.
        /// </summary>
        /// <param name="sender">El origen del evento.</param>
        /// <param name="e">Datos del evento.</param>
        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            if (listInd.SelectedItem != null)
            {
                Indumentaria prendaSeleccionada = (Indumentaria)listInd.SelectedItem;
                string descripcionPrenda = prendaSeleccionada.ToString();

                FrmEliminar frmEliminar = new FrmEliminar(this, descripcionPrenda);
                frmEliminar.ShowDialog();

                if (frmEliminar.Confirmado)
                {
                    pbrTask.Value = 0;
                    pbrTask.Visible = true;

                    await Task.Run(() =>
                    {
                        for (int i = 0; i <= 100; i++)
                        {
                            Task.Delay(50).Wait();
                            Invoke(new Action(() => pbrTask.Value = i));
                        }

                        int resultado = FrmEliminar.EliminarIndumentariaPorCodigo(prendaSeleccionada.Codigo);
                        if (resultado > 0)
                        {
                            Invoke(new Action(() =>
                            {
                                listaIndumentaria.Remove(prendaSeleccionada);
                                ActualizarLista();
                                MessageBox.Show("Prenda eliminada con éxito.");
                            }));
                        }
                        else
                        {
                            Invoke(new Action(() =>
                            {
                                MessageBox.Show("Error al eliminar la prenda de la base de datos.");
                            }));
                        }
                    });

                    pbrTask.Visible = false;
                }
            }
            else
            {
                MessageBox.Show("Seleccione una prenda para eliminar.");
            }
        }

        /// <summary>
        /// Agrega una nueva prenda de vestir a la lista.
        /// </summary>
        /// <param name="prenda">La prenda de vestir a agregar.</param>
        public void AgregarPrenda(Indumentaria prenda)
        {
            listaIndumentaria.Add(prenda);
            ActualizarLista();
        }

        /// <summary>
        /// Actualiza una prenda de vestir en la lista.
        /// </summary>
        /// <param name="prenda">La prenda de vestir a actualizar.</param>
        public void ActualizarPrenda(Indumentaria prenda)
        {
            for (int i = 0; i < listaIndumentaria.Count; i++)
            {
                if (listaIndumentaria[i].Codigo == prenda.Codigo)
                {
                    listaIndumentaria[i] = prenda;
                    break;
                }
            }
            int resultado = FrmModificar.ModificarIndumentaria(prenda);
            if (resultado > 0)
            {
                MessageBox.Show("Prenda actualizada con éxito.");
            }
            else
            {
                MessageBox.Show("No se pudo actualizar la prenda en la base de datos.");
            }
            ActualizarLista();
        }

        /// <summary>
        /// Actualiza la visualización de la lista.
        /// </summary>
        private void ActualizarLista()
        {
            listInd.DataSource = null;
            listInd.DataSource = listaIndumentaria;
        }

        /// <summary>
        /// Carga las prendas de vestir desde la base de datos.
        /// </summary>
        private void ActualizarListaDesdeDB()
        {
            listaIndumentaria = FrmAgregar.PresentarRegistro();
            ActualizarLista();
        }

        /// <summary>
        /// Maneja el evento de clic para ordenar la lista por tipo.
        /// </summary>
        /// <param name="sender">El origen del evento.</param>
        /// <param name="e">Datos del evento.</param>
        private void ordenarListaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listaIndumentaria = listaIndumentaria.OrderBy(prenda =>
            {
                if (prenda is Pantalon) return "Pantalon";
                if (prenda is Campera) return "Campera";
                if (prenda is Remera) return "Remera";
                return string.Empty;
            }).ToList();
            ActualizarLista();
        }

        /// <summary>
        /// Maneja el evento de clic para ordenar la lista por cantidad en orden ascendente.
        /// </summary>
        /// <param name="sender">El origen del evento.</param>
        /// <param name="e">Datos del evento.</param>
        private void ordenarPorCantidadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listaIndumentaria = listaIndumentaria
                .OrderBy(prenda => prenda.Cantidad)
                .ToList();

            ActualizarLista();
        }

        /// <summary>
        /// Maneja el evento de clic para ordenar la lista por cantidad en orden descendente.
        /// </summary>
        /// <param name="sender">El origen del evento.</param>
        /// <param name="e">Datos del evento.</param>
        private void ordenarPorCantidadDescendenteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listaIndumentaria = listaIndumentaria
                .OrderByDescending(prenda => prenda.Cantidad)
                .ToList();

            ActualizarLista();
        }

        /// <summary>
        /// Maneja el evento de clic para guardar la lista en un archivo XML.
        /// </summary>
        /// <param name="sender">El origen del evento.</param>
        /// <param name="e">Datos del evento.</param>
        private void xMLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string filePath = "indumentaria.xml";
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<Indumentaria>));
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    serializer.Serialize(writer, listaIndumentaria);
                }
                MessageBox.Show("Datos guardados exitosamente en XML.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar datos en XML: " + ex.Message);
            }
        }

        /// <summary>
        /// Maneja el evento de clic para guardar la lista en un archivo JSON.
        /// </summary>
        /// <param name="sender">El origen del evento.</param>
        /// <param name="e">Datos del evento.</param>
        private void jSONToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string filePath = "indumentaria.json";
            try
            {
                string jsonString = JsonSerializer.Serialize(listaIndumentaria);
                File.WriteAllText(filePath, jsonString);
                MessageBox.Show("Datos guardados exitosamente en JSON.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar datos en JSON: " + ex.Message);
            }
        }

        /// <summary>
        /// Maneja el evento de clic para cargar la lista desde un archivo XML.
        /// </summary>
        /// <param name="sender">El origen del evento.</param>
        /// <param name="e">Datos del evento.</param>
        private void cargarXMLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string filePath = "indumentaria.xml";
            try
            {
                if (File.Exists(filePath))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(List<Indumentaria>));
                    using (StreamReader reader = new StreamReader(filePath))
                    {
                        listaIndumentaria = (List<Indumentaria>)serializer.Deserialize(reader);
                    }
                    ActualizarLista();
                    MessageBox.Show("Datos cargados exitosamente desde XML.");
                }
                else
                {
                    MessageBox.Show("El archivo XML no existe.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar datos desde XML: " + ex.Message);
            }
        }

        /// <summary>
        /// Maneja el evento de clic para cargar la lista desde un archivo JSON.
        /// </summary>
        /// <param name="sender">El origen del evento.</param>
        /// <param name="e">Datos del evento.</param>
        private void cargarJSONToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string filePath = "indumentaria.json";
            try
            {
                if (File.Exists(filePath))
                {
                    string jsonString = File.ReadAllText(filePath);
                    var options = new JsonSerializerOptions();
                    options.Converters.Add(new IndumentariaConvertidor());
                    listaIndumentaria = JsonSerializer.Deserialize<List<Indumentaria>>(jsonString, options);
                    ActualizarLista();
                    MessageBox.Show("Datos cargados exitosamente desde JSON.");
                }
                else
                {
                    MessageBox.Show("El archivo JSON no existe.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar datos desde JSON: " + ex.Message);
            }
        }

        /// <summary>
        /// Maneja el evento de clic para el elemento del status strip.
        /// </summary>
        /// <param name="sender">El origen del evento.</param>
        /// <param name="e">Datos del evento.</param>
        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
        }

        /// <summary>
        /// Maneja el evento de clic para la etiqueta de fecha.
        /// </summary>
        /// <param name="sender">El origen del evento.</param>
        /// <param name="e">Datos del evento.</param>
        private void labelFecha_Click(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// Maneja el evento de clic para la etiqueta del operador.
        /// </summary>
        /// <param name="sender">El origen del evento.</param>
        /// <param name="e">Datos del evento.</param>
        private void labelOperador_Click(object sender, EventArgs e)
        {
        }
    }
}
