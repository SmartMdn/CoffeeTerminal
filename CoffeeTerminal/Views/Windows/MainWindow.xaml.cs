using System.Configuration;
using System.Windows;
using CoffeeTerminal.EntityFramework;
using CoffeeTerminal.EntityFramework.Services;
using CoffeeTerminal.Stores;
using CoffeeTerminal.ViewModels;
using CoffeeTerminal.Views.Pages;
using Prism.Mvvm;

namespace CoffeeTerminal.Views.Windows;

/// <summary>
///     Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        var navigationStore = new NavigationStore();
        var registrationService = new RegistrationService(new CoffeeTerminalDbContextFactory());
        BindableBase viewModel;

        if (ConfigurationManager.AppSettings["isRegistered"] == "false") 
            viewModel = new RegistrationViewModel(navigationStore);
        else 
            viewModel = new CatalogViewModel(navigationStore);

        navigationStore.CurrentViewModel = viewModel;

        MainFrame.NavigationService.Navigate(new MainPage
        {
            DataContext = new MainWindowViewModel(navigationStore)
        });
    }
}