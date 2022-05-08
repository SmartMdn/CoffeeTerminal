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

        Registration = new DelegateCommand(()=>
        {
            if (string.IsNullOrEmpty(Id))
            {
                MessageBox.Show("Вы не ввели Id");
                return;
            }

            if (Id.Length < 9)
            {
                MessageBox.Show("Id короче 9 символов");
                return;
            }
            
            if(!_model.Registration(Id)) return;

            RegistrationCommand =
                new RegistrationCommand(
                    new NavigationService<CatalogViewModel>(navigationStore,
                        () => new CatalogViewModel(navigationStore)), new RegistrationViewModel(navigationStore));
            RegistrationCommand.Execute(navigationStore);
        });
    }

    public DelegateCommand<string?> AddCommand { get; }
    public DelegateCommand EditCommand { get; }
    public string Id {
        get => _model.Id;
        set => _model.Id = value;
    }
    public DelegateCommand Registration { get; }
    public ICommand RegistrationCommand { get; set; }
}