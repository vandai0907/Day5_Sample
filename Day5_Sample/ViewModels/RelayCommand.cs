using System.Windows.Input;
using static System.Windows.Input.CommandManager;

namespace Day5_Sample.ViewModels;

public class RelayCommand<T> : ICommand
{
    private readonly Action<T> _execute = null;
    private readonly Predicate<T> _canExecute = null;

    public RelayCommand(Action<T> execute)
        : this(execute, null)
    {
    }

    public RelayCommand(Action<T> execute, Predicate<T> canExecute)
    {
        _execute = execute ?? throw new ArgumentNullException(nameof(execute));
        _canExecute = canExecute;
    }

    public bool CanExecute(object parameter)
    {
        return _canExecute?.Invoke((T)parameter) ?? true;
    }

    public void Execute(object parameter)
    {
        _execute((T)parameter);
    }


    public event EventHandler CanExecuteChanged
    {
        add => RequerySuggested += value;
        remove => RequerySuggested -= value;
    }
}