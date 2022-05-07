using System.ComponentModel;
using CoffeeTerminal.Stores;
using Prism.Mvvm;

namespace CoffeeTerminal.ViewModels;

internal class MainWindowViewModel : BindableBase
{
    private readonly NavigationStore _navigationStore;

    public MainWindowViewModel(NavigationStore navigationStore)
    {
        _navigationStore = navigationStore;

        _navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;
    }

    public BindableBase CurrentViewModel => _navigationStore.CurrentViewModel;

    private void OnCurrentViewModelChanged()
    {
        OnPropertyChanged(new PropertyChangedEventArgs(nameof(CurrentViewModel)));
    }
}