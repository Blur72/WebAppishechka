using WebAppishechka.Model;

namespace WebAppishechka.Interfaces
{
    public interface IChatMessage
    {
        Task<List<ChatMessage>> GetAllMessagesAsync();
        Task<bool> CreateMessageAsync(ChatMessage cm);
        Task<bool> UpdateMessageAsync(ChatMessage cm);
        Task<bool> DeleteMessageAsync(int id);
        Task<List<ChatMessage>> GetMovieCommentByMovieIdAsync(string movieId);
    }
}
