using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api_B84211_B87107.Conexion;
using Api_B84211_B87107.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api_B84211_B87107.Controllers
{ 
    [ApiController]
    [Route("[controller]")]

    public class UsuarioController : Controller
    {
        private readonly UsuarioBD context;
        public UsuarioController(UsuarioBD context)
        {
            this.context = context;
        }
        // GET: /<ValuesController>
        [HttpGet]
        public IEnumerable<Usuario> Get()
        {
            //return new String[] {"hola", "todos" };
          return context.TB_USUARIO.ToList();
        }

        // GET /<ValuesController>/5
        [HttpGet("{cedula}")]
        public Usuario Get(int cedula)
        {
            var usuario = context.TB_USUARIO.FirstOrDefault(u=> u.cedula == cedula);
            return usuario;
        }

        // POST /<ValuesController>
        [HttpPost]
        public ActionResult Post([FromBody] Usuario usuario)
        {
            try {
                context.TB_USUARIO.Add(usuario);
                context.SaveChanges();
                return Ok();
            }
            catch (Exception ex) 
            {
                return BadRequest();
            }
        }

        // PUT (Actulizar) /<ValuesController>/5
        [HttpPut("{cedula}")]
        public ActionResult Put(int cedula, [FromBody] Usuario usuario)
        {
            if (usuario.cedula == cedula)
            {
                context.Entry(usuario).State = EntityState.Modified;
                context.SaveChanges();
                return Ok();
            }
            else 
            {
                return BadRequest();
            }
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{cedula}")]
        public ActionResult Delete(int cedula)
        {
            var usuario = context.TB_USUARIO.FirstOrDefault(u => u.cedula == cedula);
            if (usuario != null)
            {
                context.TB_USUARIO.Remove(usuario);
                context.SaveChanges();
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
