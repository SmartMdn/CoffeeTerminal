using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using CoffeeTerminal.Models;
using Prism.Commands;
using Prism.Mvvm;

namespace CoffeeTerminal.ViewModels
{
    internal class RegistrationViewModel : BindableBase
    {
        readonly RegistrationModel _model = new();
        public RegistrationViewModel()
        {
            _model.PropertyChanged += (s, e) => RaisePropertyChanged(e.PropertyName);

            AddCommand = new DelegateCommand<string?>(str =>
            {
                _model.Add(str);
            });

            EditCommand = new DelegateCommand(() => _model.Edit());

            Registrate = new DelegateCommand<string?>(str =>
            {
                if (string.IsNullOrEmpty(str))
                {
                    MessageBox.Show("Вы не ввели Id");
                    return;
                }

                if (str.Length < 9)
                {
                    MessageBox.Show("Id короче 9 символов");
                    return;
                }
                _model.Registration(str);
            });
        }

        public DelegateCommand<string?> AddCommand { get; }
        public DelegateCommand EditCommand { get; }
        public string Id => _model.Id;
        private DelegateCommand<string?> Registrate { get; }

    }
}
