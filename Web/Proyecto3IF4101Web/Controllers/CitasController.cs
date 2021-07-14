using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Proyecto3IF4101Web.Controllers
{
    public class CitasController : Controller
    {
        public IActionResult Cita()
        {
            return View();
        }
    }
}
