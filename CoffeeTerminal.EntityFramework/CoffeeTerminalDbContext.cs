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
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=KOMPUTER;Database=CoffeeTerminalDB;Trusted_Connection=True;");

            base.OnConfiguring(optionsBuilder);
        }


    }
}
