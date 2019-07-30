using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GestionDuCompresseur.Context;
using GestionDuCompresseur.Model;

namespace GestionDuCompresseur.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompresseurFilialesController : ControllerBase
    {
        private readonly Gestion_Compresseur_DBContext _context;

        public CompresseurFilialesController(Gestion_Compresseur_DBContext context)
        {
            _context = context;
        }

        // GET: api/CompresseurFiliales
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CompresseurFiliale>>> GetCompresseurFiliales()
        {
            return await _context.CompresseurFiliales.ToListAsync();
        }

        // GET: api/CompresseurFiliales/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CompresseurFiliale>> GetCompresseurFiliale(int id)
        {
            var compresseurFiliale = await _context.CompresseurFiliales.FindAsync(id);

            if (compresseurFiliale == null)
            {
                return NotFound();
            }

            return compresseurFiliale;
        }

        // PUT: api/CompresseurFiliales/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCompresseurFiliale(int id, CompresseurFiliale compresseurFiliale)
        {
            if (id != compresseurFiliale.CompFilialeID)
            {
                return BadRequest();
            }

            _context.Entry(compresseurFiliale).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CompresseurFilialeExists(id))
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

        // POST: api/CompresseurFiliales
        [HttpPost]
        public async Task<ActionResult<CompresseurFiliale>> PostCompresseurFiliale(CompresseurFiliale compresseurFiliale)
        {
            _context.CompresseurFiliales.Add(compresseurFiliale);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCompresseurFiliale", new { id = compresseurFiliale.CompFilialeID }, compresseurFiliale);
        }

        // DELETE: api/CompresseurFiliales/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CompresseurFiliale>> DeleteCompresseurFiliale(int id)
        {
            var compresseurFiliale = await _context.CompresseurFiliales.FindAsync(id);
            if (compresseurFiliale == null)
            {
                return NotFound();
            }

            _context.CompresseurFiliales.Remove(compresseurFiliale);
            await _context.SaveChangesAsync();

            return compresseurFiliale;
        }

        private bool CompresseurFilialeExists(int id)
        {
            return _context.CompresseurFiliales.Any(e => e.CompFilialeID == id);
        }
    }
}
