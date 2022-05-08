using System.Windows.Input;
using System.Windows.Navigation;
using CoffeeTerminal.Commands;
using CoffeeTerminal.Services;
using CoffeeTerminal.Stores;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Prism.Mvvm;

namespace CoffeeTerminal.ViewModels;

internal class CatalogViewModel : BindableBase
{
    public CatalogViewModel(NavigationStore navigationStore)
    {
        NavigateCommand = new NavigateCommand<RegistrationViewModel>(
            new NavigationService<RegistrationViewModel>(navigationStore,
                () => new RegistrationViewModel(navigationStore)));
    }

    public ICommand NavigateCommand { get; }
}