using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ComerciarAxiesBackend.Models;
using ComerciarAxiesBackend.Models.Context;


namespace ComerciarAxiesBackend.Services
{
    public class CompraService: ICompraService
    {
        public void add(CompraModel cm)
        {
            
            using (AxieInfinityContext aIContext = new AxieInfinityContext())
            {
                using(var registrarCompra = aIContext.Database.BeginTransaction())
                {
                    try
                    {
                        var detalleOperacion = new DetalleOperacion();
                        var compra = new Compra();
                        compra.FechaCompra = cm.fechaCompra;
                        compra.MontoCompraUsd = cm.montoCompraUsd;
                        compra.MontoCompraEth = cm.montoCompraEth;
                        compra.ValorEth = cm.valorEthCompra;
                        aIContext.Compras.Add(compra);
                        aIContext.SaveChanges();

                        detalleOperacion.IdCompra = compra.IdCompra;
                        detalleOperacion.IdOperacion = cm.idOperacion;
                        detalleOperacion.ComisionMercado = cm.comisionMercado;
                        detalleOperacion.Descripcion = cm.descripcion;
                        //no se esta cargando el valor de ValorEth
                        detalleOperacion.ValorEth = cm.valorEthCompra;
                        detalleOperacion.LinkAxie = cm.linkAxie;
                        
                        aIContext.DetalleOperacions.Add(detalleOperacion);
                        aIContext.SaveChanges();

                        registrarCompra.Commit();
                    }
                    catch(Exception e)
                    {
                        registrarCompra.Rollback();
                        throw new Exception(e.Message);
                    }
                }
            }
            
        }

        public List<CompraModel> getComprasDetalle()
        {
            using (AxieInfinityContext aIContext = new AxieInfinityContext())
            {
                try
                {
                    var query = from det in aIContext.DetalleOperacions
                                join c in aIContext.Compras on det.IdCompra equals c.IdCompra
                                select new
                                {
                                    det.IdOperacion,
                                    det.LinkAxie,
                                    det.Descripcion,
                                    det.ComisionMercado,
                                    det.ValorEth,
                                    c.MontoCompraUsd,
                                    c.MontoCompraEth,
                                    c.FechaCompra,

                                }
                                into compra
                                select new CompraModel
                                {
                                    idOperacion = compra.IdOperacion,
                                    montoCompraUsd = compra.MontoCompraUsd,
                                    montoCompraEth = compra.MontoCompraEth,
                                    valorEthCompra = compra.ValorEth,
                                    comisionMercado = compra.ComisionMercado,
                                    descripcion = compra.Descripcion,
                                    linkAxie = compra.LinkAxie,
                                    fechaCompra = compra.FechaCompra
                                };
                    return query.ToList();
                }
                catch(Exception e)
                {
                    throw new Exception(e.Message);
                }
            }
        }
    }
}
