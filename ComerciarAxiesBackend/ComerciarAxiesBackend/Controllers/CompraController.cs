using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ComerciarAxiesBackend.Models;
using ComerciarAxiesBackend.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ComerciarAxiesBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompraController : ControllerBase
    {
        
        private ICompraService _ics;
       public CompraController( ICompraService ics)
        {  
            _ics = ics;
        }
        [HttpGet]
        public IActionResult GetComprasDetalle()
        {
            RespuestaModel respuestaModel = new RespuestaModel();
            try
            {
               respuestaModel.data = _ics.getComprasDetalle();
                respuestaModel.exito = 1;
            }
            catch(Exception e)
            {
                respuestaModel.exito = 0;
                respuestaModel.mensaje = e.Message;
            }
            
            return Ok(respuestaModel);
        }

        [HttpPost]
        public IActionResult Post([FromBody] CompraModel cm)
        {
            RespuestaModel rm = new RespuestaModel();
            try
            {
                _ics.add(cm);
                rm.exito = 1;
                
            }
            catch(Exception e)
            {
                rm.exito = 0;
                rm.mensaje = e.Message;
            }
            return Ok(rm);
        }

        
    }
}
