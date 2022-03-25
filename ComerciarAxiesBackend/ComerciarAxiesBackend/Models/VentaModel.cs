using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComerciarAxiesBackend.Models
{
    public class VentaModel
    {
        public int idVenta { get; set; }
        public int idOperacion { get; set; }
        public decimal montoVentaUsd { get; set; }
        public decimal montoVentaEth { get; set; }
        public decimal gananciaUsd { get; set; }
        public decimal gananciaEth { get; set; }
        public DateTime fechaVenta { get; set; }
        public decimal valorEth { get; set; }
    }
}
