﻿using Entidades.Indumentaria;
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
    public delegate void HoraActualizadaEventHandler(object sender, string horaActualizada);
    public partial class FrmInicio : Form
    {
        public event HoraActualizadaEventHandler HoraActualizada;
        private List<Indumentaria> listaIndumentaria;
        private System.Windows.Forms.Timer timer;

        public List<Indumentaria> ListaIndumentaria
        {
            get { return listaIndumentaria; }
        }

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

        private void FrmInicio_Load()
        {
            string fechaActual = DateTime.Today.ToString("dd/MM/yyyy");
            labelFecha.Text = "Fecha: " + fechaActual;
        }

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
        protected virtual void OnHoraActualizada(string horaActualizada)
        {
            HoraActualizada?.Invoke(this, horaActualizada);
        }

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

        public void AgregarPrenda(Indumentaria prenda)
        {
            listaIndumentaria.Add(prenda);
            ActualizarLista();
        }

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

        private void ActualizarLista()
        {
            listInd.DataSource = null;
            listInd.DataSource = listaIndumentaria;
        }

        private void ActualizarListaDesdeDB()
        {
            listaIndumentaria = FrmAgregar.PresentarRegistro();
            ActualizarLista();
        }

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
        private void ordenarPorCantidadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listaIndumentaria = listaIndumentaria
                .OrderBy(prenda => prenda.Cantidad) 
                .ToList();

            ActualizarLista();
        }
        private void ordenarPorCantidadDescendenteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listaIndumentaria = listaIndumentaria
                .OrderByDescending(prenda => prenda.Cantidad) 
                .ToList();

            ActualizarLista();
        }
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

        private void cargarJSONToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string filePath = "indumentaria.json";
            try
            {
                if (File.Exists(filePath))
                {
                    string jsonString = File.ReadAllText(filePath);
                    listaIndumentaria = JsonSerializer.Deserialize<List<Indumentaria>>(jsonString);
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
