using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Models
{
    public class Compras
    {
        public int Id { get; set; }
        public virtual ICollection<DetalleCompras> DetallesCompras { get; set; }
        [Required]
        public virtual MetodosPago MetodosPago { get; set; }
        [Required]
        public virtual Provedores Provedores { get; set; }
        public DateTime FechaCompra { get; set; }
        public double Total { get; set; }
    }
}