using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Api_B84211_B87107.Entities
{
    public class Vacunas
    {
        [Key]
        public int id { get; set; } 
        public int cedula { get; set; }
        public string vacuna { get; set; }
        public string descripcion { get; set; }
        public string  fecha_aplicacion{ get; set; }
        public string fecha_prox_dos { get; set; }

    }
}
