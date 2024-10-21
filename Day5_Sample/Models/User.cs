using Day5_Sample.ViewModels;

namespace Day5_Sample.Models
{
    public class User : BaseViewModel
    {
        public string Id
        {
            get => _id;
            set
            {
                _id = value;
                OnPropertyChanged();
            }
        }

        public string FirstName
        {
            get => _firstName;
            set
            {
                _firstName = value;
                OnPropertyChanged();
            }
        }

        public string LastName
        {
            get => _lastName;
            set
            {
                _lastName = value;
                OnPropertyChanged();
            }
        }

        private DateTime? _dob;
        private string _id;
        private string _firstName;
        private string _lastName;
        private string _address;
        private string _company;
        private string _index;

        public DateTime? Dob
        {
            get => _dob;
            set
            {
                DateTime.TryParse(value?.ToString(), out var result);
                _dob = result;
                OnPropertyChanged();
            }
        }

        public string Address
        {
            get => _address;
            set
            {
                _address = value;
                OnPropertyChanged();
            }
        }

        public string Company
        {
            get => _company;
            set
            {
                _company = value;
                OnPropertyChanged();
            }
        }

        public string Index
        {
            get => _index;
            set
            {
                _index = value;
                OnPropertyChanged();
            }
        }

        public User()
        {
        }
    }
}
