using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TrainingApi.Models;

namespace TrainingApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainingController : ControllerBase
    {
        private readonly TrainingContext _context;

        public TrainingController(TrainingContext context)
        {
            _context = context;
        }

        // GET: api/Training
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TrainingItem>>> GetTrainingItems()
        {
          if (_context.TrainingItems == null)
          {
              return NotFound();
          }
            return await _context.TrainingItems.ToListAsync();
        }

        // GET: api/Training/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TrainingItem>> GetTrainingItem(long id)
        {
          if (_context.TrainingItems == null)
          {
              return NotFound();
          }
            var trainingItem = await _context.TrainingItems.FindAsync(id);

            if (trainingItem == null)
            {
                return NotFound();
            }

            return trainingItem;
        }

        // PUT: api/Training/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTrainingItem(long id, TrainingItem trainingItem)
        {
            if (id != trainingItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(trainingItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TrainingItemExists(id))
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

        // POST: api/Training
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TrainingItem>> PostTrainingItem(TrainingItem trainingItem)
        {
          if (_context.TrainingItems == null)
          {
              return Problem("Entity set 'TrainingContext.TrainingItems'  is null.");
          }
            _context.TrainingItems.Add(trainingItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTrainingItem), new { id = trainingItem.Id }, trainingItem);
        }

        [HttpPost("train")]
        public async Task<ActionResult<IEnumerable<TrainingItem>>> Train(long count)
        {
            if (_context.TrainingItems == null)
            {
                return Problem("Entity set 'TrainingContext.TrainingItems'  is null.");
            }


            List<TrainingItem> trained = new List<TrainingItem>();

            foreach(TrainingItem ti in _context.TrainingItems)
            {
                if(count <= 0) { break; }
                if(ti.completed == true) { continue; }
                ti.completed = true;
                trained.Add(ti);
                count -= 1;
                _context.Entry(ti).State = EntityState.Modified;
            }
            await _context.SaveChangesAsync();

            return (trained);
        }

        // DELETE: api/Training/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTrainingItem(long id)
        {
            if (_context.TrainingItems == null)
            {
                return NotFound();
            }
            var trainingItem = await _context.TrainingItems.FindAsync(id);
            if (trainingItem == null)
            {
                return NotFound();
            }

            _context.TrainingItems.Remove(trainingItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TrainingItemExists(long id)
        {
            return (_context.TrainingItems?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
