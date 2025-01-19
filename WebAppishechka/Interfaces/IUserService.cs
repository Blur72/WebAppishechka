using WebAppishechka.Requests;
using System.Threading.Tasks;
using WebAppishechka.Model;
using Microsoft.AspNetCore.Mvc;


namespace WebAppishechka.Interfaces
{
    public interface IUserService
    {
        Task<List<User>> GetAllUsersAsync();
        Task<User> GetUserByIdAsync(int id);
        Task<bool> CreateUserAsync(User user);
        Task<bool> UpdateUserAsync(User user);
        Task<bool> DeleteUserAsync(int id);
        Task<User> AuthenticateAsync(string email, string password);
    }
}
