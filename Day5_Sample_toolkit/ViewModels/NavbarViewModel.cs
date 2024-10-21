using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using Day5_Sample_toolkit.Messages;
using Day5_Sample_toolkit.Models;
using System.Collections.ObjectModel;

namespace Day5_Sample_toolkit.ViewModels;

public class NavbarViewModel : ObservableObject
{
    private ObservableCollection<User> _originListUsers;
    private ObservableCollection<User> _listUser;

    public ObservableCollection<User> ListUser
    {
        get => _listUser;
        set
        {
            _listUser = value;
            OnPropertyChanged();
        }
    }

    private User _selectedUser;

    public User SelectedUser
    {
        get => _selectedUser;
        set
        {
            _selectedUser = value;
            OnPropertyChanged();
            WeakReferenceMessenger.Default.Send(new SelectedUserMessage(value));
        }
    }

    public NavbarViewModel()
    {
        InitData();
        WeakReferenceMessenger.Default.Register<NavbarViewModel, DeleteUserMessage>(this, Mediator_ViewModelDeleteCommandChanged);
        WeakReferenceMessenger.Default.Register<NavbarViewModel, SaveUserMessage>(this, Mediator_ViewModelSaveCommandChanged);
        WeakReferenceMessenger.Default.Register<NavbarViewModel, KeySearch>(this, Mediator_ViewModelSearchChanged);
    }

    private void Mediator_ViewModelSearchChanged(NavbarViewModel recipient, KeySearch message)
    {
        ListUser = new ObservableCollection<User>(_originListUsers.Where(u => u.FirstName.Contains(message.Key) || u.LastName.Contains(message.Key)));
    }

    private void Mediator_ViewModelSaveCommandChanged(NavbarViewModel recipient, SaveUserMessage message)
    {
        var checkExist = _originListUsers.FirstOrDefault(u => u.Id == message.User?.Id);
        if (checkExist is not null)
        {
            _originListUsers[_originListUsers.IndexOf(checkExist)] = message.User;
        }
        else
        {
            message.User = message.User ?? new User();
            message.User.Id = $"User {_originListUsers.Count() + 1}";
            _originListUsers.Add(message.User);
        }

        ListUser = new ObservableCollection<User>(_originListUsers);
    }

    private void Mediator_ViewModelDeleteCommandChanged(NavbarViewModel recipient, DeleteUserMessage message)
    {
        var checkExist = _originListUsers.FirstOrDefault(u => u.Id == message.User?.Id);
        if (checkExist is not null)
        {
            _originListUsers.Remove(checkExist);
        }

        ListUser = _originListUsers;
    }

    private void InitData()
    {
        _originListUsers = new ObservableCollection<User>()
        {
            new User()
            {
                Id = "User 1",
                FirstName = "A",
                LastName = "Nguyen Van",
                Dob = DateTime.Now,
                Address = "Viet Nam",
                Company = "Galaxy VN",
                Index = "12345"
            },
            new User()
            {
                Id = "User 2",
                FirstName = "B",
                LastName = "Nguyen ",
                Dob = DateTime.Now,
                Address = "Viet Nam",
                Company = "Galaxy VN",
                Index = "12345"
            },new User()
            {
                Id = "User 3",
                FirstName = "C",
                LastName = "Nguyen ",
                Dob = DateTime.Now,
                Address = "Viet Nam",
                Company = "Galaxy VN",
                Index = "12345"
            },
        };
        ListUser = _originListUsers;
    }
}