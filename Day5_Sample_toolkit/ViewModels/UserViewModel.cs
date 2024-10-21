using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using Day5_Sample_toolkit.Models;
using System.Windows.Input;

namespace Day5_Sample_toolkit.ViewModels;

public class UserViewModel : ObservableObject
{
    public ICommand AddCommand { get; }

    public UserViewModel()
    {
        AddCommand = new RelayCommand(OnAddClick);
    }

    private void OnAddClick()
    {
        WeakReferenceMessenger.Default.Send<User>(new User());
    }
}