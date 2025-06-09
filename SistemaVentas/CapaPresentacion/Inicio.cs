using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FontAwesome.Sharp;

using Entidad;
using CapaNegocio;

namespace CapaPresentacion
{
    public partial class Inicio : Form
    {
        private static Usuario usuarioActual;
        private static IconMenuItem MenuActivo;
        private static Form FormularioActual;

        public Inicio(Usuario obusuario)
        { 
            usuarioActual = obusuario;

            InitializeComponent();
        }

        private void Inicio_Load(object sender, EventArgs e)
        {
            List<Permiso> listaPermisos = new NPermiso().Listar(usuarioActual.IdUsuario);

            foreach (IconMenuItem iconMenu in menuMain.Items)
            {
                bool ItemsEncontrados = listaPermisos.Any(m => m.NombreMenu == iconMenu.Name);

                if (ItemsEncontrados == false)
                {
                    iconMenu.Visible = false;
                   
                }
            }

             lblusuario2.Text = usuarioActual.Username;


        }

        private void AbrirFormulario(IconMenuItem menu, Form formulario)
        {
            if(MenuActivo != null)
            {
                MenuActivo.BackColor = Color.White;
            }
            menu.BackColor = Color.Silver;
            MenuActivo = menu;

            if (FormularioActual != null)
            {
                FormularioActual.Close();
            }

            FormularioActual = formulario;
            formulario.TopLevel = false;
            formulario.FormBorderStyle = FormBorderStyle.None;
            formulario.Dock = DockStyle.Fill;
            formulario.BackColor = Color.Silver;

            Contenedor.Controls.Add(formulario);
            formulario.Show();

        }

        private void MnuUsuarios_Click(object sender, EventArgs e)
        {
            AbrirFormulario((IconMenuItem)sender, new FrmUsuarios());

         //   FrmUsuarios ofrmUsuario = new FrmUsuarios();
        ///   ofrmUsuario.Show();
          /// this.Hide();
        }

        private void MnuProductos_Click(object sender, EventArgs e)
        {
            AbrirFormulario((IconMenuItem)sender, new FrmProductos());
        }

        private void MnuCategorias_Click(object sender, EventArgs e)
        {
            AbrirFormulario((IconMenuItem)sender, new FrmCategorias());
        }


        private void MnuProveedores_Click(object sender, EventArgs e)
        {
            AbrirFormulario((IconMenuItem)sender, new FrmProveedores());
        }

        private void MnuClientes_Click(object sender, EventArgs e)
        {
            AbrirFormulario((IconMenuItem)sender, new FrmClientes());
        }

        private void MnuRegistrarCompra_Click(object sender, EventArgs e)
        {
            AbrirFormulario((IconMenuItem)sender, new FrmCompras());
        }

        private void MnuRVenta_Click(object sender, EventArgs e)
        {
            AbrirFormulario((IconMenuItem)sender, new FrmVentas());
        }
    }
}
