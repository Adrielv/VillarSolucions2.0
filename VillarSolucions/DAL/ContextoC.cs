using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Registro2.Entidades;
using System.Data.Entity;

namespace Registro2.DAL
{
    class ContextoC : DbContext
    {
        public DbSet<Cargos> Cargos { get; set; }

        public ContextoC() : base("ConStr")
        { }
    }
}
