using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using aplikacija.Data;
using aplikacija.Models;
using Filters;

namespace aplikacija.Controllers_api
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiKeyAuth]
    public class ArtikelApiController : ControllerBase
    {
        private readonly smartbuyContext _context;

        public ArtikelApiController(smartbuyContext context)
        {
            _context = context;
        }

        // GET: api/ArtikelApi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Artikel>>> GetArtikli()
        {
            return await _context.Artikli.ToListAsync();
        }

        // GET: api/ArtikelApi/5
        [HttpGet("{id}")]
        [ApiKeyAuth]
        public async Task<ActionResult<Artikel>> GetArtikel(int id)
        {
            var artikel = await _context.Artikli.FindAsync(id);

            if (artikel == null)
            {
                return NotFound();
            }

            return artikel;
        }

        // PUT: api/ArtikelApi/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutArtikel(int id, Artikel artikel)
        {
            if (id != artikel.ArtikelID)
            {
                return BadRequest();
            }

            _context.Entry(artikel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ArtikelExists(id))
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

        // POST: api/ArtikelApi
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Artikel>> PostArtikel(Artikel artikel)
        {
            _context.Artikli.Add(artikel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetArtikel", new { id = artikel.ArtikelID }, artikel);
        }

        // DELETE: api/ArtikelApi/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Artikel>> DeleteArtikel(int id)
        {
            var artikel = await _context.Artikli.FindAsync(id);
            if (artikel == null)
            {
                return NotFound();
            }

            _context.Artikli.Remove(artikel);
            await _context.SaveChangesAsync();

            return artikel;
        }

        private bool ArtikelExists(int id)
        {
            return _context.Artikli.Any(e => e.ArtikelID == id);
        }
    }
}
