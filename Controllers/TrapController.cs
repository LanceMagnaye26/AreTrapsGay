using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApi.Models;

namespace TodoApi.Controllers
{
    [Route("api/Trap")]
    [ApiController]
    public class TrapController : ControllerBase
    {
        private readonly TrapContext _context;

        public TrapController(TrapContext context)
        {
            _context = context;
        }
        // GET: api/Trap
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TrapItem>>> GetTrapItems()
        {
            return await _context.TrapItems.ToListAsync();
        }

        // GET: api/Trap/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TrapItem>> GetTrapItem(long id)
        {
            var TrapItem = await _context.TrapItems.FindAsync(id);

            if (TrapItem == null)
            {
                return NotFound();
            }

            return TrapItem;
        }

        // POST: api/Trap
        [HttpPost]
        public async Task<ActionResult<TrapItem>> PostTrapItem(TrapItem item)
        {
            _context.TrapItems.Add(item);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTrapItem), new { id = item.Id }, item);
        }

        // PUT: api/Trap/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTrapItem(int id, TrapItem item)
        {
            if (id != item.Id)
            {
                return BadRequest();
            }

            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/Trap/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTrapItem(int id)
        {
            var TrapItem = await _context.TrapItems.FindAsync(id);

            if (TrapItem == null)
            {
                return NotFound();
            }

            _context.TrapItems.Remove(TrapItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }


    }


}