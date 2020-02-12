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
    public class DatosCitasController : ControllerBase
    {
        private readonly dbContext _context;

        public DatosCitasController(dbContext context)
        {
            _context = context;
        }

        // GET: api/DatosCitas
        [HttpGet]
        public IEnumerable<DatosCita> GetDatosCita()
        {
            return _context.DatosCita;
        }

        // GET: api/DatosCitas/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDatosCita([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var datosCita = await _context.DatosCita.FindAsync(id);

            if (datosCita == null)
            {
                return NotFound();
            }

            return Ok(datosCita);
        }

        // PUT: api/DatosCitas/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDatosCita([FromRoute] int id, [FromBody] DatosCita datosCita)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != datosCita.IdDatoscita)
            {
                return BadRequest();
            }

            _context.Entry(datosCita).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DatosCitaExists(id))
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

        // POST: api/DatosCitas
        [HttpPost]
        public async Task<IActionResult> PostDatosCita([FromBody] DatosCita datosCita)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.DatosCita.Add(datosCita);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDatosCita", new { id = datosCita.IdDatoscita }, datosCita);
        }

        // DELETE: api/DatosCitas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDatosCita([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var datosCita = await _context.DatosCita.FindAsync(id);
            if (datosCita == null)
            {
                return NotFound();
            }

            _context.DatosCita.Remove(datosCita);
            await _context.SaveChangesAsync();

            return Ok(datosCita);
        }

        private bool DatosCitaExists(int id)
        {
            return _context.DatosCita.Any(e => e.IdDatoscita == id);
        }
    }
}