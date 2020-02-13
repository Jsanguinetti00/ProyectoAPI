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
    public class TipoUsuariosController : ControllerBase
    {
        private readonly dbDiabetesContext _context;

        public TipoUsuariosController(dbDiabetesContext context)
        {
            _context = context;
        }

        // GET: api/TipoUsuarios
        [HttpGet]
        public IEnumerable<TipoUsuario> GetTipoUsuario()
        {
            return _context.TipoUsuario;
        }

        // GET: api/TipoUsuarios/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTipoUsuario([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tipoUsuario = await _context.TipoUsuario.FindAsync(id);

            if (tipoUsuario == null)
            {
                return NotFound();
            }

            return Ok(tipoUsuario);
        }

        // PUT: api/TipoUsuarios/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTipoUsuario([FromRoute] int id, [FromBody] TipoUsuario tipoUsuario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tipoUsuario.IdTipoUsuario)
            {
                return BadRequest();
            }

            _context.Entry(tipoUsuario).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipoUsuarioExists(id))
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

        // POST: api/TipoUsuarios
        [HttpPost]
        public async Task<IActionResult> PostTipoUsuario([FromBody] TipoUsuario tipoUsuario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.TipoUsuario.Add(tipoUsuario);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTipoUsuario", new { id = tipoUsuario.IdTipoUsuario }, tipoUsuario);
        }

        // DELETE: api/TipoUsuarios/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTipoUsuario([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tipoUsuario = await _context.TipoUsuario.FindAsync(id);
            if (tipoUsuario == null)
            {
                return NotFound();
            }

            _context.TipoUsuario.Remove(tipoUsuario);
            await _context.SaveChangesAsync();

            return Ok(tipoUsuario);
        }

        private bool TipoUsuarioExists(int id)
        {
            return _context.TipoUsuario.Any(e => e.IdTipoUsuario == id);
        }
    }
}