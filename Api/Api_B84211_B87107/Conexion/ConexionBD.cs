using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api_B84211_B87107.Entities;
using Microsoft.EntityFrameworkCore;

namespace Api_B84211_B87107.Conexion
{
    public class ConexionBD : DbContext
    {
        public ConexionBD(DbContextOptions<ConexionBD> options) : base(options)
        {

        }

        public DbSet<Usuario> TB_USUARIO { get; set; }

    }
}
