namespace CoffeeTerminal.Domain.Models;

internal class Cart
{
    public List<Product> Products { get; set; }
    public int TotalPrice { get; set; }
}