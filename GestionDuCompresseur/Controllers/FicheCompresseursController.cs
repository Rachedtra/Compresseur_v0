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
    public class FicheCompresseursController : ControllerBase
    {
        private readonly Gestion_Compresseur_DBContext _context;

        public FicheCompresseursController(Gestion_Compresseur_DBContext context)
        {
            _context = context;
        }

        // GET: api/FicheCompresseurs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FicheCompresseur>>> GetFicheCompresseurs()
        {
            return await _context.FicheCompresseurs.ToListAsync();
        }

        // GET: api/FicheCompresseurs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FicheCompresseur>> GetFicheCompresseur(int id)
        {
            var ficheCompresseur = await _context.FicheCompresseurs.FindAsync(id);

            if (ficheCompresseur == null)
            {
                return NotFound();
            }

            return ficheCompresseur;
        }

        // PUT: api/FicheCompresseurs/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFicheCompresseur(int id, FicheCompresseur ficheCompresseur)
        {
            if (id != ficheCompresseur.CompresseurID)
            {
                return BadRequest();
            }

            _context.Entry(ficheCompresseur).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FicheCompresseurExists(id))
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

        // POST: api/FicheCompresseurs
        [HttpPost]
        public async Task<ActionResult<FicheCompresseur>> PostFicheCompresseur(FicheCompresseur ficheCompresseur)
        {
            _context.FicheCompresseurs.Add(ficheCompresseur);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFicheCompresseur", new { id = ficheCompresseur.CompresseurID }, ficheCompresseur);
        }

        // DELETE: api/FicheCompresseurs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<FicheCompresseur>> DeleteFicheCompresseur(int id)
        {
            var ficheCompresseur = await _context.FicheCompresseurs.FindAsync(id);
            if (ficheCompresseur == null)
            {
                return NotFound();
            }

            _context.FicheCompresseurs.Remove(ficheCompresseur);
            await _context.SaveChangesAsync();

            return ficheCompresseur;
        }

        private bool FicheCompresseurExists(int id)
        {
            return _context.FicheCompresseurs.Any(e => e.CompresseurID == id);
        }
    }
}
