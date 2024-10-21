using Day5_Sample.Models;

namespace Day5_Sample.ViewModels;

public class SearchUserViewModel : BaseViewModel
{
    private string _textSearch;
    public string TextSearch
    {
        get => _textSearch;
        set
        {
            _textSearch = value;
            Mediator.OnViewModelSearchChanged(value);
            OnPropertyChanged();
        }
    }
}