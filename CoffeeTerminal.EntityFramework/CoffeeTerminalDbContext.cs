using CoffeeTerminal.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace CoffeeTerminal.EntityFramework;

public class CoffeeTerminalDbContext : DbContext
{
    public CoffeeTerminalDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Terminal> Terminals { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
}