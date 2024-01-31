using Dummy_API.DTO;
using Dummy_API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Dummy_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DummyMastersController : ControllerBase
    {
        private readonly DummyContext _context;

        public DummyMastersController(DummyContext context)
        {
            _context = context;
        }

        // GET: api/DummyMasters
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DummyMasterResponse>>> GetDummyMasters()
        {
            if (_context.DummyMasters == null)
            {
                return NotFound();
            }
            return await _context.DummyMasters
                .Select(p => new DummyMasterResponse
                {
                    MasterName = p.MasterName,
                    MasterId = p.MasterId,
                })
                .ToListAsync();
        }

        // GET: api/DummyMasters/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DummyMaster>> GetDummyMaster(int id)
        {
            if (_context.DummyMasters == null)
            {
                return NotFound();
            }
            var dummyMaster = await _context.DummyMasters.FindAsync(id);

            if (dummyMaster == null)
            {
                return NotFound();
            }

            return dummyMaster;
        }

        // PUT: api/DummyMasters/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDummyMaster(int id, DummyMaster dummyMaster)
        {
            if (id != dummyMaster.MasterId)
            {
                return BadRequest();
            }

            _context.Entry(dummyMaster).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DummyMasterExists(id))
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

        // POST: api/DummyMasters
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DummyMaster>> PostDummyMaster(DummyMaster dummyMaster)
        {
            if (_context.DummyMasters == null)
            {
                return Problem("Entity set 'DummyContext.DummyMasters'  is null.");
            }
            _context.DummyMasters.Add(dummyMaster);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDummyMaster", new { id = dummyMaster.MasterId }, dummyMaster);
        }

        // DELETE: api/DummyMasters/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDummyMaster(int id)
        {
            if (_context.DummyMasters == null)
            {
                return NotFound();
            }
            var dummyMaster = await _context.DummyMasters.FindAsync(id);
            if (dummyMaster == null)
            {
                return NotFound();
            }

            _context.DummyMasters.Remove(dummyMaster);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DummyMasterExists(int id)
        {
            return (_context.DummyMasters?.Any(e => e.MasterId == id)).GetValueOrDefault();
        }
    }
}
