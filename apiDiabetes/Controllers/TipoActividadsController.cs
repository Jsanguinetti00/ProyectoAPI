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
    public class TipoActividadsController : ControllerBase
    {
        private readonly dbContext _context;

        public TipoActividadsController(dbContext context)
        {
            _context = context;
        }

        // GET: api/TipoActividads
        [HttpGet]
        public IEnumerable<TipoActividad> GetTipoActividad()
        {
            return _context.TipoActividad;
        }

        // GET: api/TipoActividads/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTipoActividad([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tipoActividad = await _context.TipoActividad.FindAsync(id);

            if (tipoActividad == null)
            {
                return NotFound();
            }

            return Ok(tipoActividad);
        }

        // PUT: api/TipoActividads/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTipoActividad([FromRoute] int id, [FromBody] TipoActividad tipoActividad)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tipoActividad.IdTipoActividad)
            {
                return BadRequest();
            }

            _context.Entry(tipoActividad).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipoActividadExists(id))
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

        // POST: api/TipoActividads
        [HttpPost]
        public async Task<IActionResult> PostTipoActividad([FromBody] TipoActividad tipoActividad)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.TipoActividad.Add(tipoActividad);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTipoActividad", new { id = tipoActividad.IdTipoActividad }, tipoActividad);
        }

        // DELETE: api/TipoActividads/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTipoActividad([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tipoActividad = await _context.TipoActividad.FindAsync(id);
            if (tipoActividad == null)
            {
                return NotFound();
            }

            _context.TipoActividad.Remove(tipoActividad);
            await _context.SaveChangesAsync();

            return Ok(tipoActividad);
        }

        private bool TipoActividadExists(int id)
        {
            return _context.TipoActividad.Any(e => e.IdTipoActividad == id);
        }
    }
}