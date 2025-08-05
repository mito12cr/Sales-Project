using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using Entidad;

namespace CapaNegocio
{
    public class NProducto
    {

        private DProducto objDProducto = new DProducto();

        public List<Producto> Listar()
        {
            return objDProducto.Listar();

        }

        public int Registrar(Producto obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (obj.Codigo == "")
            {
                Mensaje += "Se Necesita Ingresar un Tipo de Documento Primero! \n";
            }

            if (obj.Nombre == "")
            {
                Mensaje += "Se Necesita Ingresar un Nombre de Producto Primero! \n";
            }
            if (obj.Descripcion == "")
            {
                Mensaje += "Se Necesita Ingresar una Descripcion del Producto Primero! \n";
            }

            if (Mensaje != string.Empty)
            {
                return 0;
            }
            else
            {
                return objDProducto.Registrar(obj, out Mensaje);
            }


        }

        public bool Editar(Producto obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (obj.Codigo == "")
            {
                Mensaje += "Se Necesita Ingresar un Tipo de Documento Primero! \n";
            }

            if (obj.Nombre == "")
            {
                Mensaje += "Se Necesita Ingresar un Nombre de Producto Primero! \n";
            }
            if (obj.Descripcion == "")
            {
                Mensaje += "Se Necesita Ingresar una Descripcion del Producto Primero! \n";
            }

            if (Mensaje != string.Empty)
            {
                return false;
            }
            else
            {
                return objDProducto.Editar(obj, out Mensaje);
            }


        }

        public bool Eliminar(Producto obj, out string Mensaje)
        {
            return objDProducto.Eliminar(obj, out Mensaje);
        }
    }
}
