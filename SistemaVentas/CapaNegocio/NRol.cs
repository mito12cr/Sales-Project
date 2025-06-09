using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using Entidad;

namespace CapaNegocio
{
   public class NRol
    {

        private DRol objDRol = new DRol();

        public List<Rol> Listar()
        {
            return objDRol.Listar();

        }
    }
}
