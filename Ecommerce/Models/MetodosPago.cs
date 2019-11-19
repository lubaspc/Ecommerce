namespace Ecommerce.Models
{
    public class MetodosPago
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public virtual Ventas Ventas { get; set; }
        
    }
}