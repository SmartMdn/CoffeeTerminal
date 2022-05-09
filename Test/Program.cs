using System.Threading.Channels;
using CoffeeTerminal.Domain.Models;
using CoffeeTerminal.Domain.Services;
using CoffeeTerminal.EntityFramework;
using CoffeeTerminal.EntityFramework.Services;

IDataService<Product> userService = new GenericDataService<Product>(new CoffeeTerminalDbContextFactory());

userService.Create(new Product()
    { CategoryId = 1, Count = 5, Description = "frfer", Name = "fsdgsd", IsAvailable = true, Price = 1 });
Console.WriteLine("f2");