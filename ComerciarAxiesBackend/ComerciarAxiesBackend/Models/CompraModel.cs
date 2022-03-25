using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComerciarAxiesBackend.Models
{
    public class CompraModel
    {
        public int idOperacion {get; set;}
        public decimal? montoCompraUsd { get; set; }
        public decimal? montoCompraEth { get; set; }
        public decimal? valorEthCompra { get; set; }
        public decimal? comisionMercado { get; set; }
        public string descripcion { get; set; }
        public string linkAxie { get; set; }
        public DateTime? fechaCompra { get; set; }
        
    }
}
