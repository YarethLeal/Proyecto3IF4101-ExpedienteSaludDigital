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
    }
}

