using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoffeeTerminal.Domain.Models;
using CoffeeTerminal.EntityFramework;
using CoffeeTerminal.EntityFramework.Services;
using CoffeeTerminal.ViewModels;

namespace CoffeeTerminal.Commands;

internal class CatalogCommand : AsyncCommandBase
{
    private readonly GenericDataService<Category> _categoriesService = new(new CoffeeTerminalDbContextFactory());
    private readonly GenericDataService<Product> _productsService = new(new CoffeeTerminalDbContextFactory());
    private readonly CatalogViewModel _viewModel;

    public CatalogCommand(CatalogViewModel viewModel)
    {
        _viewModel = viewModel;
    }

    public override async Task ExecuteAsync(object? parameter)
    {
        var entities = await _categoriesService.GetAll();
        var entities1 = await _productsService.GetAll();
        var list = new List<IEnumerable<DomainObject>>();
        var coffeeExamplesList = new List<CoffeeExampleViewModel>();
        var itemProducts = entities1.ToList();
        foreach (var itemProduct in itemProducts) coffeeExamplesList.Add(new CoffeeExampleViewModel(itemProduct));
        _viewModel.CoffeeExampleList = coffeeExamplesList;
        _viewModel.Size = coffeeExamplesList.Count;
        list.Add(entities);
        list.Add(itemProducts);
        _viewModel.List = list;
    }
}