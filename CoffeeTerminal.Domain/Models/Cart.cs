namespace CoffeeTerminal.Domain.Models
{
    internal class Cart
    {

        public int Id { get; set; }
        public List<Product> Products { get; set; }
        public int TotalPrice { get; set; }
    }
}
