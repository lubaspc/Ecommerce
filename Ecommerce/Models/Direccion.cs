﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerce.Models
{
    public class Direccion
    {
        [Key]
        public int Id { get; set; }
        public string Estado { get; set; }
        public string Municipio { get; set; }
        public int CodigoPostal { get; set; }
        public string Colonia { get; set; }
        public string Calle { get; set; }
        public int NoInterior { get; set; }
        public int NoExterior { get; set; }
        public string Referencia { get; set; }
        
        public virtual Provedores Provedores { get; set; }

        public virtual ApplicationUser User { get; set; }

    }
}