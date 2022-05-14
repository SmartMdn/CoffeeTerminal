using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using CoffeeTerminal.Commands;
using CoffeeTerminal.Domain.Models;
using CoffeeTerminal.EntityFramework;
using CoffeeTerminal.EntityFramework.Services;
using CoffeeTerminal.Services;
using CoffeeTerminal.Stores;
using Prism.Mvvm;

namespace CoffeeTerminal.ViewModels;

internal class CatalogViewModel : BindableBase
{
    public CatalogViewModel(NavigationStore navigationStore)
    {
        NavigateCommand = new NavigateCommand<RegistrationViewModel>(
            new NavigationService<RegistrationViewModel>(navigationStore,
                () => new RegistrationViewModel(navigationStore)));
        CatalogCommand = new CatalogCommand(this);
    }

    private readonly GenericDataService<Category> _categoriesService =
        new GenericDataService<Category>(new CoffeeTerminalDbContextFactory());

    public List<IEnumerable<DomainObject>> _list = new();

    public List<IEnumerable<DomainObject>> List
    {
        get => _list;
        set
        {
            _list = value;
            SetCategories();
        }
    }

    private void SetProducts()
    {
        throw new NotImplementedException();
    }

    #region SelectedCategory
    private string _selectedCategory;
    public string SelectedCategory
    {
        get => _selectedCategory;
        set
        {
            if (value != this._selectedCategory)
                _selectedCategory = value;
            this.RaisePropertyChanged("SelectedCategory");
        }
    }
    #endregion SelectedCategory

    #region Categories
    private ObservableCollection<string> _categories;
    public ObservableCollection<string> Categories
    {
        get => _categories;
        set
        {
            if (value != this._categories)
                _categories = value;
            this.RaisePropertyChanged("Categories");
        }
    }
    #endregion Categories

    private void SetCategories()
    {
        _categories = new ObservableCollection<string>();
        foreach (var item in List[0])
        {
            _categories.Add(((Category)item).Name);
        }
        RaisePropertyChanged("Categories");
    }

    public ICommand NavigateCommand { get; }
    public CatalogCommand CatalogCommand { get; }

    public EventArgs CatalogCreateIvent
    {
        get { throw new NotImplementedException(); }
    }
}