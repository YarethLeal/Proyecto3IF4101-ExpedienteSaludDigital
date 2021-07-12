using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;//Identificar el tipo de objeto a manipular en base de datos
using System.Data.SqlClient;//Controlador de acceso a datos
using Proyecto3IF4101Web.Models;
using Microsoft.Extensions.Configuration;//Para acceder al archivo de configuración appsettings.json
using Microsoft.AspNetCore.Http;//Para el manejo de solicitudes y respuestas HTTP

namespace Proyecto3IF4101Web.Controllers
{
    public class LoginController : Controller
    {
        const string SessionUser = "_User";
        public IConfiguration Configuration { get; }
        public LoginController(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public ActionResult Login()
        {
            //ViewBag.ReturnUrl = returnUrl;
            return View(new Usuario());
        }

        [HttpPost]

        //[ValidateAntiForgeryToken]

        public ActionResult Login(Usuario model)
        {

            //Conexión a la base de datos
            string connectionString = Configuration["ConnectionStrings:DB_Connection"];

            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                var list_users = new List<Usuario>();

                if (model.cedula == 0 || model.cedula.Equals("") || model.codigoM == null || model.codigoM.Equals("") ||
                    model.contrasena == null || model.contrasena.Equals(""))
                {
                    ModelState.AddModelError("", "Ingresar los datos solicitados");
                }
                else
                {
                    string sqlQuery = $"exec sp_LOGIN @param_CEDULA='{model.cedula}',@param_CODIGO='{model.codigoM}',@param_CONTRASENA='{model.contrasena}'";
                    using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                    {
                        command.CommandType = CommandType.Text;
                        connection.Open();
                        SqlDataReader userReader = command.ExecuteReader();
                        while (userReader.Read())
                        {
                            if (Convert.ToString(userReader["EXISTE"])=="1")
                            {
                                Usuario clsUsuario = new Usuario();
                                clsUsuario.cedula = Convert.ToInt32(userReader["CEDULA"]);
                                clsUsuario.codigoM = Convert.ToString(userReader["CODIGO"]);
                                clsUsuario.contrasena = Convert.ToString(userReader["CONTRASENA"]);
                                list_users.Add(clsUsuario);
                            }
                            else
                            {
                                Usuario clsUsuario = new Usuario();
                                clsUsuario.cedula = 0;
                                clsUsuario.codigoM = "";
                                clsUsuario.contrasena = "";
                                list_users.Add(clsUsuario);
                            }
                            if (list_users.Any(p => p.codigoM == model.codigoM && p.contrasena == model.contrasena))
                            {
                                connection.Close();
                                HttpContext.Session.SetString(SessionUser, model.codigoM);//Iniciamos la sesión pasando el valor (nombre del usuario)
                                return RedirectToAction("Index", "Home");//Redireccionar a la vista usario (Lista de Usuarios)
                            }
                            else
                            {
                                connection.Close();
                                ModelState.AddModelError("", "Datos ingresado no válido.");//Error personalizado
                            }
                        } // while
                        connection.Close();
                    }
                }
            }
            return View(model);
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            HttpContext.Session.Clear();//Limpiar la sesión
            return RedirectToAction("Login", "Login");//Redireccionar a la vista login
        }
    }
}
