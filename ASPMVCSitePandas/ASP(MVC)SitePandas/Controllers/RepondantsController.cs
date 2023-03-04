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
    public class RepondantsController : Controller
    {
        private readonly LesPetitsPandasContext _context;

        public RepondantsController(LesPetitsPandasContext context)
        {
            _context = context;
        }

        //Get: Repondants
        public async Task<IActionResult> Index()
        {
            return View(await _context.Repondants.ToListAsync());
        }

        //Get: Create
        public IActionResult Create()
        {
            
            ViewData["UserId"] = new SelectList(_context.AspNetUsers, "Id", nameof(AspNetUser.UserName));
            //R.cupération Data formulaire pour UX
            return View();
        }

        //Post: Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id, Nom, Prenom, Sexe, Adresse, Ville, CodePostal, Courriel, Telephone, CreationDeCompte, RepondantPrincipal, Lien, UserId")] Repondant repondant)
        {
            if (ModelState.IsValid)
            {
                _context.Add(repondant);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] = new SelectList(_context.AspNetUsers, "Id", nameof(AspNetUser.UserName), repondant.UserId);
            //si form en erreur
            return View(repondant);
        }

        //Get: Edit
        public async Task<IActionResult> Edit(int? id)
        {
            var temp = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (User.IsInRole("User"))
            {
                id = _context.Repondants.Where(r => r.Id == (_context.Repondants.Where(e => e.UserId == temp).Single().Id)).Select(r => r.Id).FirstOrDefault();
            }
            if (id == null || _context.Repondants == null)
            {
                return NotFound();
            }
           

            var repondant = await _context.Repondants.FindAsync(id);
            if (repondant == null)
            {
                return NotFound();
            }
            if (User.IsInRole("Admin"))
            {
                ViewData["UserId"] = new SelectList(_context.AspNetUsers, "Id", nameof(AspNetUser.UserName));
            }
            else
            {
                ViewData["UserId"] = new SelectList(_context.AspNetUsers.Where(r => r.Id == temp), "Id", nameof(AspNetUser.UserName));
            }
            return View(repondant);
        }

        //Post: Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id, Nom, Prenom, Sexe, Adresse, Ville, CodePostal, Courriel, Telephone, CreationDeCompte, RepondantPrincipal, Lien, UserId")] Repondant repondant)
        {
            var temp = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (id != repondant.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(repondant);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RepondantExist(repondant.Id))
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
                ViewData["UserId"] = new SelectList(_context.AspNetUsers, "Id", nameof(AspNetUser.UserName), repondant.UserId);
            }
            else
            {
                ViewData["UserId"] = new SelectList(_context.AspNetUsers.Where(r => r.Id == temp), "Id", nameof(AspNetUser.UserName), repondant.UserId);
            }
            return View(repondant);
        }

        //Get: Delete
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Repondants == null)
            {
                return NotFound();
            }

            var repondant = await _context.Repondants
                .FirstOrDefaultAsync(r => r.Id == id);
            if (repondant == null)
            {
                return NotFound();
            }

            return View(repondant);
        }

        //Post: Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Repondants == null)
            {
                return Problem("Repondant introuvable..");
            }

            var repondant = await _context.Repondants.FindAsync(id);
            if (repondant != null)
            {
                _context.Repondants.Remove(repondant);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        //Get: Details
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Repondants == null)
            {
                return NotFound();
            }

            var repondant = await _context.Repondants
                .FirstOrDefaultAsync(r => r.Id == id);
            if (repondant == null)
            {
                return NotFound();
            }

            return View(repondant);
        }

        private bool RepondantExist(int id)
        {
            return _context.Repondants.Any(r => r.Id == id);
        }
    }
}
