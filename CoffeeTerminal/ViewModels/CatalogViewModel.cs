using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Windows.Input;
using CoffeeTerminal.Commands;
using CoffeeTerminal.Domain.Models;
using CoffeeTerminal.EntityFramework;
using CoffeeTerminal.EntityFramework.Services;
using CoffeeTerminal.Services;
using CoffeeTerminal.Stores;
using Prism.Commands;
using Prism.Mvvm;

namespace CoffeeTerminal.ViewModels;

internal class CatalogViewModel : BindableBase
{
    private bool _button1IsChecked;
    private bool _button2IsChecked;
    private bool _button3IsChecked;
    private IEnumerable<Product> _products;

    private List<CoffeeExampleViewModel> _coffeeExampleList;

    private List<IEnumerable<DomainObject>> _list = new();

    private int _size = 1;

    public CatalogViewModel(NavigationStore navigationStore)
    {
        NavigateCommand = new NavigateCommand<RegistrationViewModel>(
            new NavigationService<RegistrationViewModel>(navigationStore,
                () => new RegistrationViewModel(navigationStore)));
        CatalogCommand = new CatalogCommand(this);
        SortingCommand = new SortingCommand(this);

    }

    public bool Button1IsChecked
    {
        get => _button1IsChecked;
        set
        {

            _button1IsChecked = value;
            RaisePropertyChanged();
        }
    }

    public bool Button2IsChecked
    {
        get => _button2IsChecked;
        set
        {
            _button2IsChecked = value;
            RaisePropertyChanged();
        }
    }

    public bool Button3IsChecked
    {
        get => _button3IsChecked;
        set
        {
            _button3IsChecked = value;
            RaisePropertyChanged();
        }
    }

    public List<CoffeeExampleViewModel> CoffeeExampleList
    {
        get => _coffeeExampleList;
        set
        {
            _coffeeExampleList = value;
            RaisePropertyChanged();
        }
    }


    public IEnumerable<Product> Products
    {
        get => _products;
        set
        {
            _products = value;
            RaisePropertyChanged();
        }
    }

    public List<IEnumerable<DomainObject>> List
    {
        get => _list;
        set
        {
            _list = value;
            RaisePropertyChanged();
        }
    }

    public ICommand NavigateCommand { get; }
    public ICommand CatalogCommand { get; }

    public int Size
    {
        get => _size;
        set
        {
            if (value % 4 != 0)
                _size = value / 4 + 1;
            else
                _size = value / 4;
            RaisePropertyChanged();
        }
    }

    public SortingCommand SortingCommand { get; }
}