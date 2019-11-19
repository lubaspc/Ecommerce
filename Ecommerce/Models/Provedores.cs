using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerce.Models
{
    public class Provedores
    {

        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Telefono { get; set; }
        [Required]
        public double Credito { get; set; }
        [Required]
        public double CreditoMax { get; set; }
        public virtual ICollection<Compras> Compras { get; set; }
        [Required]
        public virtual Direccion Direccion { get; set; }
    }
}