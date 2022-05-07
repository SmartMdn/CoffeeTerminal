using System.Windows;
using System.Windows.Input;
using CoffeeTerminal.Commands;
using CoffeeTerminal.Models;
using CoffeeTerminal.Stores;
using Prism.Commands;
using Prism.Mvvm;

namespace CoffeeTerminal.ViewModels;

internal class RegistrationViewModel : BindableBase
{
    private readonly RegistrationModel _model = new();

    public RegistrationViewModel(NavigationStore navigationStore)
    {
        NavigateCatalogCommand = new NavigateCatalogCommand(navigationStore);
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

            _model.Registration(Id);

            NavigateCatalogCommand.Execute(navigationStore);
        });
    }

    public DelegateCommand<string?> AddCommand { get; }
    public DelegateCommand EditCommand { get; }
    public string Id => _model.Id;
    public DelegateCommand Registration { get; }
    public ICommand NavigateCatalogCommand { get; }
}