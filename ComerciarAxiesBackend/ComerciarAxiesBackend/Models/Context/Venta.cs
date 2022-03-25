using System;
using System.Collections.Generic;

#nullable disable

namespace ComerciarAxiesBackend.Models.Context
{
    public partial class Venta
    {
        public Venta()
        {
            DetalleOperacions = new HashSet<DetalleOperacion>();
        }

        public int IdVenta { get; set; }
        public decimal? MontoVentaUsd { get; set; }
        public decimal? MontoVentaEth { get; set; }
        public decimal? ValorEth { get; set; }
        public DateTime? FechaVenta { get; set; }

        public virtual ICollection<DetalleOperacion> DetalleOperacions { get; set; }
    }
}
