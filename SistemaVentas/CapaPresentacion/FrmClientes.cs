using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using CapaPresentacion.Utilidades;
using CapaNegocio;
using Entidad;
using ClosedXML.Excel;

namespace CapaPresentacion
{
    public partial class FrmClientes : Form
    {
        public FrmClientes()
        {
            InitializeComponent();
        }

        private void FrmClientes_Load(object sender, EventArgs e)
        {
            cmbestado.Items.Add(new ComboOpciones() { Valor = 1, Texto = "Activo" }); // RELLENANDO EL COMBOBOX DE ESTADO
            cmbestado.Items.Add(new ComboOpciones() { Valor = 0, Texto = "No Activo" });
            cmbestado.DisplayMember = "Texto";
            cmbestado.ValueMember = "Valor";
            cmbestado.SelectedIndex = 0;


            foreach (DataGridViewColumn columna in dgvdatosCliente.Columns)
            {
                if (columna.Visible == true && columna.Name != "btnseleccionar")
                {
                    cmbbusqueda.Items.Add(new ComboOpciones() { Valor = columna.Name, Texto = columna.HeaderText });
                }
            }
            cmbbusqueda.DisplayMember = "Texto";
            cmbbusqueda.ValueMember = "Valor";
            cmbbusqueda.SelectedIndex = 0;

            ///--------------------------------------------------------------------------------------------------------------------------//
            List<Cliente> listaClientes = new NCliente().Listar(); // Mostramos los Clientes que tenemos en BD
            foreach (Cliente item in listaClientes)
            {
                dgvdatosCliente.Rows.Add(new object[] {"",item.IdCliente,
                                                       item.TipoDocumento,
                                                       item.Nombre,
                                                       item.Apellido,
                                                       item.Correo,
                                                       item.Telefono,                                                       
                                                       item.Estado == true ? 1 : 0 ,
                                                       item.Estado == true ? "Activo" : "No Activo"



            });
            }
        }

        private void limpiarCajasTexto()
        {
            txttipodocumento.Text = "";
            txtnombre.Text = "";
            txtapellido.Text = "";
            txtcorreo.Text = "";
            txttelefono.Text = "";
            cmbestado.SelectedIndex = 0;
            txtindice.Text = "-1";
            txtid.Text = "0";

        }

        private void btnguardar_Click(object sender, EventArgs e)
        {
            string mensaje = string.Empty;
            Cliente objCliente = new Cliente();
            {
                objCliente.IdCliente = Convert.ToInt32(txtid.Text);
                objCliente.TipoDocumento = txttipodocumento.Text;
                objCliente.Nombre = txtnombre.Text;
                objCliente.Apellido = txtapellido.Text;
                objCliente.Correo = txtcorreo.Text;
                objCliente.Telefono = txttelefono.Text;                
                objCliente.Estado = Convert.ToInt32(((ComboOpciones)cmbestado.SelectedItem).Valor) == 1 ? true : false;
            }

            if (objCliente.IdCliente == 0)
            {
                int idClientegenerado = new NCliente().Registrar(objCliente, out mensaje);

                if (idClientegenerado != 0)
                {
                    dgvdatosCliente.Rows.Add(new object[] {"",idClientegenerado,txttipodocumento.Text,txtnombre.Text,txtapellido.Text,txtcorreo.Text,txttelefono.Text,
                                                   ((ComboOpciones)cmbestado.SelectedItem).Valor.ToString(),
                                                   ((ComboOpciones)cmbestado.SelectedItem).Texto.ToString()

            });
                    limpiarCajasTexto();
                }

                else
                {
                    MessageBox.Show(mensaje);
                }
            }

            ///FIN REGISTRAR

            else
            {
                bool resultadoCliente = new NCliente().Editar(objCliente, out mensaje);

                if (resultadoCliente)
                {
                    DataGridViewRow row = dgvdatosCliente.Rows[Convert.ToInt32(txtindice.Text)];
                    row.Cells["Id"].Value = txtid.Text;
                    row.Cells["Documento"].Value = txttipodocumento.Text;
                    row.Cells["Nombre"].Value = txtnombre.Text;
                    row.Cells["Apellido"].Value = txtapellido.Text;
                    row.Cells["Correo"].Value = txtcorreo.Text;
                    row.Cells["Telefono"].Value = txttelefono.Text;                   
                    row.Cells["EstadoValor"].Value = ((ComboOpciones)cmbestado.SelectedItem).Valor.ToString();
                    row.Cells["Estado"].Value = ((ComboOpciones)cmbestado.SelectedItem).Texto.ToString();

                    limpiarCajasTexto();
                }
                else
                {
                    MessageBox.Show(mensaje);
                }
            }
        }

        private void btnlimpiar_Click(object sender, EventArgs e)
        {
            limpiarCajasTexto();
        }

