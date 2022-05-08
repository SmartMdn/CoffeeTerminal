namespace CoffeeTerminal.Domain.Models
{
    public class Category : DomainObject
    {

        public string Name { get; set; }
        public List<Product> Products { get; set; }
    }
}
