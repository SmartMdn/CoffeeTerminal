using System;
using CoffeeTerminal.Commands;
using CoffeeTerminal.Domain.Models;
using Prism.Mvvm;

namespace CoffeeTerminal.ViewModels;

public class CoffeeExampleViewModel : BindableBase
{
    private string? _imagePath;
    private string _price;
    private string? _text;

    public CoffeeExampleViewModel(Product product)
    {
        Text = product.Name;
        ImagePath = product.ImagePath;
        Price = product.Price.ToString();
        BuyCommand = new BuyCommand(product.Price);

    }

    private CoffeeExampleViewModel()
    {
    }

    public string? Text
    {
        get => _text;
        set
        {
            _text = value;
            RaisePropertyChanged();
        }
    }

    public string? ImagePath
    {
        get => _imagePath;
        set
        {
            _imagePath = value;
            RaisePropertyChanged();
        }
    }

    public string Price
    {
        get => _price;
        set
        {
            _price = $"Цена: {value}р";
            RaisePropertyChanged();
        }
    }

    public BuyCommand BuyCommand { get; }
}