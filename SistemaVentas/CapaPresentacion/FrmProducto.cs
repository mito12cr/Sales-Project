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
    public partial class FrmProducto : Form
    {
        public FrmProducto()
        {
            InitializeComponent();
        }

        private void FrmProducto_Load(object sender, EventArgs e)
        {
            cmbestado.Items.Add(new ComboOpciones() { Valor = 1, Texto = "Activo" }); // RELLENANDO EL COMBOBOX DE ESTADO
            cmbestado.Items.Add(new ComboOpciones() { Valor = 0, Texto = "No Activo" });
            cmbestado.DisplayMember = "Texto";
            cmbestado.ValueMember = "Valor";
            cmbestado.SelectedIndex = 0;

            List<Categoria> listaCategoria = new NCategoria().Listar();
            foreach (Categoria item in listaCategoria)  //Recorremos la lista para traer todos las Categorias
            {
                cmbCategoria.Items.Add(new ComboOpciones() { Valor = item.IdCategoria, Texto = item.Descripcion });//RELLENAMOS EL COMBO DE Categorias
            }
            cmbCategoria.DisplayMember = "Texto";
            cmbCategoria.ValueMember = "Valor";
            cmbCategoria.SelectedIndex = 0;

            foreach (DataGridViewColumn columna in dgvdatosProductos.Columns)
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
            List<Producto> listaProductos = new NProducto().Listar(); // Mostramos los Productos que tenemos en BD
            foreach (Producto item in listaProductos)
            {
                dgvdatosProductos.Rows.Add(new object[] {"",
                                                       item.IdProducto,
                                                       item.Codigo,
                                                       item.Nombre,
                                                       item.Descripcion,
                                                       item.OCategoria.IdCategoria,
                                                       item.OCategoria.Descripcion,
                                                       item.Stock,
                                                       item.PrecioCompra,
                                                       item.PrecioVenta,
                                                       item.Estado == true ? 1 : 0 ,
                                                       item.Estado == true ? "Activo" : "No Activo"



            });
            }
        }
        private void limpiarCajasTexto()
        {
            txtcodigo.Text = "";
            txtnombre.Text = "";
            txtdescripcion.Text = "";
            txtstock.Text = "";
            txtPrecioCompra.Text = "";
            txtPrecioVenta.Text = "";
            cmbCategoria.SelectedIndex = 0;
            cmbestado.SelectedIndex = 0;
            txtindice.Text = "-1";
            txtid.Text = "0";

        }

        private void dgvdatosProductos_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
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

        private void dgvdatosProductos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvdatosProductos.Columns[e.ColumnIndex].Name == "btnseleccionar")
            {
                int indice = e.RowIndex;

                if (indice >= 0)
                {
                    txtindice.Text = indice.ToString();
                    txtid.Text           = dgvdatosProductos.Rows[indice].Cells["id"].Value.ToString();
                    txtcodigo.Text       = dgvdatosProductos.Rows[indice].Cells["Codigo"].Value.ToString();
                    txtnombre.Text       = dgvdatosProductos.Rows[indice].Cells["Nombre"].Value.ToString();
                    txtdescripcion.Text  = dgvdatosProductos.Rows[indice].Cells["Descripcion"].Value.ToString();
                    txtstock.Text        = dgvdatosProductos.Rows[indice].Cells["Stock"].Value.ToString();
                    txtPrecioCompra.Text = dgvdatosProductos.Rows[indice].Cells["PrecioCompra"].Value.ToString();
                    txtPrecioVenta.Text  = dgvdatosProductos.Rows[indice].Cells["PrecioVenta"].Value.ToString();

                    foreach (ComboOpciones optionCombo in cmbCategoria.Items)
                    {
                        if (Convert.ToInt32(optionCombo.Valor) == Convert.ToInt32(dgvdatosProductos.Rows[indice].Cells["IdCategoria"].Value))
                        {
                            int indiceCombo = cmbCategoria.Items.IndexOf(optionCombo);
                            cmbCategoria.SelectedIndex = indiceCombo;
                            break;
                        }
                    }

                    foreach (ComboOpciones optionCombo in cmbestado.Items)
                    {
                        if (Convert.ToInt32(optionCombo.Valor) == Convert.ToInt32(dgvdatosProductos.Rows[indice].Cells["EstadoValor"].Value))
                        {
                            int indiceCombo = cmbestado.Items.IndexOf(optionCombo);
                            cmbestado.SelectedIndex = indiceCombo;
                            break;
                        }
                    }
                }
            }
        }

        private void btnguardar_Click(object sender, EventArgs e)
        {
            string mensaje = string.Empty;
            Producto objProducto = new Producto();
            {
                objProducto.IdProducto = Convert.ToInt32(txtid.Text);
                objProducto.Codigo = txtcodigo.Text;
                objProducto.Nombre = txtnombre.Text;
                objProducto.Descripcion = txtdescripcion.Text;
                objProducto.Stock = Convert.ToInt32(txtstock.Text);
                objProducto.Estado = Convert.ToInt32(((ComboOpciones)cmbestado.SelectedItem).Valor) == 1 ? true : false;
                objProducto.PrecioCompra = Convert.ToDecimal(txtPrecioCompra.Text);
                objProducto.PrecioVenta = Convert.ToDecimal(txtPrecioVenta.Text);
                objProducto.OCategoria = new Categoria() { IdCategoria = Convert.ToInt32(((ComboOpciones)cmbCategoria.SelectedItem).Valor) };


            }

            if (objProducto.IdProducto == 0)
            {
                int idproductogenerado = new NProducto().Registrar(objProducto, out mensaje);

                if (idproductogenerado != 0)
                {
                    dgvdatosProductos.Rows.Add(new object[] {"",idproductogenerado,txtcodigo.Text,txtnombre.Text,txtdescripcion.Text,txtstock.Text,
                                                    txtPrecioCompra.Text,txtPrecioVenta.Text,
                                                   ((ComboOpciones)cmbestado.SelectedItem).Valor.ToString(),
                                                   ((ComboOpciones)cmbestado.SelectedItem).Texto.ToString(),
                                                   ((ComboOpciones)cmbCategoria.SelectedItem).Valor.ToString(),
                                                   ((ComboOpciones)cmbCategoria.SelectedItem).Texto.ToString()

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
                bool resultadoProducto = new NProducto().Editar(objProducto, out mensaje);

                if (resultadoProducto)
                {
                    DataGridViewRow row = dgvdatosProductos.Rows[Convert.ToInt32(txtindice.Text)];
                    row.Cells["Id"].Value = txtid.Text;
                    row.Cells["Codigo"].Value = txtcodigo.Text;
                    row.Cells["Nombre"].Value = txtnombre.Text;
                    row.Cells["Descripcion"].Value = txtdescripcion.Text;
                    row.Cells["IdCategoria"].Value = ((ComboOpciones)cmbCategoria.SelectedItem).Valor.ToString();
                    row.Cells["Categoria"].Value = ((ComboOpciones)cmbCategoria.SelectedItem).Texto.ToString();
                    row.Cells["Stock"].Value = txtstock.Text;
                    row.Cells["PrecioCompra"].Value = txtPrecioCompra.Text;
                    row.Cells["PrecioVenta"].Value = txtPrecioVenta.Text;
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

        private void btneliminar_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(txtid.Text) != 0)
            {
                if (MessageBox.Show("Desea Eliminar El Producto?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string mensaje = string.Empty;

                    Producto objProducto = new Producto()
                    {
                        IdProducto = Convert.ToInt32(txtid.Text)
                    };

                    bool respuesta = new NProducto().Eliminar(objProducto, out mensaje);

                    if (respuesta)
                    {
                        dgvdatosProductos.Rows.RemoveAt(Convert.ToInt32(txtindice.Text));

                        limpiarCajasTexto();
                    }
                    else
                    {
                        MessageBox.Show(mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }

            }
        }

        private void btnlimpiar_Click(object sender, EventArgs e)
        {
            limpiarCajasTexto();
        }

        private void btnbuscador_Click(object sender, EventArgs e)
        {
            string columnaFiltro = ((ComboOpciones)cmbbusqueda.SelectedItem).Valor.ToString();
            if (dgvdatosProductos.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dgvdatosProductos.Rows)
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
            if (dgvdatosProductos.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dgvdatosProductos.Rows)
                {
                    if (row.Cells[columnaFiltro].Value.ToString().Trim().ToUpper().Contains(txtbusqueda.Text.Trim().ToUpper()))
                        row.Visible = true;
                    else row.Visible = false;
                }
            }
        }

        private void btnexportar_Click(object sender, EventArgs e)
        {
            if (dgvdatosProductos.Rows.Count < 1)
            {
                MessageBox.Show("No hay Datos para Exportar", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                DataTable dt = new DataTable();
                foreach (DataGridViewColumn columna in dgvdatosProductos.Columns)    //
                {
                    if (columna.HeaderText != "" && columna.Visible)
                        dt.Columns.Add(columna.HeaderText, typeof(string));
                }

                foreach (DataGridViewRow fila in dgvdatosProductos.Rows)
                {
                    if (fila.Visible)
                        dt.Rows.Add(new object[]{
                        fila.Cells[2].Value.ToString(),
                        fila.Cells[3].Value.ToString(),
                        fila.Cells[4].Value.ToString(),                       
                        fila.Cells[6].Value.ToString(),
                        fila.Cells[7].Value.ToString(),
                        fila.Cells[8].Value.ToString(),
                        fila.Cells[9].Value.ToString(),
                        fila.Cells[11].Value.ToString()
                        });
                }

                SaveFileDialog saveFile = new SaveFileDialog();
                saveFile.FileName = string.Format("ReporteProductos_{0}.xlsx", DateTime.Now.ToString("ddMMyyyyHHmmss"));
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
