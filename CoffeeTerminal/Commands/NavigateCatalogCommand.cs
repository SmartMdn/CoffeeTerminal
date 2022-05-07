using CoffeeTerminal.Stores;
using CoffeeTerminal.ViewModels;

namespace CoffeeTerminal.Commands;

internal class NavigateCatalogCommand : CommandBase
{
    private readonly NavigationStore _navigationStore;

    public NavigateCatalogCommand(NavigationStore navigationStore)
    {
        _navigationStore = navigationStore;
    }

    public override void Execute(object? parameter)
    {
        _navigationStore.CurrentViewModel = new CatalogViewModel(_navigationStore);
    }
}