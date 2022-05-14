using System.Windows;
using System.Windows.Controls;
using CoffeeTerminal.Stores;
using CoffeeTerminal.ViewModels;

namespace CoffeeTerminal.Views.Pages;

/// <summary>
///     Логика взаимодействия для CatalogPage.xaml
/// </summary>
public partial class CatalogPage : UserControl
{
    public CatalogPage()
    {
        InitializeComponent();
    }

    private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
    {
        Button.Visibility = Visibility.Hidden;
    }
}