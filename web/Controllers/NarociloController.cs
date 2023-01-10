using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using aplikacija.Data;
using aplikacija.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace aplikacija.Controllers
{
    [Authorize]
    public class NarociloController : Controller
    {
        private readonly smartbuyContext _context;

        private readonly UserManager<ApplicationUser> _usermanager;

        public NarociloController(smartbuyContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _usermanager = userManager;
        }

        // GET: Narocilo
        public async Task<IActionResult> Index()
        {
            var smartbuyContext = _context.Narocila.Include(n => n.Naslov).Include(n => n.Oseba).Include(n => n.Status).Include(n => n.TipPrevzema);
            return View(await smartbuyContext.ToListAsync());
        }

        // GET: Narocilo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var narocilo = await _context.Narocila
                .Include(n => n.Naslov)
                .Include(n => n.Oseba)
                .Include(n => n.Status)
                .Include(n => n.TipPrevzema)
                .FirstOrDefaultAsync(m => m.NarociloID == id);
            if (narocilo == null)
            {
                return NotFound();
            }

            return View(narocilo);
        }

        // GET: Narocilo/Create
        public IActionResult Create()
        {
            ViewData["NaslovID"] = new SelectList(_context.Naslovi, "NaslovID", "Mesto");
            ViewData["OsebaID"] = new SelectList(_context.Osebe, "OsebaID", "Ime");
            ViewData["StatusID"] = new SelectList(_context.Statusi, "StatusID", "StatusID");
            ViewData["TipPrevzemaID"] = new SelectList(_context.TipiPrevzema, "TipPrevzemaID", "TipPrevzemaID");
            return View();
        }

        // POST: Narocilo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NarociloID,OsebaID,StatusID,NaslovID,TipPrevzemaID,Datum,skupniZnesek")] Narocilo narocilo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(narocilo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["NaslovID"] = new SelectList(_context.Naslovi, "NaslovID", "Mesto", narocilo.NaslovID);
            ViewData["OsebaID"] = new SelectList(_context.Osebe, "OsebaID", "Ime", narocilo.OsebaID);
            ViewData["StatusID"] = new SelectList(_context.Statusi, "StatusID", "StatusID", narocilo.StatusID);
            ViewData["TipPrevzemaID"] = new SelectList(_context.TipiPrevzema, "TipPrevzemaID", "TipPrevzemaID", narocilo.TipPrevzemaID);
            return View(narocilo);
        }

        // GET: Narocilo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var narocilo = await _context.Narocila.FindAsync(id);
            if (narocilo == null)
            {
                return NotFound();
            }
            ViewData["NaslovID"] = new SelectList(_context.Naslovi, "NaslovID", "Mesto", narocilo.NaslovID);
            ViewData["OsebaID"] = new SelectList(_context.Osebe, "OsebaID", "Ime", narocilo.OsebaID);
            ViewData["StatusID"] = new SelectList(_context.Statusi, "StatusID", "StatusID", narocilo.StatusID);
            ViewData["TipPrevzemaID"] = new SelectList(_context.TipiPrevzema, "TipPrevzemaID", "TipPrevzemaID", narocilo.TipPrevzemaID);
            return View(narocilo);
        }

        // POST: Narocilo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("NarociloID,OsebaID,StatusID,NaslovID,TipPrevzemaID,Datum,skupniZnesek")] Narocilo narocilo)
        {
            if (id != narocilo.NarociloID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(narocilo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NarociloExists(narocilo.NarociloID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["NaslovID"] = new SelectList(_context.Naslovi, "NaslovID", "Mesto", narocilo.NaslovID);
            ViewData["OsebaID"] = new SelectList(_context.Osebe, "OsebaID", "Ime", narocilo.OsebaID);
            ViewData["StatusID"] = new SelectList(_context.Statusi, "StatusID", "StatusID", narocilo.StatusID);
            ViewData["TipPrevzemaID"] = new SelectList(_context.TipiPrevzema, "TipPrevzemaID", "TipPrevzemaID", narocilo.TipPrevzemaID);
            return View(narocilo);
        }

        // GET: Narocilo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var narocilo = await _context.Narocila
                .Include(n => n.Naslov)
                .Include(n => n.Oseba)
                .Include(n => n.Status)
                .Include(n => n.TipPrevzema)
                .FirstOrDefaultAsync(m => m.NarociloID == id);
            if (narocilo == null)
            {
                return NotFound();
            }

            return View(narocilo);
        }

        // POST: Narocilo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var narocilo = await _context.Narocila.FindAsync(id);
            _context.Narocila.Remove(narocilo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NarociloExists(int id)
        {
            return _context.Narocila.Any(e => e.NarociloID == id);
        }
    }
}
