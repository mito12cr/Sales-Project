using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class Permiso
    {
        public int IdPermiso { get; set; }

        public string NombreMenu { get; set; }

        public string FechaRegistro { get; set; }

        public Rol ORol { get; set; }  //Para acceder al Foreing key de la tabla Rol y obtener su IdRol



    }
}
