﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
  public  class Proveedor
    {
        public int IdProveedor { get; set; }

        public string TipoDocumento { get; set; }

        public string Correo { get; set; }

        public string Telefono { get; set; }

        public bool Estado { get; set; }

        public string FechaRegistro { get; set; }

         
    }
}
