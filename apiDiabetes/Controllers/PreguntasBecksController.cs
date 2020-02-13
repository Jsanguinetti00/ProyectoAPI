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
    public class PreguntasBecksController : ControllerBase
    {
        private readonly dbDiabetesContext _context;

        public PreguntasBecksController(dbDiabetesContext context)
        {
            _context = context;
        }

        // GET: api/PreguntasBecks
        [HttpGet]
        public IEnumerable<PreguntasBeck> GetPreguntasBeck()
        {
            return _context.PreguntasBeck;
        }

        // GET: api/PreguntasBecks/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPreguntasBeck([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var preguntasBeck = await _context.PreguntasBeck.FindAsync(id);

            if (preguntasBeck == null)
            {
                return NotFound();
            }

            return Ok(preguntasBeck);
        }

        // PUT: api/PreguntasBecks/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPreguntasBeck([FromRoute] int id, [FromBody] PreguntasBeck preguntasBeck)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != preguntasBeck.IdPreguntasBeck)
            {
                return BadRequest();
            }

            _context.Entry(preguntasBeck).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PreguntasBeckExists(id))
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

        // POST: api/PreguntasBecks
        [HttpPost]
        public async Task<IActionResult> PostPreguntasBeck([FromBody] PreguntasBeck preguntasBeck)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.PreguntasBeck.Add(preguntasBeck);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPreguntasBeck", new { id = preguntasBeck.IdPreguntasBeck }, preguntasBeck);
        }

        // DELETE: api/PreguntasBecks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePreguntasBeck([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var preguntasBeck = await _context.PreguntasBeck.FindAsync(id);
            if (preguntasBeck == null)
            {
                return NotFound();
            }

            _context.PreguntasBeck.Remove(preguntasBeck);
            await _context.SaveChangesAsync();

            return Ok(preguntasBeck);
        }

        private bool PreguntasBeckExists(int id)
        {
            return _context.PreguntasBeck.Any(e => e.IdPreguntasBeck == id);
        }
    }
}