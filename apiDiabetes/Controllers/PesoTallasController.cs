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
    public class PesoTallasController : ControllerBase
    {
        private readonly dbContext _context;

        public PesoTallasController(dbContext context)
        {
            _context = context;
        }

        // GET: api/PesoTallas
        [HttpGet]
        public IEnumerable<PesoTalla> GetPesoTalla()
        {
            return _context.PesoTalla;
        }

        // GET: api/PesoTallas/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPesoTalla([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var pesoTalla = await _context.PesoTalla.FindAsync(id);

            if (pesoTalla == null)
            {
                return NotFound();
            }

            return Ok(pesoTalla);
        }

        // PUT: api/PesoTallas/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPesoTalla([FromRoute] int id, [FromBody] PesoTalla pesoTalla)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pesoTalla.IdPesoTalla)
            {
                return BadRequest();
            }

            _context.Entry(pesoTalla).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PesoTallaExists(id))
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

        // POST: api/PesoTallas
        [HttpPost]
        public async Task<IActionResult> PostPesoTalla([FromBody] PesoTalla pesoTalla)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.PesoTalla.Add(pesoTalla);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPesoTalla", new { id = pesoTalla.IdPesoTalla }, pesoTalla);
        }

        // DELETE: api/PesoTallas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePesoTalla([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var pesoTalla = await _context.PesoTalla.FindAsync(id);
            if (pesoTalla == null)
            {
                return NotFound();
            }

            _context.PesoTalla.Remove(pesoTalla);
            await _context.SaveChangesAsync();

            return Ok(pesoTalla);
        }

        private bool PesoTallaExists(int id)
        {
            return _context.PesoTalla.Any(e => e.IdPesoTalla == id);
        }
    }
}