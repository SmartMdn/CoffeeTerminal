using System;
using Prism.Mvvm;

namespace CoffeeTerminal.Stores;

public class NavigationStore
{
    private BindableBase _currentViewModel;

    public BindableBase CurrentViewModel
    {
        get => _currentViewModel;
        set
        {
            _currentViewModel = value;
            OnCurrentViewModelChanged();
        }
    }

    public event Action CurrentViewModelChanged;

    private void OnCurrentViewModelChanged()
    {
        CurrentViewModelChanged?.Invoke();
    }
}