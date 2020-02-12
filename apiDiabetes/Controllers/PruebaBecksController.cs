using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using apiDiabetes.Models;

namespace apiDiabetes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PruebaBecksController : ControllerBase
    {
        private readonly dbContext _context;

        public PruebaBecksController(dbContext context)
        {
            _context = context;
        }

        // GET: api/PruebaBecks
        [HttpGet]
        public IEnumerable<PruebaBeck> GetPruebaBeck()
        {
            return _context.PruebaBeck;
        }

        // GET: api/PruebaBecks/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPruebaBeck([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var pruebaBeck = await _context.PruebaBeck.FindAsync(id);

            if (pruebaBeck == null)
            {
                return NotFound();
            }

            return Ok(pruebaBeck);
        }

        // PUT: api/PruebaBecks/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPruebaBeck([FromRoute] int id, [FromBody] PruebaBeck pruebaBeck)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pruebaBeck.IdPruebaBeck)
            {
                return BadRequest();
            }

            _context.Entry(pruebaBeck).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PruebaBeckExists(id))
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

        // POST: api/PruebaBecks
        [HttpPost]
        public async Task<IActionResult> PostPruebaBeck([FromBody] PruebaBeck pruebaBeck)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.PruebaBeck.Add(pruebaBeck);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPruebaBeck", new { id = pruebaBeck.IdPruebaBeck }, pruebaBeck);
        }

        // DELETE: api/PruebaBecks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePruebaBeck([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var pruebaBeck = await _context.PruebaBeck.FindAsync(id);
            if (pruebaBeck == null)
            {
                return NotFound();
            }

            _context.PruebaBeck.Remove(pruebaBeck);
            await _context.SaveChangesAsync();

            return Ok(pruebaBeck);
        }

        private bool PruebaBeckExists(int id)
        {
            return _context.PruebaBeck.Any(e => e.IdPruebaBeck == id);
        }
    }
}