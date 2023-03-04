using Microsoft.AspNetCore.Mvc;
using ASP_MVC_SitePandas.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace ASP_MVC_SitePandas.Controllers
{
    [Authorize]
    public class GarderieController : Controller
    {
        private readonly LesPetitsPandasContext _context;

        public GarderieController(LesPetitsPandasContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _context.Garderies.ToListAsync());
        }
        //Get: Edit
        public async Task<IActionResult> Edit(int? id = 1)
        {
            if(id == null || _context.Garderies == null )
            {
                return NotFound();
            }
            var garderie = await _context.Garderies.FindAsync(id);
            if(garderie == null)
            {
                return NotFound();
            }
            return View(garderie);
        }
        //post: Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nom,Adresse,Ville,CodePostal,Telephone,Description")] Garderie garderie)
        {
            if(id != garderie.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(garderie);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GarderieExists(garderie.Id))
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
            return View(garderie);
        }

        private bool GarderieExists(int id)
        {
            return _context.Garderies.Any(e => e.Id == id);
        }
    }
}
