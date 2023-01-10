using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using aplikacija.Data;
using aplikacija.Models;

namespace aplikacija.Controllers_api
{
    [Route("api/[controller]")]
    [ApiController]
    public class KategorijaApiController : ControllerBase
    {
        private readonly smartbuyContext _context;

        public KategorijaApiController(smartbuyContext context)
        {
            _context = context;
        }

        // GET: api/KategorijaApi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Kategorija>>> GetKategorije()
        {
            return await _context.Kategorije.ToListAsync();
        }

        // GET: api/KategorijaApi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Kategorija>> GetKategorija(int id)
        {
            var kategorija = await _context.Kategorije.FindAsync(id);

            if (kategorija == null)
            {
                return NotFound();
            }

            return kategorija;
        }

        // PUT: api/KategorijaApi/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutKategorija(int id, Kategorija kategorija)
        {
            if (id != kategorija.KategorijaID)
            {
                return BadRequest();
            }

            _context.Entry(kategorija).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KategorijaExists(id))
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

        // POST: api/KategorijaApi
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Kategorija>> PostKategorija(Kategorija kategorija)
        {
            _context.Kategorije.Add(kategorija);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetKategorija", new { id = kategorija.KategorijaID }, kategorija);
        }

        // DELETE: api/KategorijaApi/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Kategorija>> DeleteKategorija(int id)
        {
            var kategorija = await _context.Kategorije.FindAsync(id);
            if (kategorija == null)
            {
                return NotFound();
            }

            _context.Kategorije.Remove(kategorija);
            await _context.SaveChangesAsync();

            return kategorija;
        }

        private bool KategorijaExists(int id)
        {
            return _context.Kategorije.Any(e => e.KategorijaID == id);
        }
    }
}
