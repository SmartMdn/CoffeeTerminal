using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Windows;
using CoffeeTerminal.Domain.Models;
using CoffeeTerminal.ViewModels;

namespace CoffeeTerminal.Commands;

internal class SortingCommand : CommandBase
{
    private readonly CatalogViewModel _catalogViewModel;
    private readonly List<bool> _buttonsStates = new();
    private List<Product> _products;

    public SortingCommand(CatalogViewModel catalogViewModel)
    {
        _catalogViewModel = catalogViewModel;
        _buttonsStates.Add(catalogViewModel.Button1IsChecked);
        _buttonsStates.Add(catalogViewModel.Button2IsChecked);
        _buttonsStates.Add(catalogViewModel.Button3IsChecked);
    }

    public override void Execute(object? parameter)
    {
        _products = (List<Product>)_catalogViewModel.List[1];
        IEnumerable<Product> result = new List<Product>();
        var coffeeExamplesList = new List<CoffeeExampleViewModel>();
        if (_catalogViewModel.Button1IsChecked)
        {
            result = _products.Where(p => p.CategoryId == 1 );
        }
        if (_catalogViewModel.Button2IsChecked)
        {
            result = _products.Where(p => p.CategoryId == 2);
        }
        if (_catalogViewModel.Button3IsChecked)
        {
            result = _products.Where(p => p.CategoryId == 3);
        }
        foreach (var itemProduct in result) coffeeExamplesList.Add(new CoffeeExampleViewModel(itemProduct));
        _catalogViewModel.CoffeeExampleList = coffeeExamplesList;
        _catalogViewModel.Size = coffeeExamplesList.Count;
    }
}