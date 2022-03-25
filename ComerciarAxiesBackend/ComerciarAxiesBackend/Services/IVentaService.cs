using ComerciarAxiesBackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComerciarAxiesBackend.Services
{
    public interface IVentaService
    {
        public void add(VentaModel vm);
        public void put();
        public void get();
    }
}
