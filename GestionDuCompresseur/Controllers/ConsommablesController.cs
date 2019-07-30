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
    public class ConsommablesController : ControllerBase
    {
        private readonly Gestion_Compresseur_DBContext _context;

        public ConsommablesController(Gestion_Compresseur_DBContext context)
        {
            _context = context;
        }

        // GET: api/Consommables
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Consommable>>> GetConsommables()
        {
            return await _context.Consommables.ToListAsync();
        }

        // GET: api/Consommables/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Consommable>> GetConsommable(int id)
        {
            var consommable = await _context.Consommables.FindAsync(id);

            if (consommable == null)
            {
                return NotFound();
            }

            return consommable;
        }

        // PUT: api/Consommables/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutConsommable(int id, Consommable consommable)
        {
            if (id != consommable.ConsommableID)
            {
                return BadRequest();
            }

            _context.Entry(consommable).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConsommableExists(id))
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

        // POST: api/Consommables
        [HttpPost]
        public async Task<ActionResult<Consommable>> PostConsommable(Consommable consommable)
        {
            _context.Consommables.Add(consommable);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetConsommable", new { id = consommable.ConsommableID }, consommable);
        }

        // DELETE: api/Consommables/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Consommable>> DeleteConsommable(int id)
        {
            var consommable = await _context.Consommables.FindAsync(id);
            if (consommable == null)
            {
                return NotFound();
            }

            _context.Consommables.Remove(consommable);
            await _context.SaveChangesAsync();

            return consommable;
        }

        private bool ConsommableExists(int id)
        {
            return _context.Consommables.Any(e => e.ConsommableID == id);
        }
    }
}
