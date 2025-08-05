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
    public partial class FrmCategorias : Form
    {
        public FrmCategorias()
        {
            InitializeComponent();
        }

        private void FrmCategorias_Load(object sender, EventArgs e)
        {
            cmbestado.Items.Add(new ComboOpciones() { Valor = 1, Texto = "Activo" }); // RELLENANDO EL COMBOBOX DE ESTADO
            cmbestado.Items.Add(new ComboOpciones() { Valor = 0, Texto = "No Activo" });
            cmbestado.DisplayMember = "Texto";
            cmbestado.ValueMember = "Valor";
            cmbestado.SelectedIndex = 0;

            foreach (DataGridViewColumn columna in dgvCategorias.Columns)
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
            List<Categoria> listaCategorias = new NCategoria().Listar(); // Mostramos las categorias que tenemos en BD
            foreach (Categoria item in listaCategorias)
            {
                dgvCategorias.Rows.Add(new object[] {"",     item.IdCategoria,
                                                             item.Descripcion,
                                                             item.Estado == true ? 1 : 0 ,
                                                             item.Estado == true ? "Activo" : "No Activo"

            });
            }


        }

        private void btnguardar_Click(object sender, EventArgs e)
        {
            string mensaje = string.Empty;
            Categoria objcategoria = new Categoria();
            {
                objcategoria.IdCategoria = Convert.ToInt32(txtid.Text);
                objcategoria.Descripcion = txtdescripcion.Text;
                objcategoria.Estado = Convert.ToInt32(((ComboOpciones)cmbestado.SelectedItem).Valor) == 1 ? true : false;

            }

            if (objcategoria.IdCategoria == 0)
            {
                int idcategoriagenerado = new NCategoria().Registrar(objcategoria, out mensaje);

                if (idcategoriagenerado != 0)
                {
                    dgvCategorias.Rows.Add(new object[] {"",idcategoriagenerado,txtdescripcion.Text,
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
                bool resultadoCategoria = new NCategoria().Editar(objcategoria, out mensaje);

                if (resultadoCategoria)
                {
                    DataGridViewRow row = dgvCategorias.Rows[Convert.ToInt32(txtindice.Text)];
                    row.Cells["Id"].Value = txtid.Text;
                    row.Cells["Descripcion"].Value = txtdescripcion.Text;
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

        private void limpiarCajasTexto()
        {
            txtdescripcion.Text = "";           
            cmbestado.SelectedIndex = 0;
            txtindice.Text = "-1";
            txtid.Text = "0";

        }

        private void btneliminar_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(txtid.Text) != 0)
            {
                if (MessageBox.Show("Desea Eliminar la Categoria?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string mensaje = string.Empty;

                    Categoria objCategoria = new Categoria()
                    {
                        IdCategoria = Convert.ToInt32(txtid.Text)
                    };

                    bool respuesta = new NCategoria().Eliminar(objCategoria, out mensaje);   //Revisar bien esta logica!!

                    if (respuesta)  //Por aca tambien
                    {
                        dgvCategorias.Rows.RemoveAt(Convert.ToInt32(txtindice.Text));

                        limpiarCajasTexto();
                    }
                    else
                    {
                        MessageBox.Show(mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }

            }
        }

        private void dgvCategorias_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
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

        private void dgvCategorias_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvCategorias.Columns[e.ColumnIndex].Name == "btnseleccionar")
            {
                int indice = e.RowIndex;

                if (indice >= 0)
                {
                    txtindice.Text = indice.ToString();
                    txtid.Text = dgvCategorias.Rows[indice].Cells["id"].Value.ToString();
                    txtdescripcion.Text = dgvCategorias.Rows[indice].Cells["Descripcion"].Value.ToString();                   

                    foreach (ComboOpciones optionCombo in cmbestado.Items)
                    {
                        if (Convert.ToInt32(optionCombo.Valor) == Convert.ToInt32(dgvCategorias.Rows[indice].Cells["EstadoValor"].Value))
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
            if (dgvCategorias.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dgvCategorias.Rows)
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
            if (dgvCategorias.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dgvCategorias.Rows)
                {
                    if (row.Cells[columnaFiltro].Value.ToString().Trim().ToUpper().Contains(txtbusqueda.Text.Trim().ToUpper()))
                        row.Visible = true;
                    else row.Visible = false;
                }
            }
        }

        private void btnlimpiar_Click(object sender, EventArgs e)
        {
            limpiarCajasTexto();
        }

        private void btnexportar_Click(object sender, EventArgs e)
        {
            if (dgvCategorias.Rows.Count < 1)
            {
                MessageBox.Show("No hay Datos para Exportar", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                DataTable dt = new DataTable();
                foreach (DataGridViewColumn columna in dgvCategorias.Columns)    //
                {
                    if (columna.HeaderText != "" && columna.Visible)
                        dt.Columns.Add(columna.HeaderText, typeof(string));
                }

                foreach (DataGridViewRow fila in dgvCategorias.Rows)
                {
                    if (fila.Visible)
                        dt.Rows.Add(new object[]{
                        fila.Cells[2].Value.ToString(),
                        fila.Cells[4].Value.ToString()
                        });
                }

                SaveFileDialog saveFile = new SaveFileDialog();
                saveFile.FileName = string.Format("ReporteCategorias_{0}.xlsx", DateTime.Now.ToString("ddMMyyyyHHmmss"));
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
