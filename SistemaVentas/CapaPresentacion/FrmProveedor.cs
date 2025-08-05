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
    public partial class FrmProveedor : Form
    {
        public FrmProveedor()
        {
            InitializeComponent();
        }

        private void FrmProveedor_Load(object sender, EventArgs e)
        {
            cmbestado.Items.Add(new ComboOpciones() { Valor = 1, Texto = "Activo" }); // RELLENANDO EL COMBOBOX DE ESTADO
            cmbestado.Items.Add(new ComboOpciones() { Valor = 0, Texto = "No Activo" });
            cmbestado.DisplayMember = "Texto";
            cmbestado.ValueMember = "Valor";
            cmbestado.SelectedIndex = 0;


            foreach (DataGridViewColumn columna in dgvdatosProveedor.Columns)
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
            List<Proveedor> listaProveedors = new NProveedor().Listar(); // Mostramos los Proveedores que tenemos en BD
            foreach (Proveedor item in listaProveedors)
            {
                dgvdatosProveedor.Rows.Add(new object[] {"",item.IdProveedor,
                                                       item.TipoDocumento,
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
            txtcorreo.Text = "";
            txttelefono.Text = "";
            cmbestado.SelectedIndex = 0;
            txtindice.Text = "-1";
            txtid.Text = "0";

        }

        private void btnguardar_Click(object sender, EventArgs e)
        {
            string mensaje = string.Empty;
            Proveedor objProveedor = new Proveedor();
            {
                objProveedor.IdProveedor = Convert.ToInt32(txtid.Text);
                objProveedor.TipoDocumento = txttipodocumento.Text;
                objProveedor.Correo = txtcorreo.Text;
                objProveedor.Telefono = txttelefono.Text;
                objProveedor.Estado = Convert.ToInt32(((ComboOpciones)cmbestado.SelectedItem).Valor) == 1 ? true : false;
            }

            if (objProveedor.IdProveedor == 0)
            {
                int idProveedorgenerado = new NProveedor().Registrar(objProveedor, out mensaje);

                if (idProveedorgenerado != 0)
                {
                    dgvdatosProveedor.Rows.Add(new object[] {"",idProveedorgenerado,txttipodocumento.Text,txtcorreo.Text,txttelefono.Text,
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
                bool resultadoProveedor = new NProveedor().Editar(objProveedor, out mensaje);

                if (resultadoProveedor)
                {
                    DataGridViewRow row = dgvdatosProveedor.Rows[Convert.ToInt32(txtindice.Text)];
                    row.Cells["Id"].Value = txtid.Text;
                    row.Cells["Documento"].Value = txttipodocumento.Text;
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
                if (MessageBox.Show("Desea Eliminar El Proveedor?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string mensaje = string.Empty;

                    Proveedor objProveedor = new Proveedor()
                    {
                        IdProveedor = Convert.ToInt32(txtid.Text)
                    };

                    bool respuesta = new NProveedor().Eliminar(objProveedor, out mensaje);

                    if (respuesta)
                    {
                        dgvdatosProveedor.Rows.RemoveAt(Convert.ToInt32(txtindice.Text));

                        limpiarCajasTexto();
                    }
                    else
                    {
                        MessageBox.Show(mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }

            }
        }

        private void dgvdatosProveedor_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
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

        private void dgvdatosProveedor_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvdatosProveedor.Columns[e.ColumnIndex].Name == "btnseleccionar")
            {
                int indice = e.RowIndex;

                if (indice >= 0)
                {
                    txtindice.Text = indice.ToString();
                    txtid.Text = dgvdatosProveedor.Rows[indice].Cells["id"].Value.ToString();
                    txttipodocumento.Text = dgvdatosProveedor.Rows[indice].Cells["Documento"].Value.ToString();
                    txtcorreo.Text = dgvdatosProveedor.Rows[indice].Cells["Correo"].Value.ToString();
                    txttelefono.Text = dgvdatosProveedor.Rows[indice].Cells["Telefono"].Value.ToString();

                    foreach (ComboOpciones optionCombo in cmbestado.Items)
                    {
                        if (Convert.ToInt32(optionCombo.Valor) == Convert.ToInt32(dgvdatosProveedor.Rows[indice].Cells["EstadoValor"].Value))
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
            if (dgvdatosProveedor.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dgvdatosProveedor.Rows)
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
            if (dgvdatosProveedor.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dgvdatosProveedor.Rows)
                {
                    if (row.Cells[columnaFiltro].Value.ToString().Trim().ToUpper().Contains(txtbusqueda.Text.Trim().ToUpper()))
                        row.Visible = true;
                    else row.Visible = false;
                }
            }
            txtbusqueda.Text = "";
        }

        private void btnexportar_Click(object sender, EventArgs e)
        {
            if(dgvdatosProveedor.Rows.Count < 1)
            {
                MessageBox.Show("No hay Datos para Exportar", "Mensaje", MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
            }
            else
            {
                DataTable dt = new DataTable();
                foreach (DataGridViewColumn columna in dgvdatosProveedor.Columns)    //
                {
                    if (columna.HeaderText != "" && columna.Visible)
                        dt.Columns.Add(columna.HeaderText, typeof(string));
                }

                foreach (DataGridViewRow fila in dgvdatosProveedor.Rows)
                {
                    if (fila.Visible)
                        dt.Rows.Add(new object[]{
                        fila.Cells[2].Value.ToString(),
                        fila.Cells[3].Value.ToString(),
                        fila.Cells[4].Value.ToString(),
                        fila.Cells[6].Value.ToString(),
                        });
                }

                SaveFileDialog saveFile = new SaveFileDialog();
                saveFile.FileName = string.Format("ReportePoovedores_{0}.xlsx", DateTime.Now.ToString("ddMMyyyyHHmmss"));
                saveFile.Filter = "Excel Files | *.xlsx";

                if(saveFile.ShowDialog() == DialogResult.OK)
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
