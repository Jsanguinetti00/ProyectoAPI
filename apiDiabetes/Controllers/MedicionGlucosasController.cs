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
    public class MedicionGlucosasController : ControllerBase
    {
        private readonly dbDiabetesContext _context;

        public MedicionGlucosasController(dbDiabetesContext context)
        {
            _context = context;
        }

        // GET: api/MedicionGlucosas
        [HttpGet]
        public IEnumerable<MedicionGlucosa> GetMedicionGlucosa()
        {
            return _context.MedicionGlucosa;
        }

        // GET: api/MedicionGlucosas/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMedicionGlucosa([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var medicionGlucosa = await _context.MedicionGlucosa.FindAsync(id);

            if (medicionGlucosa == null)
            {
                return NotFound();
            }

            return Ok(medicionGlucosa);
        }

        // PUT: api/MedicionGlucosas/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMedicionGlucosa([FromRoute] int id, [FromBody] MedicionGlucosa medicionGlucosa)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != medicionGlucosa.IdMedicionGlucosa)
            {
                return BadRequest();
            }

            _context.Entry(medicionGlucosa).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MedicionGlucosaExists(id))
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

        // POST: api/MedicionGlucosas
        [HttpPost]
        public async Task<IActionResult> PostMedicionGlucosa([FromBody] MedicionGlucosa medicionGlucosa)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.MedicionGlucosa.Add(medicionGlucosa);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMedicionGlucosa", new { id = medicionGlucosa.IdMedicionGlucosa }, medicionGlucosa);
        }

        // DELETE: api/MedicionGlucosas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMedicionGlucosa([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var medicionGlucosa = await _context.MedicionGlucosa.FindAsync(id);
            if (medicionGlucosa == null)
            {
                return NotFound();
            }

            _context.MedicionGlucosa.Remove(medicionGlucosa);
            await _context.SaveChangesAsync();

            return Ok(medicionGlucosa);
        }

        private bool MedicionGlucosaExists(int id)
        {
            return _context.MedicionGlucosa.Any(e => e.IdMedicionGlucosa == id);
        }
    }
}