using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using Day5_Sample_toolkit.Messages;
using Day5_Sample_toolkit.Models;
using System.Windows.Input;

namespace Day5_Sample_toolkit.ViewModels;

public class FormUserViewModel : ObservableObject
{
    private User _user = new User();

    public User User
    {
        get => _user;
        set
        {
            _user = value;
            OnPropertyChanged();
        }
    }
    public ICommand SaveCommand { get; }
    public ICommand DeleteCommand { get; }

    public FormUserViewModel()
    {
        SaveCommand = new RelayCommand<User>(OnSaveClick);
        DeleteCommand = new RelayCommand<User>(OnDeleteClick);
        WeakReferenceMessenger.Default.Register<SelectedUserMessage>(this, UpdateUser);

    }

    private void UpdateUser(object recipient, SelectedUserMessage message)
    {
        User = message.User;
    }

    private void OnDeleteClick(User user)
    {
        WeakReferenceMessenger.Default.Send(new DeleteUserMessage(user));
    }

    private void OnSaveClick(User user)
    {
        WeakReferenceMessenger.Default.Send(new SaveUserMessage(user));
    }
}