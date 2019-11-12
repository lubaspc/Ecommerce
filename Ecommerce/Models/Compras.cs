using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Models
{
    public class Compras
    {
        public int Id { get; set; }
        public List<DetalleCompras> DetallesCompras { get; set; }
        [Required]
        public MetodosPago MetodosPago { get; set; }
        [Required]
        public Provedores Provedores { get; set; }
        public DateTime FechaCompra { get; set; }
        public double Total { get; set; }
    }
}