namespace CoffeeTerminal.Domain.Models;

public class Product : DomainObject
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public int Price { get; set; }
    public Category? Category { get; set; }
    public int CategoryId { get; set; }
    public string? ImagePath { get; set; }
}