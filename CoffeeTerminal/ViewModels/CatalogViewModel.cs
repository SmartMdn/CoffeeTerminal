using System.Windows.Input;
using CoffeeTerminal.Commands;
using CoffeeTerminal.Stores;
using Prism.Mvvm;

namespace CoffeeTerminal.ViewModels;

internal class CatalogViewModel : BindableBase
{
    public CatalogViewModel(NavigationStore navigationStore)
    {
        NavigateHomeCommand = new NavigateHomeCommand(navigationStore);
    }

    public ICommand NavigateHomeCommand { get; }
}