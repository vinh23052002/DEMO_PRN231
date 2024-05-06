using API.Dtos;
using API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Route("api/Director")]
    [ApiController]
    public class DirectorsController : ControllerBase
    {
        private readonly PE_PRN_Fall22B1Context _context;

        public DirectorsController(PE_PRN_Fall22B1Context context)
        {
            _context = context;
        }

        [HttpGet("GetDirector/{id}")]
        public IActionResult GetDirector(int id)
        {
            var response = _context.Directors
                .Include(p => p.Movies)
                .ThenInclude(p => p.Producer)
                .Where(p => p.Id == id)
                .Select(p => new DirectorsResponse
                {
                    Id = p.Id,
                    Description = p.Description,
                    Nationality = p.Nationality,
                    Dob = p.Dob,
                    FullName = p.FullName,
                    Male = p.Male,
                    Movies = p.Movies
                    .Select(o => new MovieResponse
                    {
                        Id = o.Id,
                        Description = o.Description,
                        DirectorId = o.Id,
                        Language = o.Language,
                        ProducerId = o.ProducerId,
                        ReleaseDate = o.ReleaseDate,
                        Title = o.Title,
                        DirectorName = p.FullName,
                        ProducerName = o.Producer.Name,
                        RelatedYear = int.Parse(o.ReleaseDate.Value.ToString("yyyy")),
                        //Stars = o.Stars.Select(p => new StarsResponse { }).ToList(),
                        //Genres = new List<GenraResponse> { new GenraResponse { } }

                    }).ToList()
                }); ;

            return Ok(response);
        }

        [HttpGet("GetDirector/{nationallity}/{gender}")]
        public IActionResult GetDirector(string nationallity, string gender)
        {
            bool isMale = gender.ToLower().Equals("male");

            var response = _context.Directors
                .Include(p => p.Movies)
                .Where(p => p.Nationality.Equals(nationallity) && p.Male.Equals(isMale))
                .Select(p => new DirectorResponse2
                {
                    Nationality = p.Nationality,
                    Description = p.Description,
                    Dob = p.Dob,
                    FullName = p.FullName,
                    Gender = p.Male ? "Male" : "Female",
                    Id = p.Id,
                    DobString = p.Dob.ToString()
                });

            return Ok(response);
        }
        [HttpPost("Create")]
        public IActionResult Create(DirectorsRequest request)
        {
            var director = new Director()
            {
                Description = request.Description,
                Dob = request.Dob,
                FullName = request.FullName,
                Male = request.Male,
                Nationality = request.Nationality,


            };

            try
            {
                _context.Directors.Add(director);
                _context.SaveChanges();
            }
            catch
            {
                return BadRequest("There is an error while addding");
            };

            return Ok("1");
        }

    }


}
