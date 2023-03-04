using Microsoft.AspNetCore.Mvc;
using ASP_MVC_SitePandas.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Data;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace ASP_MVC_SitePandas.Controllers
{
    [Authorize]
    public class EnfantController : Controller
    {
        
        private readonly LesPetitsPandasContext _context;
        public EnfantController(LesPetitsPandasContext context)
        {
            _context = context;
        }
        
        public async Task <IActionResult> Index()
        {
            var temp = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var vue = _context.Enfants.Include(r => r.Repondant);
            if (User.IsInRole("Admin"))
            {
                return View(await _context.Enfants.Include(r => r.Repondant).ToListAsync());
                //vue = _context.Enfants.Include(r => r.Repondant);
            }
            else
            {
                //vue = (Microsoft.EntityFrameworkCore.Query.IIncludableQueryable<Enfant, Repondant?>)_context.Enfants.Where(e => e.RepondantId == (await _context.Repondants.Where(e => e.UserId == temp).SingleOrDefaultAsync().Id));
                return View(await _context.Enfants.Where(e => e.RepondantId == (_context.Repondants.Where(e => e.UserId == temp).Single().Id)).ToListAsync());
                
            }
           
            //_context.Enfants.Where(e => e.RepondantId == (_context.Repondants.Where(r => r.UserId == temp).SingleOrDefault().Id));
        }
        //Get: Create
        public IActionResult Create() 
        {
            var temp = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (User.IsInRole("Admin"))
            {
                ViewData["RepondanId"] = new SelectList(_context.Repondants, "Id", nameof(Repondant.Prenom));
            }
            else
            {
                ViewData["RepondanId"] = new SelectList(_context.Repondants.Where(r => r.UserId == temp), "Id", nameof(Repondant.Prenom));
            }
            return View();
            
        }
        //Post: Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nom,Prenom,Sexe,DateDeNaissance,DateInscription,ProblemeSante,ProblemeComportement,InformationSupplementaire,RepondantId")]Enfant enfant)
        {
            var temp = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (ModelState.IsValid)
            {
                _context.Add(enfant);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));

            }
            if (User.IsInRole("Admin"))
            {
                ViewData["RepondanId"] = new SelectList(_context.Repondants, "Id", nameof(Repondant.Prenom), enfant.RepondantId);
            }
            else
            {
                ViewData["RepondanId"] = new SelectList(_context.Repondants.Where(r => r.UserId == temp), "Id", nameof(Repondant.Prenom), enfant.RepondantId);
            }
            
            return View(enfant);
        }
        //Get: Edit
        public async Task<IActionResult> Edit(int? id)
        {
            var temp = User.FindFirstValue(ClaimTypes.NameIdentifier); 
            if (id == null || _context.Enfants == null)
            {
                return NotFound();
            }
            var enfant = await _context.Enfants.FindAsync(id);
            if (enfant == null)
            {
                return NotFound();
            }
            if (User.IsInRole("Admin"))
            {
                ViewData["RepondanId"] = new SelectList(_context.Repondants, "Id", nameof(Repondant.Prenom));
            }
            else
            {
                ViewData["RepondanId"] = new SelectList(_context.Repondants.Where(r => r.UserId == temp), "Id", nameof(Repondant.Prenom));
            }
            return View(enfant);
        }
        //Post: Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nom,Prenom,Sexe,DateDeNaissance,DateInscription,ProblemeSante,ProblemeComportement,InformationSupplementaire,RepondantId")]Enfant enfant)
        {
            var temp = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (id != enfant.Id) {

                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(enfant);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EnfantExists(enfant.Id))
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
                ViewData["RepondanId"] = new SelectList(_context.Repondants, "Id", nameof(Repondant.Prenom), enfant.RepondantId);
            }
            else
            {
                ViewData["RepondanId"] = new SelectList(_context.Repondants.Where(r => r.UserId == temp), "Id", nameof(Repondant.Prenom), enfant.RepondantId);
            }
            return View(enfant);
        }
        //Get: Delete
        public async Task<IActionResult> Delete(int? id)
        {
            if(id == null || _context.Enfants == null)
            {
                return NotFound();
            }
            var enfant = await _context.Enfants
                .Include(r => r.Repondant)
                .FirstOrDefaultAsync(e => e.Id == id);
            if (enfant == null)
            {
                return NotFound();
            }
            return View(enfant);
        }
        //Post: Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Enfants == null)
            {
                return Problem("Aucun enfant trouvé");
            }
            var enfant = await _context.Enfants.FindAsync(id);
            if(enfant != null)
            {
                _context.Enfants.Remove(enfant);
            }
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        //Get: Details
        public async Task<IActionResult> Details(int? id)
        {
            if(id == null || _context.Enfants == null)
            {
                return NotFound();
            }
            var enfant = await _context.Enfants.Include(r => r.Repondant)
                .FirstOrDefaultAsync(e => e.Id == id);
            if(enfant == null)
            {
                return NotFound();
            }
            return View(enfant);
        }

        private bool EnfantExists(int id)
        {
            return _context.Enfants.Any(e => e.Id == id);
        }
    }
}
