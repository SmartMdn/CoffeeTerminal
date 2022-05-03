using System.Windows;
using CoffeeTerminal.ViewModels;
using CoffeeTerminal.Views.Pages;

namespace CoffeeTerminal.Views.Windows
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainFrame.NavigationService.Navigate(new MainPage()
            {
                DataContext = new MainWindowViewModel()
            });
        }

    }

    
}
