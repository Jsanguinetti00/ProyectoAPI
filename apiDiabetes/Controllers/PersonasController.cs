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
    public class PersonasController : ControllerBase
    {
        private readonly dbDiabetesContext _context;

        public PersonasController(dbDiabetesContext context)
        {
            _context = context;
        }

        // GET: api/Personas
        [HttpGet]
        public IEnumerable<Personas> GetPersonas()
        {
            return _context.Personas;
        }

        // GET: api/Personas/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPersonas([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var personas = await _context.Personas.FindAsync(id);

            if (personas == null)
            {
                return NotFound();
            }

            return Ok(personas);
        }

        // PUT: api/Personas/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPersonas([FromRoute] int id, [FromBody] Personas personas)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != personas.IdPersona)
            {
                return BadRequest();
            }

            _context.Entry(personas).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonasExists(id))
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

        // POST: api/Personas
        [HttpPost]
        public async Task<IActionResult> PostPersonas([FromBody] Personas personas)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Personas.Add(personas);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPersonas", new { id = personas.IdPersona }, personas);
        }

        // DELETE: api/Personas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePersonas([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var personas = await _context.Personas.FindAsync(id);
            if (personas == null)
            {
                return NotFound();
            }

            _context.Personas.Remove(personas);
            await _context.SaveChangesAsync();

            return Ok(personas);
        }

        private bool PersonasExists(int id)
        {
            return _context.Personas.Any(e => e.IdPersona == id);
        }
    }
}