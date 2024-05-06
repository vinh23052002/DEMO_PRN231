using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Q1.Dtos;
using Q1.Models;

namespace Q1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StartController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly PE_PRN_23FallB5Context _context;

        public StartController(PE_PRN_23FallB5Context context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        [HttpGet("GetStarts/{nationality}/{gender}")]
        public IActionResult GetStartBy(string nationality, string gender)
        {
            Boolean isMale = gender.ToLower().Trim().Equals("male");
            var starts = _context.Stars
                .Where(p => p.Nationality.ToLower().Trim().Equals(nationality.ToLower().Trim()) && p.Male.Equals(isMale))
                .ToList();

            var response = _mapper.Map<List<StarResponse>>(starts);
            return Ok(response);
        }

        [HttpGet("GetStar/{id}")]
        public IActionResult GetStartByID(int id)
        {
            var starts = _context.Stars
                .Include(p => p.Movies)
                .SingleOrDefault(p => p.Id == id);

            var response = _mapper.Map<StartResponse2>(starts);

            return Ok(response);
        }
    }
}
