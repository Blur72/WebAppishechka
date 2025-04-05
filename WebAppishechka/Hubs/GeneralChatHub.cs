using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using WebAppishechka.DataBaseContext;
using WebAppishechka.Model;

public class GeneralChatHub : Hub
{
    private readonly ContextDB _context;

    public GeneralChatHub(ContextDB context)
    {
        _context = context;
    }

    public async Task SendMessageGeneral(string userId, string userName, string message)
    {
        var chatMessage = new ChatMessage
        {
            UserId = userId,
            UserName = userName,
            Message = message,
            Timestamp = DateTime.UtcNow
        };

        _context.ChatMessages.Add(chatMessage);
        await _context.SaveChangesAsync();

        // Уведомление всех клиентов о новом сообщении
        await Clients.All.SendAsync("ReceiveMessageGeneral", userId, userName, message);
    }

    public async Task<List<ChatMessage>> GetChatHistory()
    {
        return await _context.ChatMessages
            .OrderBy(msg => msg.Timestamp)
            .ToListAsync();
    }
}