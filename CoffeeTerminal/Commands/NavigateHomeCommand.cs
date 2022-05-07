using CoffeeTerminal.Stores;
using CoffeeTerminal.ViewModels;

namespace CoffeeTerminal.Commands;

internal class NavigateHomeCommand : CommandBase
{
    private readonly NavigationStore _navigationStore;

    public NavigateHomeCommand(NavigationStore navigationStore)
    {
        _navigationStore = navigationStore;
    }

    public override void Execute(object? parameter)
    {
        _navigationStore.CurrentViewModel = new RegistrationViewModel(_navigationStore);
    }
}