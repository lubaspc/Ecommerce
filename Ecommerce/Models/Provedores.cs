using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerce.Models
{
    public class Provedores
    {
       
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Telefono { get; set; }
        public double Credito { get; set; }
        public double CreditoMax { get; set; }
        public virtual ICollection<Compras> Compras { get; set; }
        public virtual Direccion Direccion { get; set; }
    }
}