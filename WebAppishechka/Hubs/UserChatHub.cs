using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using WebAppishechka.DataBaseContext;
using WebAppishechka.Model;

public class UserChatHub : Hub
{
    private readonly ContextDB _context;

    public UserChatHub(ContextDB context)
    {
        _context = context;
    }

    public async Task SendMessage(string recipientId, string senderId, string senderName, string message)
    {
        var personalMessage = new UserChat
        {
            SenderId = senderId,
            SenderName = senderName,
            RecipientId = recipientId,
            Message = message,
            Timestamp = DateTime.UtcNow
        };

        await _context.UserChat.AddAsync(personalMessage);
        await _context.SaveChangesAsync();

        var connectionId = Context.ConnectionId;
        await Clients.User(recipientId).SendAsync("ReceiveMessage", senderId, senderName, message);
    }

    public async Task<List<UserChat>> GetChatHistory(string userId1, string userId2)
    {
        return await _context.UserChat
            .Where(msg => (msg.RecipientId == userId1 && msg.SenderId == userId2) ||
                          (msg.RecipientId == userId2 && msg.SenderId == userId1))
            .OrderBy(msg => msg.Timestamp)
            .ToListAsync();
    }
}