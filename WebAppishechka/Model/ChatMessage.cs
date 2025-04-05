using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppishechka.Model
{
    public class ChatMessage
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey("Movie")]
        public string MovieId { get; set; } = ""; // Идентификатор фильма

        [Required]
        [ForeignKey("User")] // Указывает, что это внешний ключ
        public string UserId { get; set; } // Идентификатор пользователя (ключ)


        [Required]
        public string UserName { get; set; } // Имя пользователя

        [Required]
        public string Message { get; set; } // Текст сообщения

        [Required]
        public DateTime Timestamp { get; set; } // Время отправки сообщения
    }
}