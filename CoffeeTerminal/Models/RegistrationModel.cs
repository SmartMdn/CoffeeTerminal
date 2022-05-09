using System.Threading.Tasks;
using System.Windows;
using CoffeeTerminal.Domain.Models;
using CoffeeTerminal.Domain.Services;
using CoffeeTerminal.EntityFramework;
using CoffeeTerminal.EntityFramework.Services;
using Prism.Mvvm;

namespace CoffeeTerminal.Models;

internal class RegistrationModel : BindableBase
{
    public string Id;

    public void Add(string str)
    {
        Id += str;
        RaisePropertyChanged("Id");
    }

    public void Edit()
    {
        if (Id.Length == 0) return;
        Id = Id.Remove(Id.Length - 1);
        RaisePropertyChanged("Id");
    }
}