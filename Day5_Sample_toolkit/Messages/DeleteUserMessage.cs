using Day5_Sample_toolkit.Models;

namespace Day5_Sample_toolkit.Messages
{
    internal class DeleteUserMessage
    {
        public User User { get; }

        public DeleteUserMessage(User user)
        {
            User = user;
        }
    }
}
