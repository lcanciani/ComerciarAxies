using ComerciarAxiesBackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ComerciarAxiesBackend.Services;
using ComerciarAxiesBackend.Models.Context;

namespace ComerciarAxiesBackend.Services
{
    public class DashboardService : IDashboardService
    {
        public List<OperacionModel> getOperaciones()
        {
            var listaOperacicones = new List<OperacionModel>();

           using(var cAInfinity = new AxieInfinityContext())
            {
                try
                {
                    var query = from det in cAInfinity.DetalleOperacions
                                 join c in cAInfinity.Compras on det.IdCompra equals c.IdCompra
                                join v in cAInfinity.Ventas on det.IdVenta equals v.IdVenta
                                select new OperacionModel
                                {
                                    idOperacion = det.IdOperacion,
                                    valorEth =  det.ValorEth,
                                    comisionMercado =  det.ComisionMercado,
                                    montoComisionOperacion=  det.MontoComisionOperacion,
                                    montoComisionOperacionEth = det.MontoComisionOperacionEth,
                                    gananciaUsd =  det.GananciaUsd,
                                    gananciaEth =  det.GananciaEth,
                                    descripcion = det.Descripcion,
                                    linkAxie = det.LinkAxie,
                                    idCompra = c.IdCompra,
                                    montoCompraUsd =  c.MontoCompraUsd,
                                    montoCompraEth =  c.MontoCompraEth,
                                    valorEthCompraHistorico =  c.ValorEth,
                                    fechaCompra =  c.FechaCompra,
                                    idVenta = v.IdVenta,
                                    montoVentaUsd =  v.MontoVentaUsd,
                                    montoVentaEth =  v.MontoVentaEth,
                                    valorEthVentaHistorico =  v.ValorEth,
                                    fechaVenta = v.FechaVenta
                                };
                    listaOperacicones = query.ToList();
                    return listaOperacicones;
                }
                catch(Exception e)
                {
                    
                    throw new Exception(e.Message);
                }
            }


            
        }
    }
}
