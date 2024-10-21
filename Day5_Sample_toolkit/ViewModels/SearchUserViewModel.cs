using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using Day5_Sample_toolkit.Messages;

namespace Day5_Sample_toolkit.ViewModels;

public class SearchUserViewModel : ObservableObject
{
    private string _textSearch;
    public string TextSearch
    {
        get => _textSearch;
        set
        {
            _textSearch = value;
            OnPropertyChanged();
            WeakReferenceMessenger.Default.Send(new KeySearch(value));
        }
    }
}