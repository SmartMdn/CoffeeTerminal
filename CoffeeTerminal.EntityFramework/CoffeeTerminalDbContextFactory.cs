using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace CoffeeTerminal.EntityFramework
{
    public class CoffeeTerminalDbContextFactory : IDesignTimeDbContextFactory<CoffeeTerminalDbContext>
    {
        public CoffeeTerminalDbContext CreateDbContext()
        {
            var options = new DbContextOptionsBuilder<CoffeeTerminalDbContext>();
            options.UseSqlServer("Server=KOMPUTER;Database=CoffeeTerminalDB;Trusted_Connection=True;");

            return new CoffeeTerminalDbContext(options.Options);
        }

        public CoffeeTerminalDbContext CreateDbContext(string[] args)
        {
            return CreateDbContext();
        }
    }
}
