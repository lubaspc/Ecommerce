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
        public ApplicationUser Cliente { get; set; }
        public List<DetalleVenta> DetalleVentas { get; set; }
        [Required]
        public MetodosPago MetodoPago { get; set; }
        public DateTime FechaVenta { get; set; }
        public int status { get; set; }

    }
}