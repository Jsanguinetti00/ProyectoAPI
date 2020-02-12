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
    public class TipoEspecialistasController : ControllerBase
    {
        private readonly dbContext _context;

        public TipoEspecialistasController(dbContext context)
        {
            _context = context;
        }

        // GET: api/TipoEspecialistas
        [HttpGet]
        public IEnumerable<TipoEspecialista> GetTipoEspecialista()
        {
            return _context.TipoEspecialista;
        }

        // GET: api/TipoEspecialistas/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTipoEspecialista([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tipoEspecialista = await _context.TipoEspecialista.FindAsync(id);

            if (tipoEspecialista == null)
            {
                return NotFound();
            }

            return Ok(tipoEspecialista);
        }

        // PUT: api/TipoEspecialistas/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTipoEspecialista([FromRoute] int id, [FromBody] TipoEspecialista tipoEspecialista)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tipoEspecialista.IdEspecialista)
            {
                return BadRequest();
            }

            _context.Entry(tipoEspecialista).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipoEspecialistaExists(id))
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

        // POST: api/TipoEspecialistas
        [HttpPost]
        public async Task<IActionResult> PostTipoEspecialista([FromBody] TipoEspecialista tipoEspecialista)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.TipoEspecialista.Add(tipoEspecialista);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTipoEspecialista", new { id = tipoEspecialista.IdEspecialista }, tipoEspecialista);
        }

        // DELETE: api/TipoEspecialistas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTipoEspecialista([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tipoEspecialista = await _context.TipoEspecialista.FindAsync(id);
            if (tipoEspecialista == null)
            {
                return NotFound();
            }

            _context.TipoEspecialista.Remove(tipoEspecialista);
            await _context.SaveChangesAsync();

            return Ok(tipoEspecialista);
        }

        private bool TipoEspecialistaExists(int id)
        {
            return _context.TipoEspecialista.Any(e => e.IdEspecialista == id);
        }
    }
}