using Entidades.Indumentaria;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Cordoba.Rodrigo.PrimerParcial
{
    public partial class FrmInicio : Form
    {
        private List<Indumentaria> listaIndumentaria;

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
        }

        private void FrmInicio_Load()
        {
            string fechaActual = DateTime.Today.ToString("dd/MM/yyyy");
            labelFecha.Text = "Fecha: " + fechaActual;
            //ActualizarListaDesdeDB();
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

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (listInd.SelectedItem != null)
            {
                Indumentaria prendaSeleccionada = (Indumentaria)listInd.SelectedItem;
                string descripcionPrenda = prendaSeleccionada.ToString();

                FrmEliminar frmEliminar = new FrmEliminar(this, descripcionPrenda);
                frmEliminar.ShowDialog();

                if (frmEliminar.Confirmado)
                {
                    listaIndumentaria.Remove(prendaSeleccionada);
                    ActualizarLista();
                    MessageBox.Show("Prenda eliminada con éxito.");
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
                    listaIndumentaria[i].SetCantidad(prenda.Cantidad);
                    listaIndumentaria[i].SetTipoMaterial(prenda.TipoMaterial);
                    listaIndumentaria[i].SetCodigo(prenda.Codigo);
                    break;
                }
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
            }).ThenBy(prenda => prenda.Cantidad).ToList();
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
