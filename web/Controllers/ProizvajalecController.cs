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
    public class ProizvajalecController : Controller
    {
        private readonly smartbuyContext _context;
        private readonly UserManager<ApplicationUser> _usermanager;

        public ProizvajalecController(smartbuyContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _usermanager = userManager;
        }

        // GET: Proizvajalec
        public async Task<IActionResult> Index()
        {
            return View(await _context.Proizvajalci.ToListAsync());
        }

        // GET: Proizvajalec/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var proizvajalec = await _context.Proizvajalci
                .FirstOrDefaultAsync(m => m.ProizvajalecID == id);
            if (proizvajalec == null)
            {
                return NotFound();
            }

            return View(proizvajalec);
        }
        [Authorize(Roles = "Administrator")]
        // GET: Proizvajalec/Create
        public IActionResult Create()
        {
            return View();
        }   
        [Authorize(Roles = "Administrator")]
        // POST: Proizvajalec/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProizvajalecID,Naziv,Opis")] Proizvajalec proizvajalec)
        {
            if (ModelState.IsValid)
            {
                _context.Add(proizvajalec);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(proizvajalec);
        }
        [Authorize(Roles = "Administrator")]
        // GET: Proizvajalec/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var proizvajalec = await _context.Proizvajalci.FindAsync(id);
            if (proizvajalec == null)
            {
                return NotFound();
            }
            return View(proizvajalec);
        }
        [Authorize(Roles = "Administrator")]
        // POST: Proizvajalec/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProizvajalecID,Naziv,Opis")] Proizvajalec proizvajalec)
        {
            if (id != proizvajalec.ProizvajalecID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(proizvajalec);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProizvajalecExists(proizvajalec.ProizvajalecID))
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
            return View(proizvajalec);
        }
        [Authorize(Roles = "Administrator")]
        // GET: Proizvajalec/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var proizvajalec = await _context.Proizvajalci
                .FirstOrDefaultAsync(m => m.ProizvajalecID == id);
            if (proizvajalec == null)
            {
                return NotFound();
            }

            return View(proizvajalec);
        }
        [Authorize(Roles = "Administrator")]
        // POST: Proizvajalec/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var proizvajalec = await _context.Proizvajalci.FindAsync(id);
            _context.Proizvajalci.Remove(proizvajalec);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProizvajalecExists(int id)
        {
            return _context.Proizvajalci.Any(e => e.ProizvajalecID == id);
        }
    }
}
