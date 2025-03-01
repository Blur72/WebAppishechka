using Microsoft.AspNetCore.Mvc;
using WebAppishechka.Model;
using System.Threading.Tasks;
using System.Collections.Generic;
using WebAppishechka.Service;
using WebAppishechka.Interfaces;

namespace Blazorchik.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserChatController : Controller
    {
        private readonly IUserChat _userChatService;

        public UserChatController(IUserChat userChatService)
        {
            _userChatService = userChatService;
        }

        [HttpGet("userchat/{recipientId}/{senderId}")]
        public async Task<ActionResult<List<UserChat>>> GetMessagesForUser(string recipientId, string senderId)
        {
            var messages = await _userChatService.GetMessagesForUser(recipientId, senderId);
            return Ok(messages);
        }

        [HttpPost("send")]
        public async Task<IActionResult> SendMessage([FromBody] UserChat userChat)
        {
            await _userChatService.SendMessage(userChat.SenderId, userChat.SenderName, userChat.RecipientId, userChat.Message, userChat.ImageUrl);
            return NoContent();
        }
    }
}