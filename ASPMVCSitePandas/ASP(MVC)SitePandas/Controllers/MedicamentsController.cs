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
using Newtonsoft.Json;

namespace ASP_MVC_SitePandas.Controllers
{
    [Authorize]
    public class MedicamentsController : Controller
    {
        private readonly LesPetitsPandasContext _context;

        public MedicamentsController(LesPetitsPandasContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var temp = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (User.IsInRole("User"))
            {
                ViewData["EnfantId"] = new SelectList(_context.Enfants.Where(e => e.RepondantId == (_context.Repondants.Where(r => r.UserId == temp).SingleOrDefault().Id)), "Id", nameof(Enfant.Prenom));
                return View(await _context.Medicaments.Include(e => e.Enfant).Where(e => e.Enfant.RepondantId == (_context.Repondants.Where(r => r.UserId == temp).Single().Id)).ToListAsync());
            }
            else
            {
                ViewData["EnfantId"] = new SelectList(_context.Enfants, "Id", nameof(Enfant.Prenom));
                return View(await _context.Medicaments.Include(e => e.Enfant).ToListAsync());
            }
            
        }

        [HttpGet]
        public JsonResult GetDetailByEnfantID(int enfantId)
        {
            var medicaments = _context.Medicaments.Where(e => e.EnfantId == enfantId).ToList();
            JsonResponseViewModelMedicament model = new JsonResponseViewModelMedicament();
            if (medicaments.Count != 0)
            {
                model.ResponseCode = 0;
                model.ResponseMessage = JsonConvert.SerializeObject(medicaments);
            }
            else
            {
                model.ResponseCode = 1;
                model.ResponseMessage = "Pas de personne autoriser trouvé";
            }
            return Json(model);
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
            
            return View();
        }

        //Post: Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nom,Description,EnfantId")] Medicament medicament)
        {
            var temp = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (ModelState.IsValid)
            {
                _context.Add(medicament);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            if (User.IsInRole("Admin"))
            {
                ViewData["EnfantId"] = new SelectList(_context.Enfants, "Id", nameof(Enfant.Prenom), medicament.EnfantId);
            }
            else
            {
                ViewData["EnfantId"] = new SelectList(_context.Enfants.Where(e => e.RepondantId == (_context.Repondants.Where(r => r.UserId == temp).SingleOrDefault().Id)), "Id", nameof(Enfant.Prenom), medicament.EnfantId);
            }
            
            return View(medicament);
        }

        //Get: Edit
        public async Task<IActionResult> Edit(int? id)
        {
            var temp = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (id == null || _context.Medicaments == null)
            {
                return NotFound();
            }

            var medicament = await _context.Medicaments.FindAsync(id);
            if (medicament == null)
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
            

            return View(medicament);
        }

        //Post: Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nom,Description,EnfantId")] Medicament medicament)
        {
            var temp = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (id != medicament.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(medicament);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MedicamentExist(medicament.Id))
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
                ViewData["EnfantId"] = new SelectList(_context.Enfants, "Id", nameof(Enfant.Prenom), medicament.EnfantId);
            }
            else
            {
                ViewData["EnfantId"] = new SelectList(_context.Enfants.Where(e => e.RepondantId == (_context.Repondants.Where(r => r.UserId == temp).SingleOrDefault().Id)), "Id", nameof(Enfant.Prenom), medicament.EnfantId);
            }
            
            return View(medicament);
        }

        //Get: Delete
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Medicaments == null)
            {
                return NotFound();
            }

            var medicament = await _context.Medicaments
                .Include(e => e.Enfant)
                .FirstOrDefaultAsync(e => e.Id == id);
            if (medicament == null)
            {
                return NotFound();
            }

            return View(medicament);
        }

        //Post: Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Medicaments == null)
            {
                return Problem("Medicament introuvable..");
            }

            var medicament = await _context.Medicaments.FindAsync(id);
            if (medicament != null) 
            { 
                _context.Medicaments.Remove(medicament);
            }
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        //Get: Details
        public async Task<IActionResult> Details(int? id)
        {
            if(id == null || _context.Medicaments == null)
            {
                return NotFound();
            }
            var medicament = await _context.Medicaments
                .Include(e => e.Enfant)
                .FirstOrDefaultAsync(e => e.Id == id);
            if (medicament == null)
            {
                return NotFound();
            }

            return View(medicament);
        }
        private bool MedicamentExist(int id)
        {
            return _context.Medicaments.Any(m => m.Id == id);
        }
    }
}
