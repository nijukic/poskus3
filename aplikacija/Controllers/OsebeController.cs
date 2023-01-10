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
    public class OsebeController : Controller
    {
        private readonly smartbuyContext _context;
        private readonly UserManager<ApplicationUser> _usermanager;

        public OsebeController(smartbuyContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _usermanager = userManager;
        }

        // GET: Osebe
        public async Task<IActionResult> Index(
            string sortOrder,
            string currentFilter,
            string searchString,
            int? pageNumber)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["DateSortParm"] = sortOrder == "Date" ? "date_desc" : "Date";

            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            ViewData["CurrentFilter"] = searchString;

            var osebe = from s in _context.Osebe
                        select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                osebe = osebe.Where(s => s.Priimek.Contains(searchString)
                                       || s.Ime.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    osebe = osebe.OrderByDescending(s => s.Priimek);
                    break;
                case "Date":
                    osebe = osebe.OrderBy(s => s.Telefon);
                    break;
                case "date_desc":
                    osebe = osebe.OrderByDescending(s => s.Telefon);
                    break;
                default:
                    osebe = osebe.OrderBy(s => s.Priimek);
                    break;
            }
            int pageSize = 20;
            return View(await PaginatedList<Oseba>.CreateAsync(osebe.AsNoTracking(), pageNumber ?? 1, pageSize));
        }
        [Authorize(Roles = "Administrator")]
        // GET: Osebe/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var oseba = await _context.Osebe
                .Include(s => s.Ocene)
                    .ThenInclude(e => e.Artikel)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.OsebaID == id);
            if (oseba == null)
            {
                return NotFound();
            }

            return View(oseba);
        }
        [Authorize(Roles = "Administrator")]
        // GET: Osebe/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Osebe/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Ime,Priimek,Telefon")] Oseba oseba)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(oseba);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (DbUpdateException /* ex */)
            {
                //Log the error (uncomment ex variable name and write a log.
                ModelState.AddModelError("", "Unable to save changes. " +
                    "Try again, and if the problem persists " +
                    "see your system administrator.");
            }
            return View(oseba);
        }

        // GET: Osebe/Edit/5
        [Authorize(Roles = "Staff, Administrator")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var oseba = await _context.Osebe.FindAsync(id);
            if (oseba == null)
            {
                return NotFound();
            }
            return View(oseba);
        }

        // POST: Osebe/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator, Staff")]
        public async Task<IActionResult> Edit(int id, [Bind("OsebaID,Ime,Priimek,Telefon")] Oseba oseba)
        {
            if (id != oseba.OsebaID)
            {
                return NotFound();
            }

            var currentUser = await _usermanager.GetUserAsync(User);
            if (ModelState.IsValid)
            {
                try
                {
                    oseba.Owner = currentUser;

                    _context.Update(oseba);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OsebaExists(oseba.OsebaID))
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
            return View(oseba);
        }

        // GET: Osebe/Delete/5
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var oseba = await _context.Osebe
                .FirstOrDefaultAsync(m => m.OsebaID == id);
            if (oseba == null)
            {
                return NotFound();
            }

            return View(oseba);
        }

        // POST: Osebe/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var oseba = await _context.Osebe.FindAsync(id);
            _context.Osebe.Remove(oseba);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OsebaExists(int id)
        {
            return _context.Osebe.Any(e => e.OsebaID == id);
        }
    }
}
