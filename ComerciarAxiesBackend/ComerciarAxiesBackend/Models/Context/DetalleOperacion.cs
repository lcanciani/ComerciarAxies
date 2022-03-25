using System;
using System.Collections.Generic;

#nullable disable

namespace ComerciarAxiesBackend.Models.Context
{
    public partial class DetalleOperacion
    {
        public int IdOperacion { get; set; }
        public decimal? ValorEth { get; set; }
        public decimal? ComisionMercado { get; set; }
        public decimal? MontoComisionOperacion { get; set; }
        public decimal? MontoComisionOperacionEth { get; set; }
        public decimal? GananciaUsd { get; set; }
        public decimal? GananciaEth { get; set; }
        public string Descripcion { get; set; }
        public string LinkAxie { get; set; }
        public int? IdCompra { get; set; }
        public int? IdVenta { get; set; }

        public virtual Compra IdCompraNavigation { get; set; }
        public virtual Venta IdVentaNavigation { get; set; }
    }
}
