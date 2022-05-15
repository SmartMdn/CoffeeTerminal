using System;
using CoffeeTerminal.Stores;
using Prism.Mvvm;

namespace CoffeeTerminal.Services;

internal class NavigationService<TViewModel> where TViewModel : BindableBase
{
    private readonly Func<TViewModel> _createViewModel;
    private readonly NavigationStore _navigationStore;

    public NavigationService(NavigationStore navigationStore, Func<TViewModel> createViewModel)
    {
        _navigationStore = navigationStore;
        _createViewModel = createViewModel;
    }

    public void Navigate()
    {
        _navigationStore.CurrentViewModel = _createViewModel();
    }
}