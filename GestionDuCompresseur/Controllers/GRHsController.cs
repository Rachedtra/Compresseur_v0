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
    public class GRHsController : ControllerBase
    {
        private readonly Gestion_Compresseur_DBContext _context;

        public GRHsController(Gestion_Compresseur_DBContext context)
        {
            _context = context;
        }

        // GET: api/GRHs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GRH>>> GetGRHs()
        {
            return await _context.GRHs.ToListAsync();
        }

        // GET: api/GRHs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GRH>> GetGRH(int id)
        {
            var gRH = await _context.GRHs.FindAsync(id);

            if (gRH == null)
            {
                return NotFound();
            }

            return gRH;
        }

        // PUT: api/GRHs/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGRH(int id, GRH gRH)
        {
            if (id != gRH.GRhID)
            {
                return BadRequest();
            }

            _context.Entry(gRH).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GRHExists(id))
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

        // POST: api/GRHs
        [HttpPost]
        public async Task<ActionResult<GRH>> PostGRH(GRH gRH)
        {
            _context.GRHs.Add(gRH);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGRH", new { id = gRH.GRhID }, gRH);
        }

        // DELETE: api/GRHs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<GRH>> DeleteGRH(int id)
        {
            var gRH = await _context.GRHs.FindAsync(id);
            if (gRH == null)
            {
                return NotFound();
            }

            _context.GRHs.Remove(gRH);
            await _context.SaveChangesAsync();

            return gRH;
        }

        private bool GRHExists(int id)
        {
            return _context.GRHs.Any(e => e.GRhID == id);
        }
    }
}
