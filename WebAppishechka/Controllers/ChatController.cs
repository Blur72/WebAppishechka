using Microsoft.AspNetCore.Mvc;
using WebAppishechka.Interfaces;
using WebAppishechka.Model;
using WebAppishechka.Requests;
using WebAppishechka.Service;

namespace WebAppishechka.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatController : Controller
    {
        private readonly IChatMessage _chatMassage;

        public ChatController(IChatMessage chatMassage)
        {
            _chatMassage = chatMassage;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllMessages()
        {
            var users = await _chatMassage.GetAllMessagesAsync();
            return Ok(users);
        }


        [HttpGet("movie/{movieId}")]
        public async Task<IActionResult> GetMovieCommentsByMovieId(string movieId)
        {
            var comments = await _chatMassage.GetMovieCommentByMovieIdAsync(movieId);
            if (comments == null || !comments.Any())
                return NotFound();

            return Ok(comments);
        }

        [HttpPost]
        public async Task<IActionResult> CreateMessage(ChatMessage cm)
        {
            var result = await _chatMassage.CreateMessageAsync(cm);
            if (!result)
                return BadRequest("Email already exists");

            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMessage(int id, ChatMessage cm)
        {
            if (id != cm.Id)
                return BadRequest();

            var result = await _chatMassage.UpdateMessageAsync(cm);
            if (!result)
                return NotFound();

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMessage(int id)
        {
            var result = await _chatMassage.DeleteMessageAsync(id);
            if (!result)
                return NotFound();

            return Ok();
        }
    }
}

































//using Microsoft.AspNetCore.Mvc;
//using System.Collections.Generic;
//using System.Threading.Tasks;
//using WebAppishechka.Model;
//using WebAppishechka.DataBaseContext;
//using Microsoft.EntityFrameworkCore;

//[Route("api/chat")]
//[ApiController]
//public class ChatController : ControllerBase
//{
//    private readonly ContextDB _context;

//    public ChatController(ContextDB context)
//    {
//        _context = context;
//    }

//    [HttpGet("{movieId}")]
//    public async Task<ActionResult<List<ChatMessage>>> GetChatHistory(string movieId)
//    {
//        var messages = await _context.ChatMessages
//            .Where(msg => msg.MovieId == movieId)
//            .OrderBy(msg => msg.Timestamp)
//            .ToListAsync();

//        return Ok(messages);
//    }
//}