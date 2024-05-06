using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Q1.Models;

namespace Q1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private PE_PRN_23FallB5Context _context;

        public MovieController(PE_PRN_23FallB5Context context)
        {
            _context = context;
        }

        [HttpDelete("RemoveMovieFromGenre/{genreId}/{movieId}")]
        public IActionResult RemoveMovie(string genreId, string movieId)
        {
            if (!int.TryParse(genreId, out var gId))
            {
                return BadRequest("Id la dang so");
            }
            if (!int.TryParse(movieId, out var mId))
            {
                return BadRequest("id la dang so");
            }
            var genre = _context.Genres
                .Include(p => p.Movies)
                .FirstOrDefault(p => p.Id == gId);

            if (genre == null)
            {
                return BadRequest("The requested genre could not be found ");
            }

            var movies = genre.Movies.FirstOrDefault(p => p.Id == mId);
            if (movies == null)
            {
                return BadRequest("The requested movie not be found in the list of moives of the requested genre");
            }
            genre.Movies.Remove(movies);
            _context.SaveChanges();

            return Ok();
        }
    }
}

