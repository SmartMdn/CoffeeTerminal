using System.Windows;
using CoffeeTerminal.Views.Pages.CatalogPages;

namespace CoffeeTerminal.Views.Windows
{
    /// <summary>
    /// Логика взаимодействия для Catalog.xaml
    /// </summary>
    public partial class Catalog : Window
    {
        public Catalog()
        {
            InitializeComponent();
            MainFrame.NavigationService.Navigate(new MainPage());
        }
    }
}
