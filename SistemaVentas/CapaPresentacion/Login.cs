using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;

using CapaNegocio;
using Entidad;

namespace CapaPresentacion
{
    public partial class Login : Form
    {
        
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            List<Usuario> listaUsuarios = new NUsuario().Listar();

            Usuario ousuario = new NUsuario().Listar().Where(u => u.Username == txtUsuario.Text && u.Contraseña == txtPassword.Text).FirstOrDefault();

           if(ousuario != null)
            {
                Inicio inicio = new Inicio(ousuario);  //instanciamos el formulario de inicio
                inicio.Show();
                this.Hide();

                inicio.FormClosing += frm_closing;
            }
            else
            {
                MessageBox.Show("No Se Encontrò el Usuario, Por Favor Digitar Correctamente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
          
        }

        private void frm_closing(object sender, FormClosingEventArgs e)
        {
            this.Show();
            this.txtUsuario.Text = "";
            this.txtPassword.Text = "";
        }
    }
}
