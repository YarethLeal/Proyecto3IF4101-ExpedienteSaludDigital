using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto3IF4101Web.Models
{
    public class CitasModel
    {
        public int ID { get; set; }
        public int CEDULA { get; set; }
        public string CENTRO_SALUD { get; set; }
        public DateTime FECHA_CITA { get; set; }
        public string ESPECIALIDAD { get; set; }
        public string DESCRIPCION { get; set; }
    }
}
