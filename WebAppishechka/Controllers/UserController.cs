using Microsoft.AspNetCore.Mvc;
using WebAppishechka.Interfaces;
using WebAppishechka.Model;

namespace WebAppishechka.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController(IUserService userService) : Controller
    {
        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await userService.GetAllUsersAsync();
            return Ok(users);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await userService.GetUserByIdAsync(id);
            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(User user)
        {
            var result = await userService.CreateUserAsync(user);
            if (!result)
                return BadRequest("Email already exists");

            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, User user)
        {
            if (id != user.Id)
                return BadRequest();

            var result = await userService.UpdateUserAsync(user);
            if (!result)
                return NotFound();

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var result = await userService.DeleteUserAsync(id);
            if (!result)
                return NotFound();

            return Ok();
        }

        [HttpPost("authentication")]
        public async Task<IActionResult> Authenticate([FromBody] LoginRequest loginRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var authenticatedUser = await userService.AuthenticateAsync(loginRequest.Email, loginRequest.Password);
            return Ok(authenticatedUser);
        }
    }
}
