using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

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

    private void ButtonsBase_OnClick(object sender, RoutedEventArgs e)
    {
        Button1.IsChecked = false;
        Button2.IsChecked = false;
        Button3.IsChecked = false;
        ((ToggleButton)sender).IsChecked = true;
    }
}