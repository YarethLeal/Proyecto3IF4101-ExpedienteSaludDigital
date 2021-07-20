using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Proyecto3IF4101Web.Models;

namespace Proyecto3IF4101Web.Controllers
{
    public class CitasController : Controller
    {
        
    public IConfiguration Configuration { get; }
        public CitasController(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IActionResult Cita()
        {
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
            ViewBag.Pacientes = pacientes;
            return View();
        }


        [HttpPost]
        public IActionResult Registrar(CitasModel citasModel)
        {

            string respuesta = "No Registrado";
            if (ModelState.IsValid)
            {

                string connectionString = Configuration["ConnectionStrings:DB_Connection"];
                var connection = new SqlConnection(connectionString);

                string sqlQuery = $"exec sp_INSERT_CITA_PACIENTE @param_CEDULA={citasModel.CEDULA}," +
                    $" @param_CENTRO_SALUD='{citasModel.CENTRO_SALUD}',@param_FECHA='{citasModel.FECHA_CITA}'" +
                    $",@param_ESPECIALIDAD='{citasModel.ESPECIALIDAD}',@param_CODIGO='{citasModel.CODIGO}'";

                using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                {
                    command.CommandType = CommandType.Text;
                    connection.Open();
                    command.ExecuteReader();
                    respuesta = "Cita de Paciente Registrada";
                    connection.Close();
                    
                }

            } // if

            return new JsonResult(respuesta);
        }

        [HttpPost]
        public IActionResult RecuperarDatosPaciente(CitasModel citasModel)
        {
            List<CitasModel> pacientes = new List<CitasModel>();

            if (ModelState.IsValid)
            {

                string connectionString = Configuration["ConnectionStrings:DB_Connection"];
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string sqlQuery = $"exec sp_SELECT_CITAS_PACIENTE @param_CEDULA = " + citasModel.CEDULA;

                    using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                    {
                        command.CommandType = CommandType.Text;
                        connection.Open();
                        SqlDataReader pacientesReader = command.ExecuteReader();
                        while (pacientesReader.Read())
                        {
                            CitasModel pacienteTemp = new CitasModel();
                            pacienteTemp.ID = Int32.Parse(pacientesReader["ID"].ToString());
                            pacienteTemp.CEDULA = Int32.Parse(pacientesReader["CEDULA"].ToString());
                            pacienteTemp.CENTRO_SALUD = pacientesReader["CENTRO_SALUD"].ToString();
                            pacienteTemp.FECHA_CITA = (DateTime)pacientesReader["FECHA"];
                            pacienteTemp.ESPECIALIDAD = pacientesReader["ESPECIALIDAD"].ToString();
                            pacienteTemp.DESCRIPCION = pacientesReader["DECRIPCION"].ToString();
                            pacientes.Add(pacienteTemp);

                        } // while
                        connection.Close();
                    }

                }

            } // if


            return new JsonResult(pacientes);
        }

        [HttpPost]
        public IActionResult Delete(CitasModel citaModel)
        {
            string respuesta = "No Registrado";
            if (ModelState.IsValid)
            {

                string connectionString = Configuration["ConnectionStrings:DB_Connection"];
                var connection = new SqlConnection(connectionString);

                string sqlQuery = $"exec sp_DELETE_CITA_PACIENTE @param_ID={citaModel.ID}";

                using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                {
                    command.CommandType = CommandType.Text;
                    connection.Open();
                    command.ExecuteReader();
                    connection.Close();
                    respuesta = "Borrado";
                }

            } // if

            return new JsonResult(respuesta);
        }



        [HttpPost]
        public IActionResult Actualizar(CitasModel citaModel)
        {
            string respuesta = "No Actualizado";
            if (ModelState.IsValid)
            {

                string connectionString = Configuration["ConnectionStrings:DB_Connection"];
                var connection = new SqlConnection(connectionString);

                string sqlQuery = $"exec sp_UPDATE_CITA_PACIENTE @param_ID={citaModel.ID},@param_CEDULA={citaModel.CEDULA}," +
                 $" @param_CENTRO_SALUD='{citaModel.CENTRO_SALUD}',@param_FECHA='{citaModel.FECHA_CITA}'" +
                 $",@param_ESPECIALIDAD='{citaModel.ESPECIALIDAD}',@param_DESCRIPCION='{citaModel.DESCRIPCION}'";

                using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                {
                    command.CommandType = CommandType.Text;
                    connection.Open();
                    SqlDataReader actualizarReader = command.ExecuteReader();
                    while (actualizarReader.Read())
                    {

                        respuesta = actualizarReader["RESULTADO"].ToString();

                    } // while
                    connection.Close();
                }

            } // if

            return new JsonResult(respuesta);
        }
    }
}
