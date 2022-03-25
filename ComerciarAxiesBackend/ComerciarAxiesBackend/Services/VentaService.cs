using ComerciarAxiesBackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ComerciarAxiesBackend.Models.Context;

namespace ComerciarAxiesBackend.Services
{
    public class VentaService : IVentaService
    {
        public void add(VentaModel vm)
        {  
            using (var aIContext = new AxieInfinityContext())
            {
                using (var registrarVentaTransaccion = aIContext.Database.BeginTransaction())
                {
                    try
                    {                       
                    var venta = new Venta();
                    venta.MontoVentaUsd = vm.montoVentaEth;
                    venta.MontoVentaEth = vm.montoVentaEth;
                    venta.ValorEth = vm.valorEth;
                    venta.FechaVenta = vm.fechaVenta;
                    aIContext.Ventas.Add(venta);
                    aIContext.SaveChanges();

                    var detalleOperacion = new DetalleOperacion();
                    detalleOperacion = aIContext.DetalleOperacions.Find(vm.idOperacion);
                    detalleOperacion.GananciaUsd = vm.gananciaUsd;
                    detalleOperacion.GananciaEth = vm.gananciaEth;
                    detalleOperacion.IdVenta = venta.IdVenta;
                    aIContext.Entry(detalleOperacion).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    aIContext.SaveChanges();
                    registrarVentaTransaccion.Commit();
                    }
                    catch(Exception e)
                    {
                        registrarVentaTransaccion.Rollback();
                        throw new Exception(e.Message);   
                    }
                }
            }           
        }

        public void get()
        {
            throw new NotImplementedException();
        }

        public void put()
        {
            throw new NotImplementedException();
        }
    }
}
