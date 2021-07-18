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
    public class AlergiasController : Controller
    {

        public IConfiguration Configuration { get; }

        public AlergiasController(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IActionResult Alergia()
        {

            List<Alergias> alergias = new List<Alergias>();
            if (ModelState.IsValid)
            {
                string connectionString = Configuration["ConnectionStrings:DB_Connection"];
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string sqlQuery = $"exec sp_SELECT_ALERGIAS";
                    using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                    {
                        command.CommandType = CommandType.Text;
                        connection.Open();
                        SqlDataReader vacunasReader = command.ExecuteReader();
                        while (vacunasReader.Read())
                        {
                            Alergias alergiaTemp = new Alergias();
                            alergiaTemp.ID = Int32.Parse(vacunasReader["ID"].ToString());
                            alergiaTemp.NOMBRE = vacunasReader["NOMBRE"].ToString();
                            alergiaTemp.DECRIPCION = vacunasReader["DECRIPCION"].ToString();
                            alergias.Add(alergiaTemp);
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

            ViewBag.Alergias = alergias;
            ViewBag.Pacientes = pacientes;

            return View();
        }


        [HttpPost]
        public IActionResult ObtenerDescripcion(AlergiasModel alergiaModel)
        {
            string descripcion = "";

            if (ModelState.IsValid)
            {

                string connectionString = Configuration["ConnectionStrings:DB_Connection"];
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string sqlQuery = $"exec sp_SELECT_ALERGIA_ID @param_ID = " + alergiaModel.ID_ALERGIA;

                    using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                    {
                        command.CommandType = CommandType.Text;
                        connection.Open();
                        SqlDataReader alergiaReader = command.ExecuteReader();
                        while (alergiaReader.Read())
                        {

                            descripcion = alergiaReader["DECRIPCION"].ToString();

                        } // while
                        connection.Close();
                    }

                }

            } // if

            return new JsonResult(descripcion);
        }



        [HttpPost]
        public IActionResult Registrar(AlergiasModel alergiaModel)
        {

            string respuesta = "No Registrado";
            if (ModelState.IsValid)
            {

                string connectionString = Configuration["ConnectionStrings:DB_Connection"];
                var connection = new SqlConnection(connectionString);

                string sqlQuery = $"exec sp_INSERT_ALERGIA_PACIENTE @param_CEDULA={alergiaModel.CEDULA}," +
                    $" @param_ID_ALERGIA={alergiaModel.ID_ALERGIA},@param_FECHA='{alergiaModel.FECHA}'" +
                    $",@param_MADICAMENTOS='{alergiaModel.MEDICAMENTOS}',@param_DESCRIPCION='{alergiaModel.DESCRIPCION}'";

                using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                {
                    command.CommandType = CommandType.Text;
                    connection.Open();
                    command.ExecuteReader();
                    connection.Close();
                    respuesta = "Alergia de Paciente Registrada";
                }

            } // if

            return new JsonResult(respuesta);
        }


        [HttpPost]
        public IActionResult RecuperarDatosPaciente(AlergiasModel alergiasModel)
        {
            List<AlergiasModel> pacientes = new List<AlergiasModel>();

            if (ModelState.IsValid)
            {

                string connectionString = Configuration["ConnectionStrings:DB_Connection"];
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string sqlQuery = $"exec sp_SELECT_ALERGIA_PACIENTE @param_CEDULA = " + alergiasModel.CEDULA;

                    using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                    {
                        command.CommandType = CommandType.Text;
                        connection.Open();
                        SqlDataReader pacientesReader = command.ExecuteReader();
                        while (pacientesReader.Read())
                        {
                            AlergiasModel pacienteTemp = new AlergiasModel();
                            pacienteTemp.ID = Int32.Parse(pacientesReader["ID"].ToString());
                            pacienteTemp.CEDULA = Int32.Parse(pacientesReader["CEDULA"].ToString());
                            pacienteTemp.NOMBRE_ALERGIA = pacientesReader["NOMBRE"].ToString();
                            pacienteTemp.FECHA = pacientesReader["FECHA"].ToString();
                            pacienteTemp.MEDICAMENTOS = pacientesReader["MEDICAMENTOS"].ToString();
                            pacienteTemp.DESCRIPCION = pacientesReader["DESCRIPCION"].ToString();
                            pacienteTemp.ID_ALERGIA = Int32.Parse(pacientesReader["ID_ALERGIA"].ToString());
                            pacientes.Add(pacienteTemp);

                        } // while
                        connection.Close();
                    }

                }

            } // if


            return new JsonResult(pacientes);
        }



        [HttpPost]
        public IActionResult Delete(AlergiasModel alergiaModel)
        {
            string respuesta = "No Registrado";
            if (ModelState.IsValid)
            {

                string connectionString = Configuration["ConnectionStrings:DB_Connection"];
                var connection = new SqlConnection(connectionString);

                string sqlQuery = $"exec sp_DELETE_ALERGIA_PACIENTE @param_ID={alergiaModel.ID}";

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
        public IActionResult Actualizar(AlergiasModel alergiaModel)
        {
            string respuesta = "No Actualizado";
            if (ModelState.IsValid)
            {

                string connectionString = Configuration["ConnectionStrings:DB_Connection"];
                var connection = new SqlConnection(connectionString);

                string sqlQuery = $"exec sp_UPDATE_ALERGIA_PACIENTE @param_ID={alergiaModel.ID},@param_CEDULA={alergiaModel.CEDULA}," +
                 $" @param_ID_ALERGIA={alergiaModel.ID_ALERGIA},@param_FECHA='{alergiaModel.FECHA}'" +
                 $",@param_MEDICAMENTOS='{alergiaModel.MEDICAMENTOS}',@param_DESCRIPCION='{alergiaModel.DESCRIPCION}'";

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