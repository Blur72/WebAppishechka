using WebAppishechka.Model;

namespace WebAppishechka.Interfaces
{
    public interface IChatMessage
    {
        Task<List<ChatMessage>> GetAllMessagesAsync(int page = 1, int pageSize = 10);
        Task<bool> CreateMessageAsync(ChatMessage cm);
        Task<bool> UpdateMessageAsync(ChatMessage cm);
        Task<bool> DeleteMessageAsync(int id);
        Task<List<ChatMessage>> GetMovieCommentByMovieIdAsync();
        Task<int> GetTotalMessageCountAsync();
        Task<List<ChatMessage>> GetMessageByNameAsync(string title);
    }
}
