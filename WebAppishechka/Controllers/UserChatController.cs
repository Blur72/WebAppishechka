using Microsoft.AspNetCore.Mvc;
using WebAppishechka.Interfaces;
using WebAppishechka.Model;

namespace WebAppishechka.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserChatController(IUserChat userChatService) : Controller
    {
        [HttpGet("userchat/{recipientId}/{senderId}")]
        public async Task<ActionResult<List<UserChat>>> GetMessagesForUser(string recipientId, string senderId)
        {
            var messages = await userChatService.GetMessagesForUser(recipientId, senderId);
            return Ok(messages);
        }

        [HttpPost("send")]
        public async Task<IActionResult> SendMessage([FromBody] UserChat userChat)
        {
            await userChatService.SendMessage(userChat.SenderId, userChat.SenderName, userChat.RecipientId, userChat.Message);
            return NoContent();
        }
    }
}