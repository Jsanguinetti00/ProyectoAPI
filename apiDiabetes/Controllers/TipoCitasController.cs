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
    public class TipoCitasController : ControllerBase
    {
        private readonly dbDiabetesContext _context;

        public TipoCitasController(dbDiabetesContext context)
        {
            _context = context;
        }

        // GET: api/TipoCitas
        [HttpGet]
        public IEnumerable<TipoCitas> GetTipoCitas()
        {
            return _context.TipoCitas;
        }

        // GET: api/TipoCitas/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTipoCitas([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tipoCitas = await _context.TipoCitas.FindAsync(id);

            if (tipoCitas == null)
            {
                return NotFound();
            }

            return Ok(tipoCitas);
        }

        // PUT: api/TipoCitas/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTipoCitas([FromRoute] int id, [FromBody] TipoCitas tipoCitas)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tipoCitas.IdTipoCitas)
            {
                return BadRequest();
            }

            _context.Entry(tipoCitas).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipoCitasExists(id))
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

        // POST: api/TipoCitas
        [HttpPost]
        public async Task<IActionResult> PostTipoCitas([FromBody] TipoCitas tipoCitas)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.TipoCitas.Add(tipoCitas);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTipoCitas", new { id = tipoCitas.IdTipoCitas }, tipoCitas);
        }

        // DELETE: api/TipoCitas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTipoCitas([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tipoCitas = await _context.TipoCitas.FindAsync(id);
            if (tipoCitas == null)
            {
                return NotFound();
            }

            _context.TipoCitas.Remove(tipoCitas);
            await _context.SaveChangesAsync();

            return Ok(tipoCitas);
        }

        private bool TipoCitasExists(int id)
        {
            return _context.TipoCitas.Any(e => e.IdTipoCitas == id);
        }
    }
}