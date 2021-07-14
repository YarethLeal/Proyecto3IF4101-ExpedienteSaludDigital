using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Proyecto3IF4101Web.Models;

namespace Proyecto3IF4101Web.Controllers
{
    public class VacunasController : Controller
    {

        public IConfiguration Configuration { get; }

        public VacunasController(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IActionResult Vacuna()
        {

            List<Vacunas> vacunas = new List<Vacunas>();
            if (ModelState.IsValid)
            {
                string connectionString = Configuration["ConnectionStrings:DB_Connection"];
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string sqlQuery = $"exec sp_SELECT_VACUNAS";
                    using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                    {
                        command.CommandType = CommandType.Text;
                        connection.Open();
                        SqlDataReader vacunasReader = command.ExecuteReader();
                        while (vacunasReader.Read())
                        {
                            Vacunas vacunaTemp = new Vacunas();
                            vacunaTemp.ID = Int32.Parse(vacunasReader["ID"].ToString());
                            vacunaTemp.NOMBRE = vacunasReader["NOMBRE"].ToString();
                            vacunaTemp.DECRIPCION = vacunasReader["DECRIPCION"].ToString();
                            vacunas.Add(vacunaTemp);
                        } // while
                        connection.Close();
                    }
                }
            } // if


            List<Pacientes> pacientes = new List<Pacientes>();
            if (ModelState.IsValid)
            {
                string connectionString = Configuration["ConnectionStrings:DB_Connection"];
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string sqlQuery = $"exec sp_SELECT_CEDULAS";
                    using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                    {
                        command.CommandType = CommandType.Text;
                        connection.Open();
                        SqlDataReader pacientesReader = command.ExecuteReader();
                        while (pacientesReader.Read())
                        {
                            Pacientes pacienteTemp = new Pacientes();
                            pacienteTemp.CEDULA = Int32.Parse(pacientesReader["CEDULA"].ToString());
                            pacienteTemp.NOMBRE = pacientesReader["NOMBRE"].ToString();
                            pacientes.Add(pacienteTemp);
                        } // while
                        connection.Close();
                    }
                }
            } // if

            ViewBag.Vacunas = vacunas;
            ViewBag.Pacientes = pacientes;
            return View();
        }
    }
}
