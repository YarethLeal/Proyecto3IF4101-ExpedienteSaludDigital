using Proyecto3IF4101Web.CustomValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto3IF4101Web.Models
{
    public class Usuario
    {
        public int id { get; set; }

        [Required]

        public int cedula { get; set; }

        [Required]

        public string codigoM { get; set; }

        [Required]

        [ContrasenaValidate(ErrorMessage = "Contraseña no valida")]

        public string contrasena { get; set; }

        public int intentos { get; set; }

        public decimal nivelSeg { get; set; }

        public DateTime? fechaReg { get; set; }
    }
}
