namespace Day5_Sample_toolkit.Models;

public class User
{
    public string Id { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    private DateTime? _dob;

    public DateTime? Dob
    {
        get => _dob;
        set
        {
            DateTime.TryParse(value?.ToString(), out var result);
            _dob = result;
        }
    }

    public string Address { get; set; }

    public string Company { get; set; }

    public string Index { get; set; }
}