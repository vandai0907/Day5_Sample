namespace Day5_Sample.Models;

public class Mediator
{
    public delegate void ViewModelSelectChangedEventHandler(User user);
    public static event ViewModelSelectChangedEventHandler ViewModelClickChanged;

    public static void OnViewModelClickChanged(User user)
    {
        ViewModelClickChanged?.Invoke(user);
    }

    public delegate void ViewModelSearchChangedEventHandler(string keySearch);
    public static event ViewModelSearchChangedEventHandler ViewModelSearchChanged;

    public static void OnViewModelSearchChanged(string keySearch)
    {
        ViewModelSearchChanged?.Invoke(keySearch);
    }

    public delegate void ViewModelCommandEventHandler(User user);
    public static event ViewModelCommandEventHandler ViewModelSaveCommandChanged;

    public static void OnViewModelSaveCommandChanged(User user)
    {
        ViewModelSaveCommandChanged?.Invoke(user);
    }

    public static event ViewModelCommandEventHandler ViewModelDeleteCommandChanged;

    public static void OnViewModelDeleteCommandChanged(User user)
    {
        ViewModelDeleteCommandChanged?.Invoke(user);
    }

    public static event ViewModelCommandEventHandler ViewModelAddCommandChanged;

    public static void OnViewModelAddCommandChanged(User user)
    {
        ViewModelAddCommandChanged?.Invoke(user);
    }
}