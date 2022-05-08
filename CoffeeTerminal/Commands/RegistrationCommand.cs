using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Navigation;
using CoffeeTerminal.Services;
using CoffeeTerminal.Stores;
using CoffeeTerminal.ViewModels;

namespace CoffeeTerminal.Commands 
{
    internal class RegistrationCommand : CommandBase
    {
        private readonly NavigationService<CatalogViewModel> _navigationService;
        private readonly RegistrationViewModel _viewModel;


        public RegistrationCommand(NavigationService<CatalogViewModel> navigationService, RegistrationViewModel viewModel)
        {
            _navigationService = navigationService;
            _viewModel = viewModel;
        }

        public override void Execute(object? parameter)
        {
            MessageBox.Show($"Registration in {_viewModel.Id}...");
            _navigationService.Navigate();
        }
    }
}
