using Microsoft.EntityFrameworkCore;
using WebAppishechka.Model;


namespace WebAppishechka.DataBaseContext
{
    public class ContextDB : DbContext
    {
        public ContextDB(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> User { get; set; }
        public DbSet<Movie> Movie { get; set; }
        public DbSet<ChatMessage> ChatMessages { get; set; }
        public DbSet<UserChat> UserChat { get; set; }
    }
}
