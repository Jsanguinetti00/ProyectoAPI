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
    public class MedicionMesualsController : ControllerBase
    {
        private readonly dbContext _context;

        public MedicionMesualsController(dbContext context)
        {
            _context = context;
        }

        // GET: api/MedicionMesuals
        [HttpGet]
        public IEnumerable<MedicionMesual> GetMedicionMesual()
        {
            return _context.MedicionMesual;
        }

        // GET: api/MedicionMesuals/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMedicionMesual([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var medicionMesual = await _context.MedicionMesual.FindAsync(id);

            if (medicionMesual == null)
            {
                return NotFound();
            }

            return Ok(medicionMesual);
        }

        // PUT: api/MedicionMesuals/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMedicionMesual([FromRoute] int id, [FromBody] MedicionMesual medicionMesual)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != medicionMesual.IdMedicionMensual)
            {
                return BadRequest();
            }

            _context.Entry(medicionMesual).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MedicionMesualExists(id))
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

        // POST: api/MedicionMesuals
        [HttpPost]
        public async Task<IActionResult> PostMedicionMesual([FromBody] MedicionMesual medicionMesual)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.MedicionMesual.Add(medicionMesual);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMedicionMesual", new { id = medicionMesual.IdMedicionMensual }, medicionMesual);
        }

        // DELETE: api/MedicionMesuals/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMedicionMesual([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var medicionMesual = await _context.MedicionMesual.FindAsync(id);
            if (medicionMesual == null)
            {
                return NotFound();
            }

            _context.MedicionMesual.Remove(medicionMesual);
            await _context.SaveChangesAsync();

            return Ok(medicionMesual);
        }

        private bool MedicionMesualExists(int id)
        {
            return _context.MedicionMesual.Any(e => e.IdMedicionMensual == id);
        }
    }
}