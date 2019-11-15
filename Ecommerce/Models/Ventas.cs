using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Ecommerce.Models
{
    public class Ventas
    {
        public int Id { get; set; }
        public virtual ApplicationUser Cliente { get; set; }
        public virtual ICollection<DetalleVenta> DetalleVentas { get; set; }
        [Required]
        public virtual MetodosPago MetodoPago { get; set; }
        public DateTime FechaVenta { get; set; }
        public int Status { get; set; }

    }
}