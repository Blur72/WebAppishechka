using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppishechka.Model
{
    public class UserChat
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [ForeignKey("User")]
        public string SenderId { get; set; }
        [Required]
        public string SenderName { get; set; }
        [Required]
        [ForeignKey("User")]
        public string RecipientId { get; set; }
        [Required]
        public string Message { get; set; }
        [Required]
        public DateTime Timestamp { get; set; }
    }
}