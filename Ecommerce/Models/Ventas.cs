﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Ecommerce.Models
{
    public class Ventas
    {
        public int DEBITO => 1;
        public int CREDITO => 2;
        public int STATUS_PENDIENTE_PAGO => 1;
        public int STATUS_PAGADO => 2;
        public int STATUS_ENTREGADO => 3;
        public int Id { get; set; }
        public virtual Clientes Cliente { get; set; }
        public virtual ICollection<DetalleVenta> DetalleVentas { get; set; }
        public int Status { get; set; }
        public int TipoPago { get; set; }
        public DateTime FechaVenta { get; set; }
    }
}