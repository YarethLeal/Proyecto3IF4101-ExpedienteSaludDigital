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
    public class VacunasController : Controller
    {

        public IConfiguration Configuration { get; }

        public VacunasController(IConfiguration configuration)
        {
            Configuration = configuration;
        }


        [HttpGet("{cedula}")]
        public IEnumerable<Vacunas> Get(int cedula)
        {
            List<Vacunas> vacunas = new List<Vacunas>();
            if (ModelState.IsValid)
            {
                string connectionString = Configuration["ConnectionStrings:ConnectionString"];
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string sqlQuery = $"exec [dbo].[sp_SELECT_VACUNA_PACIENTE] @param_CEDULA={cedula}";
                    using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                    {
                        command.CommandType = CommandType.Text;
                        connection.Open();
                        SqlDataReader vacunasReader = command.ExecuteReader();
                        while (vacunasReader.Read())
                        {
                            Vacunas vacunaTemp = new Vacunas();
                            vacunaTemp.id = Int32.Parse(vacunasReader["ID"].ToString());
                            vacunaTemp.cedula = Int32.Parse(vacunasReader["CEDULA"].ToString());
                            vacunaTemp.vacuna = vacunasReader["NOMBRE"].ToString();
                            vacunaTemp.descripcion = vacunasReader["DESCRIPCION"].ToString();
                            vacunaTemp.fecha_aplicacion = vacunasReader["FECHA_APLICACION"].ToString();
                            vacunaTemp.fecha_prox_dos = vacunasReader["FECHA_PROX_DOS"].ToString();
                            vacunas.Add(vacunaTemp);
                        } // while
                        connection.Close();
                    }
                }
            } // if

            return vacunas;
        }
    }


}
