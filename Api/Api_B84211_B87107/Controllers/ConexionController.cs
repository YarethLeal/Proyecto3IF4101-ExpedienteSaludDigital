using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api_B84211_B87107.Conexion;
using Api_B84211_B87107.Entities;
using Microsoft.AspNetCore.Mvc;


namespace Api_B84211_B87107.Controllers
{ 
    [ApiController]
    [Route("[controller]")]

    public class ConexionController : Controller
    {
        private readonly ConexionBD context;
        public ConexionController(ConexionBD context)
        {
            this.context = context;
        }
        // GET: api/<ValuesController>
        [HttpGet]
        public IEnumerable<Usuario> Get()
        {
            //return new String[] {"hola", "todos" };
          return context.TB_USUARIO.ToList();
        }

        // GET api/<ValuesController>/5
        [HttpGet("{cedula}")]
        public Usuario Get(int cedula)
        {
            var usuario = context.TB_USUARIO.FirstOrDefault(u=> u.cedula == cedula);
            return usuario;
        }

        // POST api/<ValuesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
