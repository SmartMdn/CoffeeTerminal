using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CoffeeTerminal.Domain;
using CoffeeTerminal.Domain.Models;

namespace CoffeeTerminal.EntityFramework
{
    public class CoffeeTerminalDbContext : DbContext
    {
        public CoffeeTerminalDbContext(DbContextOptions options) : base(options) { }
        public DbSet<Terminal> Terminals { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