        private void btneliminar_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(txtid.Text) != 0)
            {
                if (MessageBox.Show("Desea Eliminar El Cliente?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string mensaje = string.Empty;

                    Cliente objCliente = new Cliente()
                    {
                        IdCliente = Convert.ToInt32(txtid.Text)
                    };

                    bool respuesta = new NCliente().Eliminar(objCliente, out mensaje);

                    if (respuesta)
                    {
                        dgvdatosCliente.Rows.RemoveAt(Convert.ToInt32(txtindice.Text));

                        limpiarCajasTexto();
                    }
                    else
                    {
                        MessageBox.Show(mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }

            }
        }

        private void dgvdatosCliente_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            if (e.ColumnIndex == 0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                var w = Properties.Resources.iconChechPeke2.Width;
                var h = Properties.Resources.iconChechPeke2.Height;
                var x = e.CellBounds.Left + (e.CellBounds.Width - w) / 2;
                var y = e.CellBounds.Top + (e.CellBounds.Height - h) / 2;

                e.Graphics.DrawImage(Properties.Resources.iconChechPeke2, new Rectangle(x, y, w, h));
                e.Handled = true;
            }
        }

        private void dgvdatosCliente_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvdatosCliente.Columns[e.ColumnIndex].Name == "btnseleccionar")
            {
                int indice = e.RowIndex;

                if (indice >= 0)
                {
                    txtindice.Text = indice.ToString();
                    txtid.Text = dgvdatosCliente.Rows[indice].Cells["id"].Value.ToString();
                    txttipodocumento.Text = dgvdatosCliente.Rows[indice].Cells["Documento"].Value.ToString();
                    txtnombre.Text = dgvdatosCliente.Rows[indice].Cells["Nombre"].Value.ToString();
                    txtapellido.Text = dgvdatosCliente.Rows[indice].Cells["Apellido"].Value.ToString();
                    txtcorreo.Text = dgvdatosCliente.Rows[indice].Cells["Correo"].Value.ToString();
                    txttelefono.Text = dgvdatosCliente.Rows[indice].Cells["Telefono"].Value.ToString();

                    foreach (ComboOpciones optionCombo in cmbestado.Items)
                    {
                        if (Convert.ToInt32(optionCombo.Valor) == Convert.ToInt32(dgvdatosCliente.Rows[indice].Cells["EstadoValor"].Value))
                        {
                            int indiceCombo = cmbestado.Items.IndexOf(optionCombo);
                            cmbestado.SelectedIndex = indiceCombo;
                            break;
                        }
                    }
                }
            }
        }

        private void btnbuscador_Click(object sender, EventArgs e)
        {
            string columnaFiltro = ((ComboOpciones)cmbbusqueda.SelectedItem).Valor.ToString();
            if (dgvdatosCliente.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dgvdatosCliente.Rows)
                {
                    if (row.Cells[columnaFiltro].Value.ToString().Trim().ToUpper().Contains(txtbusqueda.Text.Trim().ToUpper()))
                        row.Visible = true;
                    else row.Visible = false;
                }
            }
        }

        private void btnlimpiarcajas_Click(object sender, EventArgs e)
        {
            string columnaFiltro = ((ComboOpciones)cmbbusqueda.SelectedItem).Valor.ToString();
            if (dgvdatosCliente.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dgvdatosCliente.Rows)
                {
                    if (row.Cells[columnaFiltro].Value.ToString().Trim().ToUpper().Contains(txtbusqueda.Text.Trim().ToUpper()))
                        row.Visible = true;
                    else row.Visible = false;
                }
            }
        }

        private void btnexportar_Click(object sender, EventArgs e)
        {
            if (dgvdatosCliente.Rows.Count < 1)
            {
                MessageBox.Show("No hay Datos para Exportar", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                DataTable dt = new DataTable();
                foreach (DataGridViewColumn columna in dgvdatosCliente.Columns)    //
                {
                    if (columna.HeaderText != "" && columna.Visible)
                        dt.Columns.Add(columna.HeaderText, typeof(string));
                }

                foreach (DataGridViewRow fila in dgvdatosCliente.Rows)
                {
                    if (fila.Visible)
                        dt.Rows.Add(new object[]{
                        fila.Cells[2].Value.ToString(),
                        fila.Cells[3].Value.ToString(),
                        fila.Cells[4].Value.ToString(),
                        fila.Cells[5].Value.ToString(),
                        fila.Cells[6].Value.ToString(),
                        fila.Cells[8].Value.ToString(),
                        });
                }

                SaveFileDialog saveFile = new SaveFileDialog();
                saveFile.FileName = string.Format("ReporteClientes_{0}.xlsx", DateTime.Now.ToString("ddMMyyyyHHmmss"));
                saveFile.Filter = "Excel Files | *.xlsx";

                if (saveFile.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        XLWorkbook wb = new XLWorkbook();
                        var hoja = wb.Worksheets.Add(dt, "Informe");
                        hoja.ColumnsUsed().AdjustToContents();
                        wb.SaveAs(saveFile.FileName);
                        MessageBox.Show("Reporte Generado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Error al Generar Reporte.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
        }
    }
}
