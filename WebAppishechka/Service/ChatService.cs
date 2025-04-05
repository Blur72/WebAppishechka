using WebAppishechka.DataBaseContext;
using WebAppishechka.Interfaces;
using WebAppishechka.Model;
using Microsoft.EntityFrameworkCore;

namespace WebAppishechka.Service
{
    public class ChatService(ContextDB context) : IChatMessage
    {
        public async Task<List<ChatMessage>> GetAllMessagesAsync(int page = 1, int pageSize = 10)
        {
            var messages = await context.ChatMessages
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
            return messages;
        }

        public async Task<int> GetTotalMessageCountAsync()
        {
            return await context.ChatMessages.CountAsync(); // Пример
        }

        public async Task<bool> CreateMessageAsync(ChatMessage cm)
        {
            context.ChatMessages.Add(cm);
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateMessageAsync(ChatMessage cm)
        {
            var existingMessage = await context.ChatMessages.FindAsync(cm.Id);
            if (existingMessage == null)
                return false;

            existingMessage.UserId = cm.UserId;
            existingMessage.UserName = cm.UserName;
            existingMessage.Message = cm.Message;

            await context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteMessageAsync(int id)
        {
            var mess = await context.ChatMessages.FindAsync(id);
            if (mess == null)
                return false;

            context.ChatMessages.Remove(mess);
            await context.SaveChangesAsync();
            return true;
        }


        public async Task<List<ChatMessage>> GetMovieCommentByMovieIdAsync()
        {
            return await context.ChatMessages.ToListAsync();
        }

        public async Task<List<ChatMessage>> GetMessageByNameAsync(string title)
        {
            return await context.ChatMessages.Where(m => m.Message.StartsWith(title)).ToListAsync();
        }
    }
}
