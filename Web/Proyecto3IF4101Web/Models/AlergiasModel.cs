using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Proyecto3IF4101Web.Models
{
    public class AlergiasModel
    {
        public int ID { get; set; }
        public int ID_ALERGIA { get; set; }
        public int CEDULA { get; set; }
        public string NOMBRE_ALERGIA { get; set; }
        public string DESCRIPCION { get; set; }
        public string FECHA { get; set; }
        public string MEDICAMENTOS { get; set; }


    }

    public class Alergias
    {
        public int ID { get; set; }
        public string NOMBRE { get; set; }
        public string DECRIPCION { get; set; }

    }

   
}
