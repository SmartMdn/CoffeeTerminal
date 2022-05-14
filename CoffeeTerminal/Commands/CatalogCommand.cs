using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoffeeTerminal.Domain.Models;
using CoffeeTerminal.EntityFramework;
using CoffeeTerminal.EntityFramework.Services;
using CoffeeTerminal.Services;
using CoffeeTerminal.ViewModels;

namespace CoffeeTerminal.Commands
{
    internal class CatalogCommand : AsyncCommandBase
    {
        private readonly CatalogViewModel _viewModel;

        private readonly GenericDataService<Category> _categoriesService = new(new CoffeeTerminalDbContextFactory());
        private readonly GenericDataService<Product> _productsService = new(new CoffeeTerminalDbContextFactory());

        public CatalogCommand(CatalogViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public override async Task ExecuteAsync(object? parameter)
        {
            var entities = await _categoriesService.GetAll();
            var entities1 = await _productsService.GetAll();
            var list = new List<IEnumerable<DomainObject>>();
            list.Add(entities); 
            list.Add(entities1);
            _viewModel.List = list;
        }
    }
}
