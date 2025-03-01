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

    public async Task SendMessageGeneral(string movieId, string userId, string userName, string message)
    {
        var chatMessage = new ChatMessage
        {
            MovieId = movieId,
            UserId = userId,
            UserName = userName,
            Message = message,
            Timestamp = DateTime.UtcNow 
        };

        _context.ChatMessages.Add(chatMessage);
        await _context.SaveChangesAsync();

        await Clients.Group(movieId).SendAsync("ReceiveMessageGeneral", userId, userName, message);
    }

    public async Task<List<ChatMessage>> GetChatHistory(string movieId)
    {
        return await _context.ChatMessages
            .Where(msg => msg.MovieId == movieId)
            .OrderBy(msg => msg.Timestamp) 
            .ToListAsync();
    }
}