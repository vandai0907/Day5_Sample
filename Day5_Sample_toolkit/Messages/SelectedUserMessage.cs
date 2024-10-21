using Day5_Sample_toolkit.Models;

namespace Day5_Sample_toolkit.Messages;

public class SelectedUserMessage
{
    public User User { get; }

    public SelectedUserMessage(User user)
    {
        User = user;
    }
}