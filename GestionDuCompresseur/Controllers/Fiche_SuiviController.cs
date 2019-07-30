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
    public class Fiche_SuiviController : ControllerBase
    {
        private readonly Gestion_Compresseur_DBContext _context;

        public Fiche_SuiviController(Gestion_Compresseur_DBContext context)
        {
            _context = context;
        }

        // GET: api/Fiche_Suivi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Fiche_Suivi>>> GetFiche_Suivis()
        {
            return await _context.Fiche_Suivis.ToListAsync();
        }

        // GET: api/Fiche_Suivi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Fiche_Suivi>> GetFiche_Suivi(int id)
        {
            var fiche_Suivi = await _context.Fiche_Suivis.FindAsync(id);

            if (fiche_Suivi == null)
            {
                return NotFound();
            }

            return fiche_Suivi;
        }

        // PUT: api/Fiche_Suivi/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFiche_Suivi(int id, Fiche_Suivi fiche_Suivi)
        {
            if (id != fiche_Suivi.FicheSuiviID)
            {
                return BadRequest();
            }

            _context.Entry(fiche_Suivi).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Fiche_SuiviExists(id))
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

        // POST: api/Fiche_Suivi
        [HttpPost]
        public async Task<ActionResult<Fiche_Suivi>> PostFiche_Suivi(Fiche_Suivi fiche_Suivi)
        {
            _context.Fiche_Suivis.Add(fiche_Suivi);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFiche_Suivi", new { id = fiche_Suivi.FicheSuiviID }, fiche_Suivi);
        }

        // DELETE: api/Fiche_Suivi/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Fiche_Suivi>> DeleteFiche_Suivi(int id)
        {
            var fiche_Suivi = await _context.Fiche_Suivis.FindAsync(id);
            if (fiche_Suivi == null)
            {
                return NotFound();
            }

            _context.Fiche_Suivis.Remove(fiche_Suivi);
            await _context.SaveChangesAsync();

            return fiche_Suivi;
        }

        private bool Fiche_SuiviExists(int id)
        {
            return _context.Fiche_Suivis.Any(e => e.FicheSuiviID == id);
        }
    }
}
