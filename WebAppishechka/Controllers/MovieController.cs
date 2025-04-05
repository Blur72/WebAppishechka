using Microsoft.AspNetCore.Mvc;
using WebAppishechka.Interfaces;
using WebAppishechka.Model;

namespace WebAppishechka.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController(IMovieService movieService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAllMovies()
        {
            var movies = await movieService.GetAllMoviesAsync();
            return Ok(movies);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMovieById(int id)
        {
            var movie = await movieService.GetMovieByIdAsync(id);
            return Ok(movie);
        }


        [HttpGet("SearchByTitle")]
        public async Task<IActionResult> GetMoviesByName(string title)
        {
            var movies = await movieService.GetMovieByNameAsync(title);

            return Ok(movies);
        }

        [HttpPost]
        public async Task<IActionResult> CreateMovie(Movie movie)
        {
            var result = await movieService.CreateMovieAsync(movie);
            if (!result)
                return BadRequest("Movie already exists");

            return Ok();
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateMovie(int id, Movie movie)
        {
            if (id != movie.Id)
            {
                return BadRequest();
            }

            var result = await movieService.UpdateMovieAsync(movie);
            if (!result)
            {
                return NotFound();
            }
            return Ok(); // Returns 204 No Content on success
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteMovie(int id)
        {
            var result = await movieService.DeleteMovieAsync(id);
            if (!result)
            {
                return NotFound();
            }
            return Ok(); // Returns 204 No Content on success
        }
    }
}