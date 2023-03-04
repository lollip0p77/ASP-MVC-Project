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
    public class AllergiesController : Controller
    {
        private readonly LesPetitsPandasContext _context;
        public AllergiesController(LesPetitsPandasContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _context.Allergies.ToListAsync());
        }

        //Get: Create
        public IActionResult Create()
        {
            return View();
        }

        //Post: Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id, Nom")] Allergy allergies)
        {
            if (ModelState.IsValid)
            {
                _context.Add(allergies);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(allergies);
        }

        //Get: Edit
        public async Task<IActionResult> Edit(int? id)
        {
            if(id == null || _context.Allergies == null)
            {
                return NotFound();
            }

            var allergie = await _context.Allergies.FindAsync(id);
            if (allergie == null)
            {
                return NotFound();
            }

            return View(allergie);
        }

        //Post: Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id, Nom")] Allergy allergies)
        {
            if(id != allergies.Id)
            {
                return NotFound();
            }
            if(ModelState.IsValid)
            {
                try
                {
                    _context.Update(allergies);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AllergieExist(allergies.Id))
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
            return View(allergies) ;
        }

        //Get: Delete
        public async Task<IActionResult> Delete(int? id)
        {
            if(id == null || _context.Allergies == null)
            {
                return NotFound();
            }

            var allergies = await _context.Allergies
                .FirstOrDefaultAsync(a => a.Id == id);
            if(allergies == null)
            {
                return NotFound();
            }

            return View(allergies);
        }

        //Post: Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if(_context.Allergies == null)
            {
                return Problem("Allergie introuvable...");
            }

            var allergie = await _context.Allergies.FindAsync(id);
            if(allergie != null)
            {
                _context.Allergies.Remove(allergie);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AllergieExist(int id)
        {
            return _context.Allergies.Any(a => a.Id == id);
        }
    }
}
