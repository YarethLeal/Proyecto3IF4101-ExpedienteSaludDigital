using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Api_B84211_B87107.Entities
{
    public class Usuario
    {
        [Key]
        public int cedula { get; set; }
        public string contrasena { get; set; }
        public string nombre { get; set; }
        public int edad { get; set; }
        public string tpSangre { get; set; }
        public string estado_civil { get; set; }
        public int telefono { get; set; }
        public string domicilio { get; set; }

    }
}

