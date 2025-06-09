using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
 public  class Ventas
    {
        public int IdVentas { get; set; }

        public string TipoDocumento { get; set; }

        public string NumeroDocumento { get; set; }

        public string DocumentoCliente { get; set; }

        public string NombreCliente { get; set; }

        public decimal MontoPago { get; set; }

        public decimal MontoCambio { get; set; }

        public decimal MontoTotal { get; set; }

        public string FechaRegistro { get; set; }

        public Usuario OUsuario { get; set; }

        public List<DetalleVenta> ODetalleVenta { get; set; }

    }
}
