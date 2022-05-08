using Prism.Mvvm;

namespace CoffeeTerminal.Models;

internal class RegistrationModel : BindableBase
{
    public string Id;
    public C

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

    public bool Registration(string str)
    {
        
        return true;
    }
}