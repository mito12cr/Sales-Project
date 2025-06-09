using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using Entidad;

namespace CapaNegocio
{
   public class NPermiso
    {

        private DPermisos objDPermiso = new DPermisos();

        public List<Permiso> Listar(int idUsuario)
        {
            return objDPermiso.Listar(idUsuario);

        }

    }
}
