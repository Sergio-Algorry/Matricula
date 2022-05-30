using Matricula.BD.Data.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matricula.BD.Data
{
    /// <summary>
    /// REpresentación de la Base de datos
    /// </summary>
    public class dbcontext : DbContext
    {

        public DbSet<Medico> Medicos { get; set; }
        public DbSet<Especialidad> Especialidades { get; set; }

        public dbcontext(DbContextOptions options) : base(options)
        {
        }
    }
}
