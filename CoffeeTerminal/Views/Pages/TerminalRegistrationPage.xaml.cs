using System.Windows;
using System.Windows.Controls;
using CoffeeTerminal.ViewModels;
using CoffeeTerminal.Views.Windows;
using CoffeeTerminal;
using System.Windows.Input;
using System;

namespace CoffeeTerminal.Views.Pages;

/// <summary>
/// Логика взаимодействия для TerminalRegistrationPage.xaml
/// </summary>
public partial class TerminalRegistrationPage : Page
{
    public TerminalRegistrationPage()
    {
        InitializeComponent();
        CommandBinding commandBinding = new CommandBinding();
        commandBinding.Command = ApplicationCommands.Help;
        // устанавливаем метод, который будет выполняться при вызове команды
        commandBinding.Executed += CommandBinding_Executed;
        // добавляем привязку к коллекции привязок элемента Button
        EnterButton.CommandBindings.Add(commandBinding);

    }

    private void CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
    {
        /*TODO Create Registration with WebAPI*/
        Catalog catalogWindow = new Catalog();
        catalogWindow.Show();
    }
}