using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Api_B84211_B87107.Conexion;
using Api_B84211_B87107.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Api_B84211_B87107.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class UsuarioController : Controller
    {
        public IConfiguration Configuration { get; }

        public UsuarioController(IConfiguration configuration)
        {
            Configuration = configuration;
        }


        [HttpGet("{cedula}")]
        public Usuario Get(int cedula)
        {
            Usuario usuarioInfo = new Usuario();
            if (ModelState.IsValid)
            {
                string connectionString = Configuration["ConnectionStrings:ConnectionString"];
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string sqlQuery = $"exec sp_SELECT_PACIENTE @param_CEDULA={cedula}";
                    using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                    {
                        command.CommandType = CommandType.Text;
                        connection.Open();
                        SqlDataReader datosReader = command.ExecuteReader();

                        while (datosReader.Read())
                        {
                            usuarioInfo.cedula = Int32.Parse(datosReader["CEDULA"].ToString());
                            usuarioInfo.nombre = datosReader["NOMBRE"].ToString();
                            usuarioInfo.edad = Int32.Parse(datosReader["EDAD"].ToString());
                            usuarioInfo.tpSangre = datosReader["TPSANGRE"].ToString();
                            usuarioInfo.estado_civil = datosReader["ESTADOCIVIL"].ToString();
                            usuarioInfo.telefono = Int32.Parse(datosReader["TELEFONO"].ToString());
                            usuarioInfo.domicilio = datosReader["DOMICILIO"].ToString();

                        } // while
                        connection.Close();
                    }
                }
            } // if

            return usuarioInfo;
        }


        [HttpGet("{cedula}/{contrasena}")]
        public int Get(int cedula, string contrasena)
        {
            int verificar = 0;
            if (ModelState.IsValid)
            {
                string connectionString = Configuration["ConnectionStrings:ConnectionString"];
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string sqlQuery = $"exec sp_LOGIN2 @param_CEDULA={cedula}, @param_CONTRASENA='{contrasena}'";
                    using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                    {
                        command.CommandType = CommandType.Text;
                        connection.Open();
                        SqlDataReader verificarReader = command.ExecuteReader();
                        while (verificarReader.Read())
                        {
                            verificar = Int32.Parse(verificarReader["EXISTE"].ToString());

                        } // while
                        connection.Close();
                    }
                }
            } // if

            return verificar;
        }


        [HttpGet("{cedula}/{contrasena}/{num}")]
        public ActionResult Get(int cedula, string contrasena,int num)
        {
            string verificar = "Error";
            if (ModelState.IsValid)
            {
                string connectionString = Configuration["ConnectionStrings:ConnectionString"];
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string sqlQuery = $"exec sp_REGISTRAR @param_CEDULA={cedula}, @param_CONTRASENA='{contrasena}'";
                    using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                    {
                        command.CommandType = CommandType.Text;
                        connection.Open();
                        SqlDataReader verificarReader = command.ExecuteReader();
                        while (verificarReader.Read())
                        {
                            verificar = verificarReader["RESULTADO"].ToString();


                        } // while
                        connection.Close();
                    }
                }
            } // if
            
            return new JsonResult(verificar);
        }

        //[HttpPost]
        //public async Task<string> Post([FromBody] Usuario usuario)
        //{
        //    string verificar = "Error";
        //    if (ModelState.IsValid)
        //    {
        //        string connectionString = Configuration["ConnectionStrings:ConnectionString"];
        //        using (SqlConnection connection = new SqlConnection(connectionString))
        //        {
        //            string sqlQuery = $"exec sp_REGISTRAR @param_CEDULA={usuario.cedula}, @param_CONTRASENA='{usuario.contrasena}'";
        //            using (SqlCommand command = new SqlCommand(sqlQuery, connection))
        //            {
        //                command.CommandType = CommandType.Text;
        //                connection.Open();
        //                SqlDataReader verificarReader = command.ExecuteReader();
        //                while (verificarReader.Read())
        //                {
        //                    verificar = verificarReader["RESULTADO"].ToString();


        //                } // while
        //                connection.Close();
        //            }
        //        }
        //    } // if

        //    return verificar;
        //}

        // PUT (Actulizar) /<ValuesController>/5
        [HttpPut("{cedula}")]
        public ActionResult Put(int cedula, [FromBody] Usuario usuario)
        {

            if (ModelState.IsValid)
            {
                string connectionString = Configuration["ConnectionStrings:ConnectionString"];
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string sqlQuery = $"exec sp_UPDATE_PACIENTE @param_CEDULA={cedula}, @param_ESTADOCIVIL='{usuario.estado_civil}'," +
                        $"@param_TELEFONO={usuario.telefono},@param_DOMICILIO='{usuario.domicilio}'";
                    using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                    {
                        command.CommandType = CommandType.Text;
                        connection.Open();
                        command.ExecuteReader();
                        connection.Close();
                        return Ok();
                    }
                }
            } // if

            return BadRequest();
        }


        //// GET: /<ValuesController>
        //[HttpGet]
        //public IEnumerable<Usuario> Get()
        //{
        //    //return new String[] {"hola", "todos" };
        //  return context.TB_USUARIO.ToList();
        //}

        //// GET /<ValuesController>/5
        //[HttpGet("{cedula}")]
        //public Usuario Get(int cedula)
        //{
        //    var usuario = context.TB_USUARIO.FirstOrDefault(u=> u.cedula == cedula);
        //    return usuario;
        //}

        //// POST /<ValuesController> 'ingresos'
        //[HttpPost]
        //public ActionResult Post([FromBody] Usuario usuario)
        //{
        //    try {
        //        context.TB_USUARIO.Add(usuario);
        //        context.SaveChanges();
        //        return Ok();
        //    }
        //    catch (Exception ex) 
        //    {
        //        return BadRequest();
        //    }
        //}

        //// PUT (Actulizar) /<ValuesController>/5
        //[HttpPut("{cedula}")]
        //public ActionResult Put(int cedula, [FromBody] Usuario usuario)
        //{
        //    if (usuario.cedula == cedula)
        //    {
        //        context.Entry(usuario).State = EntityState.Modified;
        //        context.SaveChanges();
        //        return Ok();
        //    }
        //    else 
        //    {
        //        return BadRequest();
        //    }
        //}

        //// DELETE api/<ValuesController>/5
        //[HttpDelete("{cedula}")]
        //public ActionResult Delete(int cedula)
        //{
        //    var usuario = context.TB_USUARIO.FirstOrDefault(u => u.cedula == cedula);
        //    if (usuario != null)
        //    {
        //        context.TB_USUARIO.Remove(usuario);
        //        context.SaveChanges();
        //        return Ok();
        //    }
        //    else
        //    {
        //        return BadRequest();
        //    }
        //}
    }
}
