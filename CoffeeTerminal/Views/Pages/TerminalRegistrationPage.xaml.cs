using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using CoffeeTerminal.Windows;

namespace CoffeeTerminal.Pages
{
    /// <summary>
    /// Логика взаимодействия для TerminalRegistrationPage.xaml
    /// </summary>
    public partial class TerminalRegistrationPage : Page
    {
        public TerminalRegistrationPage()
        {
            InitializeComponent();
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            string num = "";

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
