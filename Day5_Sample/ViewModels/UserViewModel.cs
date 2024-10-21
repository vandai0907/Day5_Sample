using Day5_Sample.Models;
using System.Windows.Input;

namespace Day5_Sample.ViewModels
{
    internal class UserViewModel : BaseViewModel
    {
        public ICommand AddCommand { get; }

        public UserViewModel()
        {
            AddCommand = new RelayCommand<User>(OnAddClick);
        }

        private void OnAddClick(User user)
        {
            Mediator.OnViewModelClickChanged(new User());
        }
    }
}
