using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using Entidad;

namespace CapaNegocio
{
  public  class NCategoria
    {

        private DCategoria objDCategoria = new DCategoria();

        public List<Categoria> Listar()
        {
            return objDCategoria.Listar();

        }

        public int Registrar(Categoria obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (obj.Descripcion == "")
            {
                Mensaje += "El Campo ''Descripcion'' debe estar Lleno Primero! \n";
            }            

            if (Mensaje != string.Empty)
            {
                return 0;
            }
            else
            {
                return objDCategoria.Registrar(obj, out Mensaje);
            }


        }

        public bool Editar(Categoria obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (obj.Descripcion == "")
            {
                Mensaje += "El Campo ''Descripcion'' debe estar Lleno Primero! \n";
            }

            if (Mensaje != string.Empty)
            {
                return false;
            }
            else
            {
                return objDCategoria.Editar(obj, out Mensaje);
            }


        }

        public bool Eliminar(Categoria obj, out string Mensaje)
        {
            return objDCategoria.Eliminar(obj, out Mensaje);
        }
    }
}
