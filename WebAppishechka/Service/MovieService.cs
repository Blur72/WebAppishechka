using Microsoft.EntityFrameworkCore;
using WebAppishechka.DataBaseContext;
using WebAppishechka.Interfaces;
using WebAppishechka.Model;

namespace WebAppishechka.Service
{
    public class MovieService : IMovieService
    {
        private readonly ContextDB _context;

        public MovieService(ContextDB context)
        {
            _context = context;
        }

        public async Task<List<Movie>> GetAllMoviesAsync()
        {
            return await _context.Movie.ToListAsync();
        }

        public async Task<Movie> GetMovieByIdAsync(int id)
        {
            return await _context.Movie.FindAsync(id);
        }


        public async Task<List<Movie>> GetMovieByNameAsync(string title)
        {
            return await _context.Movie.Where(m => m.Title.StartsWith(title)).ToListAsync();
        }

        public async Task<bool> CreateMovieAsync(Movie movie)
        {
            if (await _context.Movie.AnyAsync(m => m.Title == movie.Title))
                return false;

            _context.Movie.Add(movie);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateMovieAsync(Movie movie)
        {
            var existingMovie = await _context.Movie.FindAsync(movie.Id);
            if (existingMovie == null)
                return false;

            existingMovie.Title = movie.Title;
            existingMovie.Description = movie.Description;
            existingMovie.Genre = movie.Genre;
            existingMovie.ReleaseDate = movie.ReleaseDate;
            existingMovie.Rating = movie.Rating;
            existingMovie.ImageUrl = movie.ImageUrl;


            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteMovieAsync(int id)
        {
            var movie = await _context.Movie.FindAsync(id);
            if (movie == null)
            {
                return false;
            }

            _context.Movie.Remove(movie);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}