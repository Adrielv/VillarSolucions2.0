using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Registro2.Entidades;
using System.Data.Entity;

namespace Registro2.DAL
{
    public class Contexto : DbContext 
 
    {
        public DbSet<Persona> Persona { get; set; }
      


        public Contexto() : base ("ConStr")
        { }
    }
}
