using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Registro2.Entidades
{
   public  class Cargos
    {
        [Key]
        
        public int CargoId { get; set; }
        
        public string Descripcion { get; set; }

        public Cargos()
        {
            CargoId = 0;
            Descripcion = string.Empty;
        }
    }
}
