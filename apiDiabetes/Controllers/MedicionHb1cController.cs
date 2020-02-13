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
    public class MedicionHb1cController : ControllerBase
    {
        private readonly dbDiabetesContext _context;

        public MedicionHb1cController(dbDiabetesContext context)
        {
            _context = context;
        }

        // GET: api/MedicionHb1c
        [HttpGet]
        public IEnumerable<MedicionHb1c> GetMedicionHb1c()
        {
            return _context.MedicionHb1c;
        }

        // GET: api/MedicionHb1c/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMedicionHb1c([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var medicionHb1c = await _context.MedicionHb1c.FindAsync(id);

            if (medicionHb1c == null)
            {
                return NotFound();
            }

            return Ok(medicionHb1c);
        }

        // PUT: api/MedicionHb1c/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMedicionHb1c([FromRoute] int id, [FromBody] MedicionHb1c medicionHb1c)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != medicionHb1c.IdMedicionHb1c)
            {
                return BadRequest();
            }

            _context.Entry(medicionHb1c).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MedicionHb1cExists(id))
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

        // POST: api/MedicionHb1c
        [HttpPost]
        public async Task<IActionResult> PostMedicionHb1c([FromBody] MedicionHb1c medicionHb1c)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.MedicionHb1c.Add(medicionHb1c);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMedicionHb1c", new { id = medicionHb1c.IdMedicionHb1c }, medicionHb1c);
        }

        // DELETE: api/MedicionHb1c/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMedicionHb1c([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var medicionHb1c = await _context.MedicionHb1c.FindAsync(id);
            if (medicionHb1c == null)
            {
                return NotFound();
            }

            _context.MedicionHb1c.Remove(medicionHb1c);
            await _context.SaveChangesAsync();

            return Ok(medicionHb1c);
        }

        private bool MedicionHb1cExists(int id)
        {
            return _context.MedicionHb1c.Any(e => e.IdMedicionHb1c == id);
        }
    }
}