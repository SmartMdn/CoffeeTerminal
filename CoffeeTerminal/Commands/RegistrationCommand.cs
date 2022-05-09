using System.Threading.Tasks;
using System.Windows;
using CoffeeTerminal.Domain.Models;
using CoffeeTerminal.EntityFramework;
using CoffeeTerminal.EntityFramework.Services;
using CoffeeTerminal.Services;
using CoffeeTerminal.ViewModels;

namespace CoffeeTerminal.Commands 
{
    internal class RegistrationCommand : AsyncCommandBase
    {
        private readonly NavigationService<CatalogViewModel> _navigationService;
        private readonly RegistrationViewModel _viewModel;

        private readonly RegistrationService registrationService =
            new RegistrationService(new CoffeeTerminalDbContextFactory());

        public RegistrationCommand(NavigationService<CatalogViewModel> navigationService, RegistrationViewModel viewModel)
        {
            _navigationService = navigationService;
            _viewModel = viewModel;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            if (!await registrationService.Registration(_viewModel.Id))
            {
                MessageBox.Show("Введён неверный Id. Уточните верный у поставщика");
                return;
            }

            MessageBox.Show("Регистрация прошла успешно");

        }
    }
}
