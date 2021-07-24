using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Api_B84211_B87107.Entities
{
    public class Alergias
    {
        [Key]
        public int id { get; set; }
        public int cedula { get; set; }
        public string alergia { get; set; }
        public string fecha { get; set; }
        public string medicamentos { get; set; }
        public string descripcion { get; set; }
    }
}
