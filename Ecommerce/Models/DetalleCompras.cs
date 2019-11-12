using System;

namespace Ecommerce.Models
{
    public class DetalleCompras
    {
        public int Id { get; set; }
        public Productos Productos { get; set; }
        public int Cantidad { get; set; }
        public Compras Compras { get; set; }
        public int PorcentajeDescuento { get; set; }
        public int PorcentajeIncremnto { get; set; }
        public double SubTotal { get; set; }
        public DateTime Fecha_vencimiento { get; set; }
    }
}