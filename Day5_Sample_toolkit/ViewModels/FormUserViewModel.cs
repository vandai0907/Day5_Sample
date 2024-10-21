using Day5_Sample_toolkit.Models;
using System.Windows.Input;

namespace Day5_Sample_toolkit.ViewModels;

public class FormUserViewModel
{
    private User _user = new User();

    public User User
    {
        get => _user;
        set
        {
            _user = value;
        }
    }
    public ICommand SaveCommand { get; }
    public ICommand DeleteCommand { get; }

    public FormUserViewModel()
    {
    }

    private void UserChange(User user)
    {
        this.User = user;
    }

    private void OnDeleteClick(User user)
    {
    }

    private void OnSaveClick(User user)
    {
    }
}