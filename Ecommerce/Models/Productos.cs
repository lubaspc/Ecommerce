using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Ecommerce.Models
{
    public class Productos
    {
        public int Id { set; get; }
        [StringLength(120,ErrorMessage ="As eccedido el tamaño permitido")] [Required(ErrorMessage = "Es nesesario el nombre")]
        public string Nombre { get; set; }
        [StringLength(120)] 
        public string Descripcion { get; set; }

        [StringLength(120)] 
        public string Url_image { get; set; }
        [StringLength(120)]
        public string Sabor { get; set; }

        [StringLength(120)] 
        public string Marca { get; set; }
        public double Costo_unitario { get; set; }
        public int Porcentage_descuento { get; set; }
        public int Status { get; set; }
       
        public double Precio_final { get; set; }

        public List<Catalogos> Categorias { set; get; }
        public List<DetalleVenta> DetalleVentas { set; get; }
        public List<DetalleCompras> DetalleCompra { set; get; }

    }
}