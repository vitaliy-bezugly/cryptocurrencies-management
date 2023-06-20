using System;
using System.Windows.Input;

namespace Cryptocurrencies.DesktopUi.Commands;

public class UnParametrizedCommandHandler : ICommand
{
    private readonly Action _execute;
    private readonly Func<bool> _canExecute;
    
    public UnParametrizedCommandHandler(Action execute, Func<bool> canExecute)
    {
        _execute = execute;
        _canExecute = canExecute;
    }
    
    public event EventHandler? CanExecuteChanged
    {
        add => CommandManager.RequerySuggested += value;
        remove => CommandManager.RequerySuggested -= value;
    }
    
    public bool CanExecute(object? parameter)
    {
        var result = _canExecute.Invoke();
        return result;
    }

    public void Execute(object? parameter)
    {
        _execute.Invoke();
    }
}