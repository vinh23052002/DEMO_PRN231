using Dummy_API.DTO;
using Dummy_API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Dummy_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DummyDetailsController : ControllerBase
    {
        private readonly DummyContext _context;

        public DummyDetailsController(DummyContext context)
        {
            _context = context;
        }

        // GET: api/DummyDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DummyDetail>>> GetDummyDetails()
        {
            if (_context.DummyDetails == null)
            {
                return NotFound();
            }
            return await _context.DummyDetails.ToListAsync();
        }

        // GET: api/DummyDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DummyDetail>> GetDummyDetail(int id)
        {
            if (_context.DummyDetails == null)
            {
                return NotFound();
            }
            var dummyDetail = await _context.DummyDetails.FindAsync(id);

            if (dummyDetail == null)
            {
                return NotFound();
            }

            return dummyDetail;
        }
        [HttpPost("Filter")]
        public async Task<ActionResult<DummyDetail>> Filter(FilterRequest req)
        {
            if (_context.DummyDetails == null)
            {
                return NotFound();
            }
            var dummyDetails = await _context.DummyDetails
                                    .Include(p => p.Master)
                                    .Where(p => p.DetailName.ToLower().Contains(req.detail_name.ToLower()) && p.Master.MasterName.ToLower().Contains(req.master_name.ToLower()))
                                    .ToListAsync();

            var res = dummyDetails.Select(p => new DummyDetailResponse
            {
                DetailId = p.DetailId,
                DetailName = p.DetailName,
                MasterId = p.MasterId,
                Master = new DummyMasterResponse
                {
                    MasterId = p.MasterId,
                    MasterName = p.Master.MasterName
                }
            });

            if (dummyDetails == null)
            {
                return NotFound();
            }

            return Ok(res);
        }

        // PUT: api/DummyDetails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDummyDetail(int id, DummyDetail dummyDetail)
        {
            if (id != dummyDetail.DetailId)
            {
                return BadRequest();
            }

            _context.Entry(dummyDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DummyDetailExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/DummyDetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DummyDetail>> PostDummyDetail(DummyDetail dummyDetail)
        {
            if (_context.DummyDetails == null)
            {
                return Problem("Entity set 'DummyContext.DummyDetails'  is null.");
            }
            _context.DummyDetails.Add(dummyDetail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDummyDetail", new { id = dummyDetail.DetailId }, dummyDetail);
        }

        // DELETE: api/DummyDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDummyDetail(int id)
        {
            if (_context.DummyDetails == null)
            {
                return NotFound();
            }
            var dummyDetail = await _context.DummyDetails.FindAsync(id);
            if (dummyDetail == null)
            {
                return NotFound();
            }

            _context.DummyDetails.Remove(dummyDetail);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DummyDetailExists(int id)
        {
            return (_context.DummyDetails?.Any(e => e.DetailId == id)).GetValueOrDefault();
        }
    }
}
