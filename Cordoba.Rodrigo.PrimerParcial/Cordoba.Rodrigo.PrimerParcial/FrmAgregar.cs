using Entidades.Indumentaria;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace Cordoba.Rodrigo.PrimerParcial
{
    public partial class FrmAgregar : frmBaseIndumentaria
    {
        private FrmInicio inicio;

        public FrmAgregar(FrmInicio inicio)
        {
            InitializeComponent();
            this.inicio = inicio;
            this.FormClosed += FrmAgregar_FormClosed;
            cmbMaterial.Items.AddRange(Enum.GetNames(typeof(EMaterial)));

            rdbCapucha.Visible = false;
            rdbBermuda.Visible = false;
            rdbEstampado.Visible = false;

            rdbCampera.CheckedChanged += RadioButton_CheckedChanged;
            radioButton1.CheckedChanged += RadioButton_CheckedChanged;
            rdbRemera.CheckedChanged += RadioButton_CheckedChanged;
        }

        public static int AgregarIndumentaria(Indumentaria indumentaria)
        {
            int retorno = 0;

            try
            {
                using (SqlConnection conexion = BDGeneral.ObtenerConexion())
                {
                    string query = "INSERT INTO Indumentaria (codigo, cantidad, tipoMaterial, caracteristicaPropia, prenda) " +
                                   "VALUES (@codigo, @cantidad, @tipoMaterial, @caracteristicaPropia, @prenda)";
                    SqlCommand comando = new SqlCommand(query, conexion);

                    comando.Parameters.AddWithValue("@codigo", indumentaria.Codigo);
                    comando.Parameters.AddWithValue("@cantidad", indumentaria.Cantidad);
                    comando.Parameters.AddWithValue("@tipoMaterial", indumentaria.TipoMaterial.ToString());

                    if (indumentaria is Campera campera)
                    {
                        comando.Parameters.AddWithValue("@caracteristicaPropia", campera.TieneCapucha);
                        comando.Parameters.AddWithValue("@prenda", "Campera");
                    }
                    else if (indumentaria is Pantalon pantalon)
                    {
                        comando.Parameters.AddWithValue("@caracteristicaPropia", pantalon.EsBermuda);
                        comando.Parameters.AddWithValue("@prenda", "Pantalon");
                    }
                    else if (indumentaria is Remera remera)
                    {
                        comando.Parameters.AddWithValue("@caracteristicaPropia", remera.TieneEstampado);
                        comando.Parameters.AddWithValue("@prenda", "Remera");
                    }

                    retorno = comando.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Error al ejecutar la consulta: {ex.Message}");
                MessageBox.Show($"Error al ejecutar la consulta: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error inesperado: {ex.Message}");
                MessageBox.Show($"Error inesperado: {ex.Message}");
            }

            return retorno;
        }

        public static List<Indumentaria> PresentarRegistro()
        {
            List<Indumentaria> lista = new List<Indumentaria>();

            try
            {
                using (SqlConnection conexion = BDGeneral.ObtenerConexion())
                {
                    string query = "SELECT * FROM Indumentaria";
                    SqlCommand comando = new SqlCommand(query, conexion);

                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string codigo = reader["Codigo"] as string;
                            int cantidad = reader.GetInt32(reader.GetOrdinal("Cantidad"));
                            EMaterial tipoMaterial = (EMaterial)Enum.Parse(typeof(EMaterial), reader["TipoMaterial"] as string);
                            string prenda = reader["Prenda"] as string;

                            Indumentaria indumentaria = null;

                            if (prenda == "Campera")
                            {
                                bool tieneCapucha = reader.IsDBNull(reader.GetOrdinal("caracteristicaPropia")) ? false : reader.GetBoolean(reader.GetOrdinal("caracteristicaPropia"));
                                indumentaria = new Campera(codigo, cantidad, tipoMaterial, tieneCapucha);
                            }
                            else if (prenda == "Pantalon")
                            {
                                bool esBermuda = reader.IsDBNull(reader.GetOrdinal("caracteristicaPropia")) ? false : reader.GetBoolean(reader.GetOrdinal("caracteristicaPropia"));
                                indumentaria = new Pantalon(codigo, cantidad, tipoMaterial, esBermuda);
                            }
                            else if (prenda == "Remera")
                            {
                                bool tieneEstampado = reader.IsDBNull(reader.GetOrdinal("caracteristicaPropia")) ? false : reader.GetBoolean(reader.GetOrdinal("caracteristicaPropia"));
                                indumentaria = new Remera(codigo, cantidad, tipoMaterial, tieneEstampado);
                            }

                            if (indumentaria != null)
                            {
                                lista.Add(indumentaria);
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Error al ejecutar la consulta: {ex.Message}");
                MessageBox.Show($"Error al ejecutar la consulta: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error inesperado: {ex.Message}");
                MessageBox.Show($"Error inesperado: {ex.Message}");
            }

            return lista;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            int cantidad;
            string codigo;

            if (int.TryParse(textBoxCantidad.Text, out cantidad) && !string.IsNullOrEmpty(txtCodigo.Text))
            {
                codigo = txtCodigo.Text;

                EMaterial material;
                if (Enum.TryParse(cmbMaterial.SelectedItem.ToString(), out material))
                {
                    try
                    {
                        if (inicio.ListaIndumentaria.Any(p => p.Codigo == codigo))
                        {
                            throw new Inventario<Indumentaria>.CodigoDuplicadoException($"Ya existe una prenda con código {codigo}.");
                        }

                        Indumentaria prenda = null;
                        if (rdbRemera.Checked)
                        {
                            prenda = new Remera(codigo, cantidad, material, rdbEstampado.Checked);
                        }
                        else if (radioButton1.Checked)
                        {
                            prenda = new Pantalon(codigo, cantidad, material, rdbBermuda.Checked);
                        }
                        else if (rdbCampera.Checked)
                        {
                            prenda = new Campera(codigo, cantidad, material, rdbCapucha.Checked);
                        }

                        if (prenda != null)
                        {
                            int resultado = AgregarIndumentaria(prenda);
                            if (resultado > 0)
                            {
                                MessageBox.Show("Guardado exitosamente.");
                                inicio.AgregarPrenda(prenda);
                                this.Close();
                            }
                            else
                            {
                                MessageBox.Show("No se pudo guardar.");
                                Console.WriteLine("No se pudo guardar la prenda en la base de datos.");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Seleccione un tipo de prenda.");
                        }
                    }
                    catch (Inventario<Indumentaria>.CodigoDuplicadoException ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ocurrió un error: {ex.Message}");
                    }
                }
                else
                {
                    MessageBox.Show("Seleccione un material válido.");
                }
            }
            else
            {
                MessageBox.Show("Ingrese una cantidad válida y un código no vacío.");
            }
        }

        private void FrmAgregar_FormClosed(object sender, FormClosedEventArgs e)
        {
            inicio.Show();
        }

        private void RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbCampera.Checked)
            {
                rdbCapucha.Visible = true;
                rdbBermuda.Visible = false;
                rdbEstampado.Visible = false;
            }
            else if (radioButton1.Checked)
            {
                rdbCapucha.Visible = false;
                rdbBermuda.Visible = true;
                rdbEstampado.Visible = false;
            }
            else if (rdbRemera.Checked)
            {
                rdbCapucha.Visible = false;
                rdbBermuda.Visible = false;
                rdbEstampado.Visible = true;
            }
            else
            {
                rdbCapucha.Visible = false;
                rdbBermuda.Visible = false;
                rdbEstampado.Visible = false;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
            inicio.Show();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void FrmAgregar_Load(object sender, EventArgs e)
        {
        }
    }
}
