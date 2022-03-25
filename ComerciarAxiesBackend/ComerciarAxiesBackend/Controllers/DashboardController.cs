using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ComerciarAxiesBackend.Services;
using ComerciarAxiesBackend.Models;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ComerciarAxiesBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        private IDashboardService _IDashboardService;
        public DashboardController(IDashboardService iDS)
        {
            _IDashboardService = iDS;
        }
        // GET: api/<OperacionController>
        [HttpGet]
        public IActionResult Get()
        {

            RespuestaModel respuestaModel = new RespuestaModel();
            try
            {
               respuestaModel.data = _IDashboardService.getOperaciones();
                respuestaModel.exito = 1;
            }
            catch(Exception e)
            {
                respuestaModel.exito = 0;
                respuestaModel.mensaje = e.Message;
            }
            return Ok(respuestaModel);
        }

        // GET api/<OperacionController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<OperacionController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<OperacionController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<OperacionController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
