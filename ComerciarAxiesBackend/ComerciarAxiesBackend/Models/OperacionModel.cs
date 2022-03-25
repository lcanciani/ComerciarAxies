using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComerciarAxiesBackend.Models
{
    public class OperacionModel
    {
        public int? idOperacion { get; set; }
        public decimal? valorEth { get; set; }
        public decimal? comisionMercado { get; set; }
        public decimal? montoComisionOperacion { get; set; }
        public decimal? montoComisionOperacionEth { get; set; }
        public decimal? gananciaUsd { get; set; }
        public decimal? gananciaEth { get; set; }
        public string? descripcion { get; set; }
        public string? linkAxie { get; set; }
        public int? idCompra { get; set; }
        public decimal? montoCompraUsd { get; set; }
        public decimal? montoCompraEth { get; set; }
        public decimal? valorEthCompraHistorico { get; set; }
        public DateTime? fechaCompra { get; set; }
        public int? idVenta { get; set; }
        public decimal? montoVentaUsd { get; set; }
        public decimal? montoVentaEth { get; set; }
        public decimal? valorEthVentaHistorico { get; set; }
        public DateTime? fechaVenta { get; set; }

    }
}
