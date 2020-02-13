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
    public class CitasController : ControllerBase
    {
        private readonly dbDiabetesContext _context;

        public CitasController(dbDiabetesContext context)
        {
            _context = context;
        }

        // GET: api/Citas
        [HttpGet]
        public IEnumerable<Citas> GetCitas()
        {
            return _context.Citas;
        }

        // GET: api/Citas/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCitas([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var citas = await _context.Citas.FindAsync(id);

            if (citas == null)
            {
                return NotFound();
            }

            return Ok(citas);
        }

        // PUT: api/Citas/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCitas([FromRoute] int id, [FromBody] Citas citas)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != citas.IdCitas)
            {
                return BadRequest();
            }

            _context.Entry(citas).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CitasExists(id))
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

        // POST: api/Citas
        [HttpPost]
        public async Task<IActionResult> PostCitas([FromBody] Citas citas)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Citas.Add(citas);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCitas", new { id = citas.IdCitas }, citas);
        }

        // DELETE: api/Citas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCitas([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var citas = await _context.Citas.FindAsync(id);
            if (citas == null)
            {
                return NotFound();
            }

            _context.Citas.Remove(citas);
            await _context.SaveChangesAsync();

            return Ok(citas);
        }

        private bool CitasExists(int id)
        {
            return _context.Citas.Any(e => e.IdCitas == id);
        }
    }
}