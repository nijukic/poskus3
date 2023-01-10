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
    public class KategorijaController : Controller
    {
        private readonly smartbuyContext _context;

        private readonly UserManager<ApplicationUser> _usermanager;

        public KategorijaController(smartbuyContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _usermanager = userManager;
        }

        // GET: Kategorija
        public async Task<IActionResult> Index()
        {
            return View(await _context.Kategorije.ToListAsync());
        }

        // GET: Kategorija/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kategorija = await _context.Kategorije
                .FirstOrDefaultAsync(m => m.KategorijaID == id);
            if (kategorija == null)
            {
                return NotFound();
            }

            return View(kategorija);
        }
        [Authorize(Roles = "Administrator")]
        // GET: Kategorija/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Kategorija/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Administrator")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("KategorijaID,Naziv")] Kategorija kategorija)
        {
            if (ModelState.IsValid)
            {
                _context.Add(kategorija);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(kategorija);
        }

        // GET: Kategorija/Edit/5
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kategorija = await _context.Kategorije.FindAsync(id);
            if (kategorija == null)
            {
                return NotFound();
            }
            return View(kategorija);
        }

        // POST: Kategorija/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Administrator")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("KategorijaID,Naziv")] Kategorija kategorija)
        {
            if (id != kategorija.KategorijaID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(kategorija);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KategorijaExists(kategorija.KategorijaID))
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
            return View(kategorija);
        }

        [Authorize(Roles = "Administrator")]
        // GET: Kategorija/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kategorija = await _context.Kategorije
                .FirstOrDefaultAsync(m => m.KategorijaID == id);
            if (kategorija == null)
            {
                return NotFound();
            }

            return View(kategorija);
        }

        // POST: Kategorija/Delete/5
        [Authorize(Roles = "Administrator")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var kategorija = await _context.Kategorije.FindAsync(id);
            _context.Kategorije.Remove(kategorija);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KategorijaExists(int id)
        {
            return _context.Kategorije.Any(e => e.KategorijaID == id);
        }
    }
}
