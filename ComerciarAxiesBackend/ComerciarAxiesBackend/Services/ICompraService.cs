using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ComerciarAxiesBackend.Models;
namespace ComerciarAxiesBackend.Services
{
    public interface ICompraService
    {
        public void add(CompraModel model);

        public List<CompraModel> getComprasDetalle();
    }
}
