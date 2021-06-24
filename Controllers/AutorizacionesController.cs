using CfaAPI.IServices;
using CfaAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CfaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutorizacionesController : ControllerBase
    {

        private IAutorizacionesService _oAutorizacionesService;

        public AutorizacionesController(IAutorizacionesService oAutorizacionesService)
        {
            _oAutorizacionesService = oAutorizacionesService;

        
        }

        // GET: api/<AutorizacionesController>
        [HttpGet("{ClaTrabajadorSesion}/{ClaUsuarioMod}/{IdToken}/{txtBuscar}/{NombrePcMod}/{Idioma}")]
        public IEnumerable<Autorizaciones> Get(int ClaTrabajadorSesion, int ClaUsuarioMod, string IdToken, string txtBuscar = null, string NombrePcMod = null, string Idioma = null)
        {
            if (txtBuscar == "''")
            {
                txtBuscar = string.Empty;
            }

            return _oAutorizacionesService.Gets(ClaTrabajadorSesion,ClaUsuarioMod,IdToken,txtBuscar,NombrePcMod,Idioma);

        }

        // GET api/<AutorizacionesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<AutorizacionesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<AutorizacionesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AutorizacionesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
