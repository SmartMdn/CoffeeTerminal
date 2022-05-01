using System.Windows;
using System.Windows.Controls;
using CoffeeTerminal.ViewModels;
using CoffeeTerminal.Views.Windows;
using CoffeeTerminal;

namespace CoffeeTerminal.Views.Pages
{
    /// <summary>
    /// Логика взаимодействия для TerminalRegistrationPage.xaml
    /// </summary>
    public partial class TerminalRegistrationPage : Page
    {
        public TerminalRegistrationPage()
        {
            InitializeComponent();
            this.DataContext = new MainWindowViewModel();
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            if (TextBox.Text.Length == 15) return;
            FrameworkElement? frmElement = e.Source as FrameworkElement;
            TextBox.Text += frmElement?.Name switch 
            {
                "Button1" => "1",
                "Button2" => "2",
                "Button3" => "3",
                "Button4" => "4",
                "Button5" => "5",
                "Button6" => "6",
                "Button7" => "7",
                "Button8" => "8",
                "Button9" => "9",
                "Button10" => "10",
                _ => ""
            };
        }

        private void EditClick(object sender, RoutedEventArgs e)
        {
            if (TextBox.Text.Length == 0) return;

            string str = TextBox.Text;
            TextBox.Text = str.Remove(TextBox.Text.Length-1);
        }

        private void RegistrationClick(object sender, RoutedEventArgs e)
        {
            /*TODO Create Registration with WebAPI*/
            Catalog catalogWindow = new Catalog();
            catalogWindow.Show();
        }
    }

    
}
