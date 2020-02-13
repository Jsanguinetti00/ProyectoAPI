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
    public class PerfilModulosController : ControllerBase
    {
        private readonly dbDiabetesContext _context;

        public PerfilModulosController(dbDiabetesContext context)
        {
            _context = context;
        }

        // GET: api/PerfilModulos
        [HttpGet]
        public IEnumerable<PerfilModulos> GetPerfilModulos()
        {
            return _context.PerfilModulos;
        }

        // GET: api/PerfilModulos/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPerfilModulos([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var perfilModulos = await _context.PerfilModulos.FindAsync(id);

            if (perfilModulos == null)
            {
                return NotFound();
            }

            return Ok(perfilModulos);
        }

        // PUT: api/PerfilModulos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPerfilModulos([FromRoute] int id, [FromBody] PerfilModulos perfilModulos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != perfilModulos.IdPerfilModulos)
            {
                return BadRequest();
            }

            _context.Entry(perfilModulos).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PerfilModulosExists(id))
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

        // POST: api/PerfilModulos
        [HttpPost]
        public async Task<IActionResult> PostPerfilModulos([FromBody] PerfilModulos perfilModulos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.PerfilModulos.Add(perfilModulos);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPerfilModulos", new { id = perfilModulos.IdPerfilModulos }, perfilModulos);
        }

        // DELETE: api/PerfilModulos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePerfilModulos([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var perfilModulos = await _context.PerfilModulos.FindAsync(id);
            if (perfilModulos == null)
            {
                return NotFound();
            }

            _context.PerfilModulos.Remove(perfilModulos);
            await _context.SaveChangesAsync();

            return Ok(perfilModulos);
        }

        private bool PerfilModulosExists(int id)
        {
            return _context.PerfilModulos.Any(e => e.IdPerfilModulos == id);
        }
    }
}