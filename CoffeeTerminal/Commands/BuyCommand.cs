using System;
using System.Windows;

namespace CoffeeTerminal.Commands
{
    public class BuyCommand : CommandBase
    {
        private readonly int _price;
        public BuyCommand(int price)
        {
            _price = price;
        }
        public override void Execute(object? parameter)
        {
            MessageBox.Show($"Стоимость:{_price}р.\nСледуйте инструкциям на терминале.");
        }
    }
}
