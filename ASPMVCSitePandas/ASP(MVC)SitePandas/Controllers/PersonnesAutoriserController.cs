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
    public class PersonnesAutoriserController : Controller
    {
        private readonly LesPetitsPandasContext _context;
        public PersonnesAutoriserController(LesPetitsPandasContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var temp = User.FindFirstValue(ClaimTypes.NameIdentifier);
            
            
            if (User.IsInRole("User"))
            {
                ViewData["EnfantId"] = new SelectList(_context.Enfants.Where(e => e.RepondantId == (_context.Repondants.Where(r => r.UserId == temp).SingleOrDefault().Id)), "Id", nameof(Enfant.Prenom));
                //return View(await _context.PersonnesAutorisers.Include(e => e.Enfant).Where(e => e.Enfant.RepondantId == (_context.Repondants.Where(r => r.UserId == temp).Single().Id)).ToListAsync());
            }
            else
            {
                ViewData["EnfantId"] = new SelectList(_context.Enfants, "Id", nameof(Enfant.Prenom));
                
            }
            return View();

        }
        
        [HttpGet]
        public JsonResult GetDetailByEnfantID(int enfantId)
        {
            var persoAuto = _context.PersonnesAutorisers.Where(e => e.EnfantId == enfantId).ToList();
            JsonResponseViewModel model = new JsonResponseViewModel();
            if (persoAuto.Count != 0)
            {
                model.ResponseCode = 0;
                model.ResponseMessage = JsonConvert.SerializeObject(persoAuto);
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
        public async Task<IActionResult> Create([Bind("Id,Nom,Prenom,Telephone,ContactUrgence,LienEnfant,EnfantId")] PersonnesAutoriser personnesAutoriser)
        {
            var temp = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (ModelState.IsValid)
            {
                _context.Add(personnesAutoriser);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));

            }
            if (User.IsInRole("Admin"))
            {
                ViewData["EnfantId"] = new SelectList(_context.Enfants, "Id", nameof(Enfant.Prenom), personnesAutoriser.EnfantId);
            }
            else
            {
                ViewData["EnfantId"] = new SelectList(_context.Enfants.Where(e => e.RepondantId == (_context.Repondants.Where(r => r.UserId == temp).SingleOrDefault().Id)), "Id", nameof(Enfant.Prenom), personnesAutoriser.EnfantId);
            }
            return View(personnesAutoriser);
        }
        //Get: Edit
        public async Task<IActionResult> Edit(int? id)
        {
            var temp = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (id == null || _context.PersonnesAutorisers == null)
            {
                return NotFound();
            }
            var personnes = await _context.PersonnesAutorisers.FindAsync(id);
            if (personnes == null)
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
            return View(personnes);
        }
        //Post: Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nom,Prenom,Telephone,ContactUrgence,LienEnfant,EnfantId")] PersonnesAutoriser personnesAutoriser)
        {
            var temp = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (id != personnesAutoriser.Id)
            {

                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(personnesAutoriser);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PersonnesAutoriserExists(personnesAutoriser.Id))
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
                ViewData["EnfantId"] = new SelectList(_context.Enfants, "Id", nameof(Enfant.Prenom), personnesAutoriser.EnfantId);
            }
            else
            {
                ViewData["EnfantId"] = new SelectList(_context.Enfants.Where(e => e.RepondantId == (_context.Repondants.Where(r => r.UserId == temp).SingleOrDefault().Id)), "Id", nameof(Enfant.Prenom), personnesAutoriser.EnfantId);
            }
            return View(personnesAutoriser);
        }
        //Get: Delete
        public async Task<IActionResult> Delete(int? id)
        {
            if(id == null || _context.PersonnesAutorisers == null)
            {
                return NotFound();
            }
            var personnes = await _context.PersonnesAutorisers
                .FirstOrDefaultAsync(e => e.Id == id);
            if(personnes == null)
            {
                return NotFound(); 
            }
            return View(personnes);
        }
        //Post: Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.PersonnesAutorisers == null )
            {
                return Problem("Aucun enfant trouvé");
            }
            var personnes = await _context.PersonnesAutorisers.FindAsync(id);
            if(personnes != null)
            {
                _context.PersonnesAutorisers.Remove(personnes);
            }
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        //Get: Details
        public async Task<IActionResult> Details(int? id)
        {
            if(id == null || _context.PersonnesAutorisers == null)
            {
                return NotFound();
            }
            var personnes = await _context.PersonnesAutorisers.Include(e => e.Enfant)
                .FirstOrDefaultAsync(e => e.Id == id);
            if(personnes == null)
            {
                return NotFound();
            }
            return View(personnes);
        }
        private bool PersonnesAutoriserExists(int id)
        {
            return _context.PersonnesAutorisers.Any(e => e.Id == id);
        }
    }
}
