using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using apiDiabetes.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;


namespace apiDiabetes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class Calendario7pasosController : ControllerBase
    {
        private readonly dbDiabetesContext _context;

        public Calendario7pasosController(dbDiabetesContext context)
        {
            _context = context;
        }

        // GET: api/Calendario7pasos
        [HttpGet]
        public IEnumerable<Calendario7pasos> GetCalendario7pasos()
        {
            return _context.Calendario7pasos;
        }

        // GET: api/Calendario7pasos/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCalendario7pasos([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var calendario7pasos = await _context.Calendario7pasos.FindAsync(id);

            if (calendario7pasos == null)
            {
                return NotFound();
            }

            return Ok(calendario7pasos);
        }

        // PUT: api/Calendario7pasos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCalendario7pasos([FromRoute] int id, [FromBody] Calendario7pasos calendario7pasos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != calendario7pasos.IdCalendario7pasos)
            {
                return BadRequest();
            }

            _context.Entry(calendario7pasos).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Calendario7pasosExists(id))
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

        // POST: api/Calendario7pasos
        [HttpPost]
        public async Task<IActionResult> PostCalendario7pasos([FromBody] Calendario7pasos calendario7pasos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Calendario7pasos.Add(calendario7pasos);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCalendario7pasos", new { id = calendario7pasos.IdCalendario7pasos }, calendario7pasos);
        }

        // DELETE: api/Calendario7pasos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCalendario7pasos([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var calendario7pasos = await _context.Calendario7pasos.FindAsync(id);
            if (calendario7pasos == null)
            {
                return NotFound();
            }

            _context.Calendario7pasos.Remove(calendario7pasos);
            await _context.SaveChangesAsync();

            return Ok(calendario7pasos);
        }

        private bool Calendario7pasosExists(int id)
        {
            return _context.Calendario7pasos.Any(e => e.IdCalendario7pasos == id);
        }
    }
}