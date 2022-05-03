using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using CoffeeTerminal.Models;
using Prism.Commands;
using Prism.Mvvm;
using System.Windows.Input;

namespace CoffeeTerminal.ViewModels
{
    internal class MainWindowViewModel : BindableBase
    {
        public BindableBase CurrentViewModel { get; }

        public MainWindowViewModel()
        {
            CurrentViewModel = new RegistrationViewModel();
        }
    }
}
