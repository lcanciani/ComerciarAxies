using System;
using System.Collections.Generic;

#nullable disable

namespace ComerciarAxiesBackend.Models.Context
{
    public partial class Compra
    {
        public Compra()
        {
            DetalleOperacions = new HashSet<DetalleOperacion>();
        }

        public int IdCompra { get; set; }
        public decimal? MontoCompraUsd { get; set; }
        public decimal? MontoCompraEth { get; set; }
        public decimal? ValorEth { get; set; }
        public DateTime? FechaCompra { get; set; }

        public virtual ICollection<DetalleOperacion> DetalleOperacions { get; set; }
    }
}
