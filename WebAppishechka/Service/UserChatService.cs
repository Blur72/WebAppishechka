using Microsoft.EntityFrameworkCore;
using WebAppishechka.DataBaseContext;
using WebAppishechka.Interfaces;
using WebAppishechka.Model;

namespace WebAppishechka.Service
{
    public class UserChatService : IUserChat
    {
        private readonly ContextDB _context;

        public UserChatService(ContextDB context)
        {
            _context = context;
        }

        public async Task<List<UserChat>> GetMessagesForUser(string recipientId, string senderId)
        {
            return await _context.UserChat
                .Where(msg =>
                    (msg.RecipientId == recipientId && msg.SenderId == senderId) ||
                    (msg.RecipientId == senderId && msg.SenderId == recipientId))
                .ToListAsync();
        }

        public async Task SendMessage(string senderId, string senderName, string recipientId, string message, string imageUrl = null)
        {
            var chatMessage = new UserChat
            {
                SenderId = senderId,
                SenderName = senderName,
                RecipientId = recipientId,
                Message = message,
                ImageUrl = imageUrl,
                Timestamp = DateTime.UtcNow
            };

            await _context.UserChat.AddAsync(chatMessage);
            await _context.SaveChangesAsync();
        }
    }
}