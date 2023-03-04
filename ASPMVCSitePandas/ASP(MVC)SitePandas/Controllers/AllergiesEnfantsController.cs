using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ASP_MVC_SitePandas.Models;
using System.Security.Claims;

namespace ASP_MVC_SitePandas.Controllers
{
    [Authorize]
    public class AllergiesEnfantsController : Controller
    {
        private readonly LesPetitsPandasContext _context;

        public AllergiesEnfantsController(LesPetitsPandasContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var temp = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (User.IsInRole("User"))
            {
                return View(await _context.AllergiesEnfants.Include(a => a.Allergie).Include(e => e.Enfant).Where(e => e.Enfant.RepondantId == (_context.Repondants.Where(r => r.UserId == temp).Single().Id)).ToListAsync());
            }
            else
            {
                return View(await _context.AllergiesEnfants.Include(e => e.Enfant).Include(a => a.Allergie).ToListAsync());
            }
        }

        //Get: Create
        public IActionResult Create()
        {
            var temp = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (User.IsInRole("Admin"))
            {
                ViewData["EnfantId"] = new SelectList(_context.Enfants, "Id", nameof(Enfant.Prenom));
            }
            else
            {
                ViewData["EnfantId"] = new SelectList(_context.Enfants.Where(e => e.RepondantId == (_context.Repondants.Where(r => r.UserId == temp).SingleOrDefault().Id)), "Id", nameof(Enfant.Prenom));
            }
            ViewData["AllergieId"] = new SelectList(_context.Allergies, "Id", nameof(Allergy.Nom));
            return View();
        }

        //Post: Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id, EnfantId, AllergieId, Intervention")] AllergiesEnfant allergiesEnfant)
        {
            var temp = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (ModelState.IsValid)
            {
                _context.Add(allergiesEnfant);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            if (User.IsInRole("Admin"))
            {
                ViewData["EnfantId"] = new SelectList(_context.Enfants, "Id", nameof(Enfant.Prenom), allergiesEnfant.EnfantId);
            }
            else
            {
                ViewData["EnfantId"] = new SelectList(_context.Enfants.Where(e => e.RepondantId == (_context.Repondants.Where(r => r.UserId == temp).SingleOrDefault().Id)), "Id", nameof(Enfant.Prenom), allergiesEnfant.EnfantId);
            }
            ViewData["AllergieId"] = new SelectList(_context.Allergies, "Id", nameof(Allergy.Nom), allergiesEnfant.AllergieId);

            return View(allergiesEnfant);
        }

        //Get: Edit
        public async Task<IActionResult> Edit(int? id)
        {
            var temp = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if(id == null || _context.AllergiesEnfants == null)
            {
                return NotFound();
            }

            var allergieEnfant = await _context.AllergiesEnfants.FindAsync(id);
            if(allergieEnfant == null)
            {
                return NotFound();
            }
            if (User.IsInRole("Admin"))
            {
                ViewData["EnfantId"] = new SelectList(_context.Enfants, "Id", nameof(Enfant.Prenom));
            }
            else
            {
                ViewData["EnfantId"] = new SelectList(_context.Enfants.Where(e => e.RepondantId == (_context.Repondants.Where(r => r.UserId == temp).SingleOrDefault().Id)), "Id", nameof(Enfant.Prenom));
            }
            ViewData["AllergieId"] = new SelectList(_context.Allergies, "Id", nameof(Allergy.Nom));

            return View(allergieEnfant);
        }

        //Post: Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id, EnfantId, AllergieId, Intervention")] AllergiesEnfant allergiesEnfant)
        {
            var temp = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if(id != allergiesEnfant.Id)
            {
                return NotFound();
            }
            if(ModelState.IsValid)
            {
                try
                {
                    _context.Update(allergiesEnfant);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if(!AllergiesEnfantExist(allergiesEnfant.Id))
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
            if (User.IsInRole("Admin"))
            {
                ViewData["EnfantId"] = new SelectList(_context.Enfants, "Id", nameof(Enfant.Prenom), allergiesEnfant.EnfantId);
            }
            else
            {
                ViewData["EnfantId"] = new SelectList(_context.Enfants.Where(e => e.RepondantId == (_context.Repondants.Where(r => r.UserId == temp).SingleOrDefault().Id)), "Id", nameof(Enfant.Prenom), allergiesEnfant.EnfantId);
            }
            ViewData["AllergieId"] = new SelectList(_context.Allergies, "Id", nameof(Allergy.Nom), allergiesEnfant.AllergieId);

            return View(allergiesEnfant);
        }

        //Get: Delete
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.AllergiesEnfants == null)
            {
                return NotFound();
            }
            var allergieEnfant = await _context.AllergiesEnfants
                .Include(e => e.Enfant)
                .Include(a => a.Allergie)
                .FirstOrDefaultAsync(e => e.Id == id);
            if(allergieEnfant == null)
            {
                return NotFound();
            }

            return View(allergieEnfant);
        }

        //Post: Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.AllergiesEnfants == null)
            {
                return Problem("Allergie de l'enfant introuvable..");
            }

            var allergieEnfant = await _context.AllergiesEnfants.FindAsync(id);
            if(allergieEnfant != null)
            {
                _context.AllergiesEnfants.Remove(allergieEnfant);
            }
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        //Get: Details
        public async Task<IActionResult> Details(int? id)
        {
            if(id == null || _context.AllergiesEnfants == null)
            {
                return NotFound();
            }
            var allergieEnfant = await _context.AllergiesEnfants
                .Include(e => e.Enfant)
                .Include(a => a.Allergie)
                .FirstOrDefaultAsync(e => e.Id == id);
            if (allergieEnfant == null)
            {
                return NotFound();
            }

            return View(allergieEnfant);
        }
        private bool AllergiesEnfantExist(int id)
        {
            return _context.AllergiesEnfants.Any(a => a.Id == id);
        }
    }
}
