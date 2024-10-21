using Day5_Sample.Models;
using System.Windows.Input;

namespace Day5_Sample.ViewModels;

public class FormUserViewModel : BaseViewModel
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
        Mediator.ViewModelClickChanged += UserChange;
        Mediator.ViewModelAddCommandChanged += UserChange;
    }

    private void UserChange(User user)
    {
        this.User = user;
    }

    private void OnDeleteClick(User user)
    {
        Mediator.OnViewModelDeleteCommandChanged(user);
    }

    private void OnSaveClick(User user)
    {
        Mediator.OnViewModelSaveCommandChanged(User);
    }
}