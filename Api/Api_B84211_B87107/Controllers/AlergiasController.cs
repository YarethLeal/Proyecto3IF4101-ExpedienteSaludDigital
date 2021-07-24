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
    public class AlergiasController : Controller
    {

        public IConfiguration Configuration { get; }

        public AlergiasController(IConfiguration configuration)
        {
            Configuration = configuration;
        }


        [HttpGet("{cedula}")]
        public IEnumerable<Alergias> Get(int cedula)
        {
            List<Alergias> alergias = new List<Alergias>();
            if (ModelState.IsValid)
            {
                string connectionString = Configuration["ConnectionStrings:ConnectionString"];
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string sqlQuery = $"exec sp_SELECT_ALERGIA_PACIENTE @param_CEDULA={cedula}";
                    using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                    {
                        command.CommandType = CommandType.Text;
                        connection.Open();
                        SqlDataReader alergiaReader = command.ExecuteReader();
                        while (alergiaReader.Read())
                        {
                            Alergias alergiaTemp = new Alergias();
                            alergiaTemp.id = Int32.Parse(alergiaReader["ID"].ToString());
                            alergiaTemp.cedula = Int32.Parse(alergiaReader["CEDULA"].ToString());
                            alergiaTemp.alergia = alergiaReader["NOMBRE"].ToString();
                            alergiaTemp.fecha = alergiaReader["FECHA"].ToString();
                            alergiaTemp.medicamentos = alergiaReader["MEDICAMENTOS"].ToString();
                            alergiaTemp.descripcion = alergiaReader["DESCRIPCION"].ToString();
                            alergias.Add(alergiaTemp);
                        } // while
                        connection.Close();
                    }
                }
            } // if

            return alergias;
        }
    }
}
