using Microsoft.AspNetCore.Mvc;
using WebAppishechka.DataBaseContext;
using WebAppishechka.Interfaces;
using WebAppishechka.Model;
using WebAppishechka.Requests;
using BCrypt.Net;
using Microsoft.EntityFrameworkCore;

namespace WebAppishechka.Service
{
    public class ChatService : IChatMessage
    {
        private readonly ContextDB _context;
        public ChatService(ContextDB context)
        {
            _context = context;
        }
        public async Task<List<ChatMessage>> GetAllMessagesAsync()
        {
            return await _context.ChatMessages.ToListAsync();
        }
        public async Task<bool> CreateMessageAsync(ChatMessage cm)
        {
            _context.ChatMessages.Add(cm);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateMessageAsync(ChatMessage cm)
        {
            var existingMessage = await _context.ChatMessages.FindAsync(cm.Id);
            if (existingMessage == null)
                return false;

            existingMessage.MovieId = cm.MovieId;
            existingMessage.UserId = cm.UserId;
            existingMessage.UserName = cm.UserName;
            existingMessage.Message = cm.Message;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteMessageAsync(int id)
        {
            var mess = await _context.ChatMessages.FindAsync(id);
            if (mess == null)
                return false;

            _context.ChatMessages.Remove(mess);
            await _context.SaveChangesAsync();
            return true;
        }


        public async Task<List<ChatMessage>> GetMovieCommentByMovieIdAsync(string movieId)
        {
            return await _context.ChatMessages
                                 .Where(mc => mc.MovieId == movieId)
                                 .ToListAsync();
        }
    }
}
