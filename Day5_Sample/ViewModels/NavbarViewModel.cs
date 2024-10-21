using Day5_Sample.Models;
using System.Collections.ObjectModel;

namespace Day5_Sample.ViewModels;

public class NavbarViewModel : BaseViewModel
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
            Mediator.OnViewModelClickChanged(value);
        }
    }

    public NavbarViewModel()
    {
        InitData();
        Mediator.ViewModelSearchChanged += Mediator_ViewModelSearchChanged;
        Mediator.ViewModelSaveCommandChanged += Mediator_ViewModelSaveCommandChanged;
        Mediator.ViewModelDeleteCommandChanged += Mediator_ViewModelDeleteCommandChanged;
        Mediator.ViewModelAddCommandChanged += Mediator_ViewModelAddCommandChanged;
    }

    private void Mediator_ViewModelAddCommandChanged(User user)
    {
        SelectedUser = user;
    }

    private void Mediator_ViewModelDeleteCommandChanged(User user)
    {
        var checkExist = _originListUsers.FirstOrDefault(u => u.Id == user?.Id);
        if (checkExist is not null)
        {
            _originListUsers.Remove(checkExist);
        }

        ListUser = _originListUsers;
    }

    private void Mediator_ViewModelSaveCommandChanged(User user)
    {
        var checkExist = _originListUsers.FirstOrDefault(u => u.Id == user?.Id);
        if (checkExist is not null)
        {
            _originListUsers[_originListUsers.IndexOf(checkExist)] = user;
        }
        else
        {
            user = user ?? new User();
            user.Id = $"User {_originListUsers.Count() + 1}";
            _originListUsers.Add(user);
        }

        ListUser = new ObservableCollection<User>(_originListUsers);
    }

    private void Mediator_ViewModelSearchChanged(string keySearch)
    {
        ListUser = new ObservableCollection<User>(_originListUsers.Where(u => u.FirstName.Contains(keySearch) || u.LastName.Contains(keySearch)));
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