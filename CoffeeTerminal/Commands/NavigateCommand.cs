using CoffeeTerminal.Services;
using Prism.Mvvm;

namespace CoffeeTerminal.Commands;

internal class NavigateCommand<TViewModel> : CommandBase where TViewModel : BindableBase
{
    private readonly NavigationService<TViewModel> _navigationService;


    public NavigateCommand(NavigationService<TViewModel> navigationService)
    {
        _navigationService = navigationService;
    }

    public override void Execute(object? parameter)
    {
        _navigationService.Navigate();
    }
}