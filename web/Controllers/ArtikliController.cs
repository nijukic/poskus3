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
    public class ArtikliController : Controller
    {
        private readonly smartbuyContext _context;

        private readonly UserManager<ApplicationUser> _usermanager;

        public ArtikliController(smartbuyContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _usermanager = userManager;
        }

        // GET: 
        public async Task<IActionResult> Index(
            string sortOrder,
            string currentFilter,
            string searchString,
            int? pageNumber)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["CenaSortParm"] = String.IsNullOrEmpty(sortOrder) ? "cena_desc" : "";

            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewData["CurrentFilter"] = searchString;

            var artikli = from s in _context.Artikli
                          select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                artikli = artikli.Where(s => s.Naziv.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "cena_desc":
                    artikli = artikli.OrderByDescending(s => s.Cena);
                    break;
                default:
                    artikli = artikli.OrderBy(s => s.Cena);
                    break;
            }
            int pageSize = 20;
            return View(await PaginatedList<Artikel>.CreateAsync(artikli.AsNoTracking(), pageNumber ?? 1, pageSize));
        }

        // GET: Artikli/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var artikel = await _context.Artikli
                .Include(s => s.Proizvajalec)
                .Include(f => f.Kategorija)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ArtikelID == id);
            if (artikel == null)
            {
                return NotFound();
            }

            /*
            if (User.IsInRole("admin")) //whatever your admin role is called
            {
                return View(artikel);
            }

            if (User.IsInRole("user"))
            {
                return View("IndexUser");
            }

            return View("Whatever"); //or RedirectToAction(...)
                */
                
            return View(artikel);
        }
        [Authorize(Roles = "Administrator, Zaposlen")]
        // GET: Artikli/Create
        public IActionResult Create()
        {
            PopulateProizvajalciDropDownList();
            PopulateKategorijeDropDownList();
            return View();
        }
        [Authorize(Roles = "Administrator, Zaposlen")]
        // POST: Artikli/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ArtikelID,Naziv,Opis,Cena,ProizvajalecID, KategorijaID")] Artikel artikel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(artikel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            PopulateProizvajalciDropDownList(artikel.ProizvajalecID);
            PopulateKategorijeDropDownList(artikel.KategorijaID);
            return View(artikel);
        }
        [Authorize(Roles = "Administrator, Zaposlen")]
        // GET: Artikli/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var artikel = await _context.Artikli
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ArtikelID == id);
            if (artikel == null)
            {
                return NotFound();
            }
            PopulateProizvajalciDropDownList(artikel.ProizvajalecID);
            PopulateKategorijeDropDownList(artikel.KategorijaID);
            return View(artikel);
        }
        [Authorize(Roles = "Administrator, Zaposlen")]
        // POST: Artikli/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPost(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var artikelToUpdate = await _context.Artikli
                .FirstOrDefaultAsync(c => c.ArtikelID == id);

            if (await TryUpdateModelAsync<Artikel>(artikelToUpdate,
                "",
                c => c.Naziv, c => c.Opis, c => c.ProizvajalecID))
            {
                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateException /* ex */)
                {
                    //Log the error (uncomment ex variable name and write a log.)
                    ModelState.AddModelError("", "Unable to save changes. " +
                        "Try again, and if the problem persists, " +
                        "see your system administrator.");
                }
                return RedirectToAction(nameof(Index));
            }
            PopulateProizvajalciDropDownList(artikelToUpdate.ProizvajalecID);
            PopulateKategorijeDropDownList(artikelToUpdate.KategorijaID);
            return View(artikelToUpdate);
        }

        private void PopulateProizvajalciDropDownList(object selectedProizvajalec = null)
        {
            var proizvajalciQuery = from d in _context.Proizvajalci
                                    orderby d.Naziv
                                    select d;
            ViewBag.ProizvajalecID = new SelectList(proizvajalciQuery.AsNoTracking(), "ProizvajalecID", "Naziv", selectedProizvajalec);
        }



        private void PopulateKategorijeDropDownList(object selectedKategorija = null)
        {
            var kategorijeQuery = from d in _context.Kategorije
                                  orderby d.Naziv
                                  select d;
            ViewBag.KategorijaID = new SelectList(kategorijeQuery.AsNoTracking(), "KategorijaID", "Naziv", selectedKategorija);
        }
        [Authorize(Roles = "Administrator, Zaposlen")]
        // GET: Artikli/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var artikel = await _context.Artikli
                .FirstOrDefaultAsync(m => m.ArtikelID == id);
            if (artikel == null)
            {
                return NotFound();
            }

            return View(artikel);
        }
        [Authorize(Roles = "Administrator, Zaposlen")]
        // POST: Artikli/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var artikel = await _context.Artikli.FindAsync(id);
            _context.Artikli.Remove(artikel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ArtikelExists(int id)
        {
            return _context.Artikli.Any(e => e.ArtikelID == id);
        }
    }
}
