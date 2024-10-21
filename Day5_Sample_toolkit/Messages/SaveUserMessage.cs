using Day5_Sample_toolkit.Models;

namespace Day5_Sample_toolkit.Messages;

public class SaveUserMessage
{
    public User User { get; set; }

    public SaveUserMessage(User user)
    {
        User = user;
    }
}