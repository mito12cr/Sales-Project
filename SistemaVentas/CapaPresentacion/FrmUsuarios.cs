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

namespace CapaPresentacion
{
    public partial class FrmUsuarios : Form
    {
        public FrmUsuarios()
        {
            InitializeComponent();
        }

        private void FrmUsuarios_Load(object sender, EventArgs e)
        {
            cmbestado.Items.Add(new ComboOpciones() { Valor = 1, Texto = "Activo" }); // RELLENANDO EL COMBOBOX DE ESTADO
            cmbestado.Items.Add(new ComboOpciones() { Valor = 0, Texto = "No Activo" });
            cmbestado.DisplayMember = "Texto";
            cmbestado.ValueMember = "Valor";
            cmbestado.SelectedIndex = 0;

            List<Rol> listaRol = new NRol().Listar();
            foreach (Rol item in listaRol)  //Recorremos la lista para traer todos los roles
            {
                cmbrol.Items.Add(new ComboOpciones() { Valor = item.IdRol, Texto = item.Descripcion });//RELLENAMOS EL COMBO DE ROL
            }
            cmbrol.DisplayMember = "Texto";
            cmbrol.ValueMember = "Valor";
            cmbrol.SelectedIndex = 0;

            foreach (DataGridViewColumn columna in dgvdatosUser.Columns)
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
            List<Usuario> listaUsuarios = new NUsuario().Listar(); // Mostramos los Usuarios que tenemos en BD
            foreach (Usuario item in listaUsuarios)
            {
                dgvdatosUser.Rows.Add(new object[] {"",item.IdUsuario,
                                                       item.TipoDocumento,
                                                       item.Nombre,
                                                       item.Apellido,
                                                       item.Correo,
                                                       item.Telefono,        
                                                       item.Estado == true ? 1 : 0 ,
                                                       item.Estado == true ? "Activo" : "No Activo",
                                                       item.Username,
                                                       item.Contraseña,
                                                       item.ORol.IdRol,
                                                       item.ORol.Descripcion



            });
            }
        }

        private void picboxGuardar_Click(object sender, EventArgs e)
        {
            dgvdatosUser.Rows.Add(new object[] {"",txtid.Text,txttipodocumento.Text,txtnombre.Text,txtapellido.Text,txtcorreo.Text,
                                                   txtusername.Text,txttelefono.Text,
                                                   ((ComboOpciones)cmbestado.SelectedItem).Valor.ToString(),
                                                   ((ComboOpciones)cmbestado.SelectedItem).Texto.ToString(),
                                                   ((ComboOpciones)cmbrol.SelectedItem).Valor.ToString(),
                                                   ((ComboOpciones)cmbrol.SelectedItem).Texto.ToString()

            });
            limpiarCajasTexto();
        }

        private void limpiarCajasTexto()
        {
            txttipodocumento.Text = "";
            txtnombre.Text = "";
            txtapellido.Text = "";
            txtcorreo.Text = "";
            txtusername.Text = "";
            txttelefono.Text = "";
            txtcontraseña.Text = "";
            txtrepetirrcontraseña.Text = "";
            cmbrol.SelectedIndex = 0;
            cmbestado.SelectedIndex = 0;
            txtindice.Text = "-1";
            txtid.Text = "0";

        }

        private void dgvdatosUser_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
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

