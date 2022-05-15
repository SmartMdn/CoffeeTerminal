using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace CoffeeTerminal.EntityFramework;

public class CoffeeTerminalDbContextFactory : IDesignTimeDbContextFactory<CoffeeTerminalDbContext>
{
    public CoffeeTerminalDbContext CreateDbContext(string[] args)
    {
        return CreateDbContext();
    }

    public CoffeeTerminalDbContext CreateDbContext()
    {
        var options = new DbContextOptionsBuilder<CoffeeTerminalDbContext>();
        //options.UseSqlServer("Server=KOMPUTER;Database=CoffeeTerminalDB;Trusted_Connection=True;");
        options.UseSqlServer("Server=HOME-PC\\SQLEXPRESS;Database=CoffeeTerminalDB;Trusted_Connection=True;");

        return new CoffeeTerminalDbContext(options.Options);
    }
}