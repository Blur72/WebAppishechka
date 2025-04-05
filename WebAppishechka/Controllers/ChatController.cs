using Microsoft.AspNetCore.Mvc;
using WebAppishechka.Interfaces;
using WebAppishechka.Model;

namespace WebAppishechka.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatController(IChatMessage chatMassage) : Controller
    {
        [HttpGet]
        public async Task<IActionResult> GetAllMessages(int page = 1, int pageSize = 10)
        {
            var messages = await chatMassage.GetAllMessagesAsync(page, pageSize);
            return Ok(messages);
        }

        [HttpGet("Count")]
        public async Task<ActionResult<int>> GetTotalMessageCount()
        {
            var count = await chatMassage.GetTotalMessageCountAsync();
            return Ok(count);
        }


        [HttpGet("movie/{movieId}")]
        public async Task<IActionResult> GetMovieCommentsByMovieId(string movieId)
        {
            var comments = await chatMassage.GetMovieCommentByMovieIdAsync();
            if (comments.Count == 0)
                return NotFound();

            return Ok(comments);
        }

        [HttpPost]
        public async Task<IActionResult> CreateMessage(ChatMessage cm)
        {
            var result = await chatMassage.CreateMessageAsync(cm);
            if (!result)
                return BadRequest("Email already exists");

            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMessage(int id, ChatMessage cm)
        {
            if (id != cm.Id)
                return BadRequest();

            var result = await chatMassage.UpdateMessageAsync(cm);
            if (!result)
                return NotFound();

            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteMessage(int id)
        {
            var result = await chatMassage.DeleteMessageAsync(id);
            if (!result)
                return NotFound();

            return Ok();
        }

        [HttpGet("SearchByTitle")]
        public async Task<IActionResult> GetMessagesByName(string title)
        {
            var movies = await chatMassage.GetMessageByNameAsync(title);

            return Ok(movies);
        }
    }
}