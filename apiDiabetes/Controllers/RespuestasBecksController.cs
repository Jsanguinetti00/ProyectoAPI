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
    public class RespuestasBecksController : ControllerBase
    {
        private readonly dbDiabetesContext _context;

        public RespuestasBecksController(dbDiabetesContext context)
        {
            _context = context;
        }

        // GET: api/RespuestasBecks
        [HttpGet]
        public IEnumerable<RespuestasBeck> GetRespuestasBeck()
        {
            return _context.RespuestasBeck;
        }

        // GET: api/RespuestasBecks/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRespuestasBeck([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var respuestasBeck = await _context.RespuestasBeck.FindAsync(id);

            if (respuestasBeck == null)
            {
                return NotFound();
            }

            return Ok(respuestasBeck);
        }

        // PUT: api/RespuestasBecks/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRespuestasBeck([FromRoute] int id, [FromBody] RespuestasBeck respuestasBeck)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != respuestasBeck.IdRespuestasBeck)
            {
                return BadRequest();
            }

            _context.Entry(respuestasBeck).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RespuestasBeckExists(id))
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

        // POST: api/RespuestasBecks
        [HttpPost]
        public async Task<IActionResult> PostRespuestasBeck([FromBody] RespuestasBeck respuestasBeck)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.RespuestasBeck.Add(respuestasBeck);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRespuestasBeck", new { id = respuestasBeck.IdRespuestasBeck }, respuestasBeck);
        }

        // DELETE: api/RespuestasBecks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRespuestasBeck([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var respuestasBeck = await _context.RespuestasBeck.FindAsync(id);
            if (respuestasBeck == null)
            {
                return NotFound();
            }

            _context.RespuestasBeck.Remove(respuestasBeck);
            await _context.SaveChangesAsync();

            return Ok(respuestasBeck);
        }

        private bool RespuestasBeckExists(int id)
        {
            return _context.RespuestasBeck.Any(e => e.IdRespuestasBeck == id);
        }
    }
}