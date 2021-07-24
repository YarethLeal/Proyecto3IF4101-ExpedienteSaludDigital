using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Api_B84211_B87107.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace Api_B84211_B87107.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class CitasController : Controller
    {

        public IConfiguration Configuration { get; }

        public CitasController(IConfiguration configuration)
        {
            Configuration = configuration;
        }


        [HttpGet("{cedula}")]
        public IEnumerable<Citas> Get(int cedula)
        {
            List<Citas> citas = new List<Citas>();
            if (ModelState.IsValid)
            {
                string connectionString = Configuration["ConnectionStrings:ConnectionString"];
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string sqlQuery = $"exec sp_SELECT_CITAS_PACIENTE @param_CEDULA={cedula}";
                    using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                    {
                        command.CommandType = CommandType.Text;
                        connection.Open();
                        SqlDataReader citasReader = command.ExecuteReader();
                        while (citasReader.Read())
                        {
                            Citas cita = new Citas();
                            cita.id = Int32.Parse(citasReader["ID"].ToString());
                            cita.cedula = Int32.Parse(citasReader["CEDULA"].ToString());
                            cita.centro_salud = citasReader["CENTRO_SALUD"].ToString();
                            cita.fecha = citasReader["FECHA"].ToString();
                            cita.especialidad = citasReader["ESPECIALIDAD"].ToString();
                            cita.descripción = citasReader["DECRIPCION"].ToString();
                            cita.codigo = citasReader["CODIGO"].ToString();
                            citas.Add(cita);
                        } // while
                        connection.Close();
                    }
                }
            } // if

            return citas;
        }
    }
}
