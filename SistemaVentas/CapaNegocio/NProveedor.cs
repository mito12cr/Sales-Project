using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using Entidad;

namespace CapaNegocio
{
    public class NProveedor
    {
        private DProveedor objDProveedor = new DProveedor();

        public List<Proveedor> Listar()
        {
            return objDProveedor.Listar();

        }

        public int Registrar(Proveedor obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (obj.TipoDocumento == "")
            {
                Mensaje += "Se Necesita Ingresar un Tipo de Documento Primero! \n";
            }

            if (Mensaje != string.Empty)
            {
                return 0;
            }
            else
            {
                return objDProveedor.Registrar(obj, out Mensaje);
            }


        }

        public bool Editar(Proveedor obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (obj.TipoDocumento == "")
            {
                Mensaje += "Se Necesita Ingresar un Tipo de Documento Primero! \n";
            }

            if (Mensaje != string.Empty)
            {
                return false;
            }
            else
            {
                return objDProveedor.Editar(obj, out Mensaje);
            }


        }

        public bool Eliminar(Proveedor obj, out string Mensaje)
        {
            return objDProveedor.Eliminar(obj, out Mensaje);
        }
    }
}
