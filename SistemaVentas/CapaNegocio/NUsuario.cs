using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using Entidad;

namespace CapaNegocio
{
  public  class NUsuario
    {

        private DUsuario objDUsuario = new DUsuario();

        public List<Usuario> Listar()
        {
            return objDUsuario.Listar();

        }

        public int Registrar(Usuario obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if(obj.TipoDocumento == "")
            {
                Mensaje += "Se Necesita Ingresar un Tipo de Documento Primero! \n";
            }

            if (obj.Nombre == "")
            {
                Mensaje += "Se Necesita Ingresar un Nombre de Usuario Primero! \n";
            }

            if (obj.Contraseña == "")
            {
                Mensaje += "Se Necesita Ingresar una Contraseña Primero! \n";
            }

            if(Mensaje != string.Empty)
            {
                return 0;
            }
            else
            {
                return objDUsuario.Registrar(obj, out Mensaje);
            }

            
        }

        public bool Editar(Usuario obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (obj.TipoDocumento == "")
            {
                Mensaje += "Se Necesita Ingresar un Tipo de Documento Primero! \n";
            }

            if (obj.Nombre == "")
            {
                Mensaje += "Se Necesita Ingresar un Nombre de Usuario Primero! \n";
            }

            if (obj.Contraseña == "")
            {
                Mensaje += "Se Necesita Ingresar una Contraseña Primero! \n";
            }

            if (Mensaje != string.Empty)
            {
                return false;
            }
            else
            {
                return objDUsuario.Editar(obj, out Mensaje);
            }

            
        }

        public bool Eliminar(Usuario obj, out string Mensaje)
        {
            return objDUsuario.Eliminar(obj, out Mensaje);
        }
    }
}
