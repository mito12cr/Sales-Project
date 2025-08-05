using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using Entidad;

namespace CapaNegocio
{
   public class NCliente
    {
        private DCliente objDCliente = new DCliente();

        public List<Cliente> Listar()
        {
            return objDCliente.Listar();

        }

        public int Registrar(Cliente obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (obj.TipoDocumento == "")
            {
                Mensaje += "Se Necesita Ingresar un Tipo de Documento Primero! \n";
            }

            if (obj.Nombre == "")
            {
                Mensaje += "Se Necesita Ingresar un Nombre de Cliente Primero! \n";
            }

            if (Mensaje != string.Empty)
            {
                return 0;
            }
            else
            {
                return objDCliente.Registrar(obj, out Mensaje);
            }


        }

        public bool Editar(Cliente obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (obj.TipoDocumento == "")
            {
                Mensaje += "Se Necesita Ingresar un Tipo de Documento Primero! \n";
            }

            if (obj.Nombre == "")
            {
                Mensaje += "Se Necesita Ingresar un Nombre de Cliente Primero! \n";
            }

            if (Mensaje != string.Empty)
            {
                return false;
            }
            else
            {
                return objDCliente.Editar(obj, out Mensaje);
            }


        }

        public bool Eliminar(Cliente obj, out string Mensaje)
        {
            return objDCliente.Eliminar(obj, out Mensaje);
        }
    }
}
