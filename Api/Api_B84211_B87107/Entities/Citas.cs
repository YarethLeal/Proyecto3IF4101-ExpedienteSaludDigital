using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Api_B84211_B87107.Entities
{
    public class Citas
    {
        [Key]
        public int id { get; set; }
        public int cedula { get; set; }
        public string centro_salud { get; set; }
        public string fecha { get; set; }
        public string especialidad { get; set; }
        public string descripción { get; set; }
        public string codigo { get; set; }

    }
}
