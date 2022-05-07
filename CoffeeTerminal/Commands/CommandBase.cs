﻿using System;
using System.Windows.Input;

namespace CoffeeTerminal.Commands;

internal abstract class CommandBase : ICommand
{
    public bool CanExecute(object? parameter)
    {
        return true;
    }

    public abstract void Execute(object? parameter);

    public event EventHandler? CanExecuteChanged;

    protected void OnCanExecuteChanged()
    {
        CanExecuteChanged?.Invoke(this, EventArgs.Empty);
    }
}