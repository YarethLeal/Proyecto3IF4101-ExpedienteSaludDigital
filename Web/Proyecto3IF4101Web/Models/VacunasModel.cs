using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Proyecto3IF4101Web.Models
{
    public class VacunasModel
    {
        public SelectList VacunasList { get; set; }
        public SelectList PacientesList { get; set; }
        public int ID { get; set; }
        public int ID_VACUNA { get; set; }
        public int CEDULA { get; set; }
        public string NOMBRE_VACUNA { get; set; }
        public string DESCRIPCION { get; set; }
        public string FECHA_APLI { get; set; }
        public string FECHA_PROX { get; set; }


    }

    public class Vacunas
    {
       public int ID { get; set; }
       public string NOMBRE { get; set; }
       public string DECRIPCION { get; set; }

    }

    public class Pacientes
    {
        public int CEDULA { get; set; }
        public string NOMBRE { get; set; }

    }

}
