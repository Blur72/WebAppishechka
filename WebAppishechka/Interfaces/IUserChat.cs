using WebAppishechka.Model;

namespace WebAppishechka.Interfaces
{
    public interface IUserChat
    {
        Task<List<UserChat>> GetMessagesForUser(string recipientId, string senderId);
        Task SendMessage(string senderId, string senderName, string recipientId, string message);
    }
}