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
    public class NaslovController : Controller
    {
        private readonly smartbuyContext _context;

        private readonly UserManager<ApplicationUser> _usermanager;

        public NaslovController(smartbuyContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _usermanager = userManager;
        }

        // GET: Naslov
        public async Task<IActionResult> Index()
        {
            var smartbuyContext = _context.Naslovi.Include(n => n.Oseba);
            return View(await smartbuyContext.ToListAsync());
        }

        // GET: Naslov/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var naslov = await _context.Naslovi
                .Include(n => n.Oseba)
                .FirstOrDefaultAsync(m => m.NaslovID == id);
            if (naslov == null)
            {
                return NotFound();
            }

            return View(naslov);
        }

        // GET: Naslov/Create
        public IActionResult Create()
        {
            ViewData["OsebaID"] = new SelectList(_context.Osebe, "OsebaID", "Ime");
            return View();
        }

        // POST: Naslov/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NaslovID,OsebaID,HisnaSt,Ulica,Posta,Mesto")] Naslov naslov)
        {
            if (ModelState.IsValid)
            {
                _context.Add(naslov);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["OsebaID"] = new SelectList(_context.Osebe, "OsebaID", "Ime", naslov.OsebaID);
            return View(naslov);
        }

        // GET: Naslov/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var naslov = await _context.Naslovi.FindAsync(id);
            if (naslov == null)
            {
                return NotFound();
            }
            ViewData["OsebaID"] = new SelectList(_context.Osebe, "OsebaID", "Ime", naslov.OsebaID);
            return View(naslov);
        }

        // POST: Naslov/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("NaslovID,OsebaID,HisnaSt,Ulica,Posta,Mesto")] Naslov naslov)
        {
            if (id != naslov.NaslovID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(naslov);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NaslovExists(naslov.NaslovID))
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
            ViewData["OsebaID"] = new SelectList(_context.Osebe, "OsebaID", "Ime", naslov.OsebaID);
            return View(naslov);
        }

        // GET: Naslov/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var naslov = await _context.Naslovi
                .Include(n => n.Oseba)
                .FirstOrDefaultAsync(m => m.NaslovID == id);
            if (naslov == null)
            {
                return NotFound();
            }

            return View(naslov);
        }

        // POST: Naslov/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var naslov = await _context.Naslovi.FindAsync(id);
            _context.Naslovi.Remove(naslov);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NaslovExists(int id)
        {
            return _context.Naslovi.Any(e => e.NaslovID == id);
        }
    }
}
