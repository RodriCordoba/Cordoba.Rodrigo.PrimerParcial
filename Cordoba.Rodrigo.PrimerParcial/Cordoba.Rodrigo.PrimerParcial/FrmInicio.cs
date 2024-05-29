using Entidades.Indumentaria;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text.Json;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Cordoba.Rodrigo.PrimerParcial
{
    public partial class FrmInicio : Form
    {
        private List<Indumentaria> listaIndumentaria;

        public FrmInicio(string nombreOperador)
        {
            InitializeComponent();
            this.IsMdiContainer = true;
            FrmInicio_Load();
            labelOperador.Text = "Operador: " + nombreOperador;
            listaIndumentaria = new List<Indumentaria>();
        }

        private void FrmInicio_Load()
        {
            string fechaActual = DateTime.Today.ToString("dd/MM/yyyy");
            labelFecha.Text = "Fecha: " + fechaActual;
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
            ActualizarLista();
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

                ActualizarLista();

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
        private void ordenarListaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listaIndumentaria = listaIndumentaria.OrderBy(prenda => {
                if (prenda is Pantalon) return "Pantalon";
                if (prenda is Campera) return "Campera";
                if (prenda is Remera) return "Remera";
                return string.Empty;
            }).ThenBy(prenda => prenda.Cantidad).ToList();
            ActualizarLista();
        }  
        private void xMLToolStripMenuItem_Click(object sender, EventArgs e)//guarda el archivo xml
        {
            
        }
        private void jSONToolStripMenuItem_Click(object sender, EventArgs e)//guarda el archivo json
        {
 
        }

        private void cargarXMLToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void cargarJSONToolStripMenuItem_Click(object sender, EventArgs e)
        {

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