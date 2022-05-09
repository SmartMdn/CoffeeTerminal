using System.Windows;
using System.Windows.Input;
using CoffeeTerminal.Commands;
using CoffeeTerminal.Models;
using CoffeeTerminal.Services;
using CoffeeTerminal.Stores;
using Prism.Commands;
using Prism.Mvvm;

namespace CoffeeTerminal.ViewModels;

internal class RegistrationViewModel : BindableBase
{
    private readonly RegistrationModel _model = new();

    public RegistrationViewModel(NavigationStore navigationStore)
    {
        
        _model.PropertyChanged += (s, e) => RaisePropertyChanged(e.PropertyName);

        AddCommand = new DelegateCommand<string?>(str =>
        {
            if (str != null) _model.Add(str);
        });

        EditCommand = new DelegateCommand(() => _model.Edit());

        Registration =
            new RegistrationCommand(
                new NavigationService<CatalogViewModel>(navigationStore, () => new CatalogViewModel(navigationStore)),
                this);
    }

    public DelegateCommand<string?> AddCommand { get; }
    public DelegateCommand EditCommand { get; }
    public string Id {
        get => _model.Id;
        set => _model.Id = value;
    }
    public RegistrationCommand Registration { get; set; }
}