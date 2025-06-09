﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class Usuario
    {

        public int IdUsuario { get; set; }

        public string TipoDocumento { get; set; }

        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public string Correo { get; set; }

        public string Telefono { get; set; }

        public bool Estado { get; set; }

        public string Username { get; set; }

        public string Contraseña { get; set; }

        public string FechaRegistro { get; set; }

        public Rol ORol { get; set; }




    }
}
