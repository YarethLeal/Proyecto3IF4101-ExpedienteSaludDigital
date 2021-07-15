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

        [HttpPost]
        public IActionResult RegistrarAjax(VacunasModel vacunaModel)
        {
            string respuesta = "No Registrado";
            if (ModelState.IsValid)
            {

                string connectionString = Configuration["ConnectionStrings:DB_Connection"];
                var connection = new SqlConnection(connectionString);

                string sqlQuery = $"exec sp_INSERT_VACUNA_PACIENTE @param_CEDULA={vacunaModel.CEDULA}," +
                    $"@param_ID_VACUNA={vacunaModel.ID_VACUNA},@param_FECHA_APLICACION='{vacunaModel.FECHA_APLI}'" +
                    $",@param_FECHA_PROX_DOS='{vacunaModel.FECHA_PROX}',@param_DESCRIPCION='{vacunaModel.DECRIPCION}'";

                using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                {
                    command.CommandType = CommandType.Text;
                    connection.Open();
                    command.ExecuteReader();
                    connection.Close();
                    respuesta = "Aplicacion de Vacuna Registrada";
                }

            } // if

            return new JsonResult(respuesta);
        }


        [HttpPost]
        public IActionResult ObtenerDescripcion(VacunasModel vacunaModel)
        {
            string descripcion = "";

            if (ModelState.IsValid)
            {

                string connectionString = Configuration["ConnectionStrings:DB_Connection"];
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string sqlQuery = $"exec sp_SELECT_VACUNA_ID @param_ID=" + vacunaModel.ID_VACUNA;

                    using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                    {
                        command.CommandType = CommandType.Text;
                        connection.Open();
                        SqlDataReader vacunasReader = command.ExecuteReader();
                        while (vacunasReader.Read())
                        {

                            descripcion = vacunasReader["DECRIPCION"].ToString();

                        } // while
                        connection.Close();
                    }

                }

            } // if

            return new JsonResult(descripcion);
        }

    }
}