        private void dgvdatosUser_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvdatosUser.Columns[e.ColumnIndex].Name == "btnseleccionar")
            {
                int indice = e.RowIndex;

                if (indice >= 0)
                {
                    txtindice.Text              = indice.ToString();
                    txtid.Text                  = dgvdatosUser.Rows[indice].Cells["id"].Value.ToString();
                    txttipodocumento.Text       = dgvdatosUser.Rows[indice].Cells["Documento"].Value.ToString();
                    txtnombre.Text              = dgvdatosUser.Rows[indice].Cells["Nombre"].Value.ToString();
                    txtapellido.Text            = dgvdatosUser.Rows[indice].Cells["Apellido"].Value.ToString();
                    txtcorreo.Text              = dgvdatosUser.Rows[indice].Cells["Correo"].Value.ToString();                    
                    txtusername.Text            = dgvdatosUser.Rows[indice].Cells["UserName"].Value.ToString();
                    txttelefono.Text            = dgvdatosUser.Rows[indice].Cells["Telefono"].Value.ToString();
                    txtcontraseña.Text          = dgvdatosUser.Rows[indice].Cells["Contraseña"].Value.ToString();
                    txtrepetirrcontraseña.Text  = dgvdatosUser.Rows[indice].Cells["Contraseña"].Value.ToString();

                    foreach (ComboOpciones optionCombo in cmbrol.Items)
                    {
                        if (Convert.ToInt32(optionCombo.Valor) == Convert.ToInt32(dgvdatosUser.Rows[indice].Cells["IdRol"].Value))
                        {
                            int indiceCombo = cmbrol.Items.IndexOf(optionCombo);
                            cmbrol.SelectedIndex = indiceCombo;
                            break;
                        }
                    }

                    foreach (ComboOpciones optionCombo in cmbestado.Items)
                    {
                        if (Convert.ToInt32(optionCombo.Valor) == Convert.ToInt32(dgvdatosUser.Rows[indice].Cells["EstadoValor"].Value))
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
            Usuario objUsuario = new Usuario();
            {
                objUsuario.IdUsuario     = Convert.ToInt32(txtid.Text);
                objUsuario.TipoDocumento = txttipodocumento.Text;
                objUsuario.Nombre        = txtnombre.Text;
                objUsuario.Apellido      = txtapellido.Text;
                objUsuario.Correo        = txtcorreo.Text;
                objUsuario.Estado        = Convert.ToInt32(((ComboOpciones)cmbestado.SelectedItem).Valor) == 1 ? true : false;
                objUsuario.Username      = txtusername.Text;
                objUsuario.Telefono      = txttelefono.Text;
                objUsuario.Contraseña    = txtcontraseña.Text;
                objUsuario.ORol = new Rol() { IdRol = Convert.ToInt32(((ComboOpciones)cmbrol.SelectedItem).Valor) };

                
            }

            if(objUsuario.IdUsuario == 0)
            {
                int idusuariogenerado = new NUsuario().Registrar(objUsuario, out mensaje);

                if (idusuariogenerado != 0)
                {
                    dgvdatosUser.Rows.Add(new object[] {"",idusuariogenerado,txttipodocumento.Text,txtnombre.Text,txtapellido.Text,txtcorreo.Text,
                                                   txtusername.Text,txttelefono.Text,
                                                   ((ComboOpciones)cmbestado.SelectedItem).Valor.ToString(),
                                                   ((ComboOpciones)cmbestado.SelectedItem).Texto.ToString(),
                                                   ((ComboOpciones)cmbrol.SelectedItem).Valor.ToString(),
                                                   ((ComboOpciones)cmbrol.SelectedItem).Texto.ToString()

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
                bool resultadoUsuario = new NUsuario().Editar(objUsuario , out mensaje);

                if(resultadoUsuario)
                {
                    DataGridViewRow row = dgvdatosUser.Rows[Convert.ToInt32(txtindice.Text)];
                    row.Cells["Id"].Value = txtid.Text;
                    row.Cells["Documento"].Value = txttipodocumento.Text;
                    row.Cells["Nombre"].Value = txtnombre.Text;
                    row.Cells["Apellido"].Value = txtapellido.Text;
                    row.Cells["Correo"].Value = txtcorreo.Text;
                    row.Cells["UserName"].Value = txtusername.Text;
                    row.Cells["Telefono"].Value = txttelefono.Text;
                    row.Cells["Contraseña"].Value = txtcontraseña.Text;
                    row.Cells["EstadoValor"].Value = ((ComboOpciones)cmbestado.SelectedItem).Valor.ToString();
                    row.Cells["Estado"].Value      = ((ComboOpciones)cmbestado.SelectedItem).Texto.ToString();
                    row.Cells["IdRol"].Value       = ((ComboOpciones)cmbrol.SelectedItem).Valor.ToString();
                    row.Cells["Rol"].Value         = ((ComboOpciones)cmbrol.SelectedItem).Texto.ToString();

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
                if (MessageBox.Show("Desea Eliminar El Usuario?" ,"Mensaje", MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string mensaje = string.Empty;

                    Usuario objUsuario = new Usuario()
                    {
                        IdUsuario = Convert.ToInt32(txtid.Text)
                    };

                    bool respuesta = new NUsuario().Eliminar(objUsuario, out mensaje);

                    if(respuesta)
                    {
                        dgvdatosUser.Rows.RemoveAt(Convert.ToInt32(txtindice.Text));

                        limpiarCajasTexto();
                    }
                    else
                    {
                        MessageBox.Show(mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }

            }
        }

        private void btnbuscador_Click(object sender, EventArgs e)
        {
            string columnaFiltro = ((ComboOpciones)cmbbusqueda.SelectedItem).Valor.ToString();
            if (dgvdatosUser.Rows.Count > 0)
            {
                foreach(DataGridViewRow row in dgvdatosUser.Rows)
                {
                    if (row.Cells[columnaFiltro].Value.ToString().Trim().ToUpper().Contains(txtbusqueda.Text.Trim().ToUpper()))
                        row.Visible = true;
                    else row.Visible = false;
                }
            }
        }

        private void btnlimpiarcajas_Click(object sender, EventArgs e)
        {
            txtbusqueda.Text = "";
            foreach(DataGridViewRow row in dgvdatosUser.Rows)
            {
                row.Visible = true;
            }
        }
    }
}