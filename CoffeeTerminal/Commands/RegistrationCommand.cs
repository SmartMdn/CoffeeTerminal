using System.Threading.Tasks;
using System.Windows;
using CoffeeTerminal.EntityFramework;
using CoffeeTerminal.EntityFramework.Services;
using CoffeeTerminal.Services;
using CoffeeTerminal.ViewModels;

namespace CoffeeTerminal.Commands;

internal class RegistrationCommand : AsyncCommandBase
{
    private readonly NavigationService<CatalogViewModel> _navigationService;

    private readonly RegistrationService _registrationService = new(new CoffeeTerminalDbContextFactory());
    private readonly RegistrationViewModel _viewModel;

    public RegistrationCommand(NavigationService<CatalogViewModel> navigationService, RegistrationViewModel viewModel)
    {
        _navigationService = navigationService;
        _viewModel = viewModel;
    }

    public override async Task ExecuteAsync(object? parameter)
    {
        if (_viewModel.Id == null)
        {
            MessageBox.Show("Поле пустое");
            return;
        }
        if (_viewModel.Id.Length != 9)
        {
            MessageBox.Show("Ввёдыннй Id неверной длины. Введите 9-тизначный Id");
            return;
        }

        if (!await _registrationService.Registration(_viewModel.Id))
        {
            MessageBox.Show("Введён неверный Id. Уточните верный у поставщика");
            return;
        }

        MessageBox.Show("Регистрация прошла успешно");
        _navigationService.Navigate();
    }
}