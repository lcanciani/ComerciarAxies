using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComerciarAxiesBackend.Models
{
    public class RespuestaModel
    {
        public object data { get; set; }
        public int exito { get; set; }
        public string mensaje { get; set; }
    }
}
