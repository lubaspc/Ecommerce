namespace Ecommerce.Models
{
    public class MetodosPago
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public Ventas Ventas { get; set; }
        public Compras Compras { get; set; }
    }
}