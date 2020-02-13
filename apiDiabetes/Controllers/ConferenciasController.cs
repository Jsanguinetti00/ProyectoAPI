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
    public class ConferenciasController : ControllerBase
    {
        private readonly dbDiabetesContext _context;

        public ConferenciasController(dbDiabetesContext context)
        {
            _context = context;
        }

        // GET: api/Conferencias
        [HttpGet]
        public IEnumerable<Conferencias> GetConferencias()
        {
            return _context.Conferencias;
        }

        // GET: api/Conferencias/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetConferencias([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var conferencias = await _context.Conferencias.FindAsync(id);

            if (conferencias == null)
            {
                return NotFound();
            }

            return Ok(conferencias);
        }

        // PUT: api/Conferencias/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutConferencias([FromRoute] int id, [FromBody] Conferencias conferencias)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != conferencias.IdConferencias)
            {
                return BadRequest();
            }

            _context.Entry(conferencias).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConferenciasExists(id))
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

        // POST: api/Conferencias
        [HttpPost]
        public async Task<IActionResult> PostConferencias([FromBody] Conferencias conferencias)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Conferencias.Add(conferencias);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetConferencias", new { id = conferencias.IdConferencias }, conferencias);
        }

        // DELETE: api/Conferencias/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteConferencias([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var conferencias = await _context.Conferencias.FindAsync(id);
            if (conferencias == null)
            {
                return NotFound();
            }

            _context.Conferencias.Remove(conferencias);
            await _context.SaveChangesAsync();

            return Ok(conferencias);
        }

        private bool ConferenciasExists(int id)
        {
            return _context.Conferencias.Any(e => e.IdConferencias == id);
        }
    }
}