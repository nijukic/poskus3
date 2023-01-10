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
    public class OcenaController : Controller
    {
        private readonly smartbuyContext _context;

        private readonly UserManager<ApplicationUser> _usermanager;

        public OcenaController(smartbuyContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _usermanager = userManager;
        }

        // GET: Ocena
        public async Task<IActionResult> Index()
        {
            var smartbuyContext = _context.Ocene.Include(o => o.Artikel).Include(o => o.Oseba);
            return View(await smartbuyContext.ToListAsync());
        }

        // GET: Ocena/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ocena = await _context.Ocene
                .Include(o => o.Artikel)
                .Include(o => o.Oseba)
                .FirstOrDefaultAsync(m => m.OcenaID == id);
            if (ocena == null)
            {
                return NotFound();
            }

            return View(ocena);
        }
        // GET: Ocena/Create
        public IActionResult Create()
        {
            ViewData["ArtikelID"] = new SelectList(_context.Artikli, "ArtikelID", "Naziv");
            ViewData["OsebaID"] = new SelectList(_context.Osebe, "OsebaID", "Ime");
            return View();
        }

        // POST: Ocena/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OcenaID,OsebaID,ArtikelID,Opis,Vrednost,potrjenNakup")] Ocena ocena)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ocena);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ArtikelID"] = new SelectList(_context.Artikli, "ArtikelID", "Naziv", ocena.ArtikelID);
            ViewData["OsebaID"] = new SelectList(_context.Osebe, "OsebaID", "Ime", ocena.OsebaID);
            return View(ocena);
        }
        [Authorize(Roles = "Administrator")]
        // GET: Ocena/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ocena = await _context.Ocene.FindAsync(id);
            if (ocena == null)
            {
                return NotFound();
            }
            ViewData["ArtikelID"] = new SelectList(_context.Artikli, "ArtikelID", "Naziv", ocena.ArtikelID);
            ViewData["OsebaID"] = new SelectList(_context.Osebe, "OsebaID", "Ime", ocena.OsebaID);
            return View(ocena);
        }

        // POST: Ocena/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OcenaID,OsebaID,ArtikelID,Opis,Vrednost,potrjenNakup")] Ocena ocena)
        {
            if (id != ocena.OcenaID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ocena);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OcenaExists(ocena.OcenaID))
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
            ViewData["ArtikelID"] = new SelectList(_context.Artikli, "ArtikelID", "Naziv", ocena.ArtikelID);
            ViewData["OsebaID"] = new SelectList(_context.Osebe, "OsebaID", "Ime", ocena.OsebaID);
            return View(ocena);
        }
        [Authorize(Roles = "Administrator")]
        // GET: Ocena/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ocena = await _context.Ocene
                .Include(o => o.Artikel)
                .Include(o => o.Oseba)
                .FirstOrDefaultAsync(m => m.OcenaID == id);
            if (ocena == null)
            {
                return NotFound();
            }

            return View(ocena);
        }
        [Authorize(Roles = "Administrator")]
        // POST: Ocena/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ocena = await _context.Ocene.FindAsync(id);
            _context.Ocene.Remove(ocena);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OcenaExists(int id)
        {
            return _context.Ocene.Any(e => e.OcenaID == id);
        }
    }
}
