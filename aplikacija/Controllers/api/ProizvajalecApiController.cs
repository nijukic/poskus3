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
    public class ProizvajalecApiController : ControllerBase
    {
        private readonly smartbuyContext _context;

        public ProizvajalecApiController(smartbuyContext context)
        {
            _context = context;
        }

        // GET: api/ProizvajalecApi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Proizvajalec>>> GetProizvajalci()
        {
            return await _context.Proizvajalci.ToListAsync();
        }

        // GET: api/ProizvajalecApi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Proizvajalec>> GetProizvajalec(int id)
        {
            var proizvajalec = await _context.Proizvajalci.FindAsync(id);

            if (proizvajalec == null)
            {
                return NotFound();
            }

            return proizvajalec;
        }

        // PUT: api/ProizvajalecApi/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProizvajalec(int id, Proizvajalec proizvajalec)
        {
            if (id != proizvajalec.ProizvajalecID)
            {
                return BadRequest();
            }

            _context.Entry(proizvajalec).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProizvajalecExists(id))
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

        // POST: api/ProizvajalecApi
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Proizvajalec>> PostProizvajalec(Proizvajalec proizvajalec)
        {
            _context.Proizvajalci.Add(proizvajalec);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProizvajalec", new { id = proizvajalec.ProizvajalecID }, proizvajalec);
        }

        // DELETE: api/ProizvajalecApi/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Proizvajalec>> DeleteProizvajalec(int id)
        {
            var proizvajalec = await _context.Proizvajalci.FindAsync(id);
            if (proizvajalec == null)
            {
                return NotFound();
            }

            _context.Proizvajalci.Remove(proizvajalec);
            await _context.SaveChangesAsync();

            return proizvajalec;
        }

        private bool ProizvajalecExists(int id)
        {
            return _context.Proizvajalci.Any(e => e.ProizvajalecID == id);
        }
    }
}
