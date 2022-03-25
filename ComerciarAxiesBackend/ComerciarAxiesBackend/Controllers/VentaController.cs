using ComerciarAxiesBackend.Models;
using ComerciarAxiesBackend.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ComerciarAxiesBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentaController : ControllerBase
    {
        private IVentaService _ventaService;
        public VentaController(IVentaService ventaService)
        {
            _ventaService = ventaService;
        }
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        
        [HttpPost]
        public IActionResult Post([FromBody] VentaModel ventaModel)
        {
            RespuestaModel respuestaModel = new RespuestaModel();
            try
            {
                respuestaModel.exito = 1;

                _ventaService.add(ventaModel);
            }
            catch(Exception e)
            {
                respuestaModel.exito = 0;
                respuestaModel.mensaje = e.Message;
            }
            return Ok(respuestaModel);
        }

        
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
