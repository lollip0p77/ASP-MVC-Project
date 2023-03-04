using Microsoft.AspNetCore.Mvc;
using ASP_MVC_SitePandas.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ASP_MVC_SitePandas.Controllers
{
    [Authorize]
    public class EducatricesController : Controller
    {
        private readonly LesPetitsPandasContext _context;

        public EducatricesController(LesPetitsPandasContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _context.Educatrices.ToListAsync());
        }
        //Get: Create
        public IActionResult Create()
        {
            ViewData["UserId"] = new SelectList(_context.AspNetUsers, "Id", nameof(AspNetUser.UserName));
            return View();
        }
        //Post: Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nom,Prenom,Sexe,Adresse,Ville,CodePostal,DateDeNaissance,DateDembauche,DateDeFinDemploi,Salaire,Telephone,UserId")] Educatrice educatrice)
        {
            if (ModelState.IsValid)
            {
                _context.Add(educatrice);
                await _context.SaveChangesAsync();



                return RedirectToAction(nameof(Index));
            }

            ViewData["UserId"] = new SelectList(_context.AspNetUsers, "Id", nameof(AspNetUser.UserName), educatrice.UserId);

            return View(educatrice);
        }
        //Get: Edit
        public async Task<IActionResult> Edit(int? id)
        {
            if(id == null || _context.Educatrices == null)
            {
                return NotFound();
            }
            var garderie = await _context.Educatrices.FindAsync(id);
            if(garderie == null)
            {
                return NotFound();
            }
            ViewData["UserId"] = new SelectList(_context.AspNetUsers, "Id", nameof(AspNetUser.UserName));
            return View(garderie);
        }
        //Post: Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nom,Prenom,Sexe,Adresse,Ville,CodePostal,DateDeNaissance,DateDembauche,DateDeFinDemploi,Salaire,Telephone,UserId")] Educatrice educatrice)
        {
            if(id != educatrice.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(educatrice);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!educatriceExists(educatrice.Id))
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
            ViewData["UserId"] = new SelectList(_context.AspNetUsers, "Id", nameof(AspNetUser.UserName), educatrice.UserId);
            return View(educatrice);
        }
        //Get: Delete
        public async Task<IActionResult> Delete(int? id)
        {
            if(id == null || _context.Educatrices == null)
            {
                return NotFound();
            }
            var educatrice = await _context.Educatrices
                .FirstOrDefaultAsync(e => e.Id == id);
            if(educatrice == null)
            {
                return NotFound();
            }
            return View(educatrice);
        }
        //Post: Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
           if(_context.Educatrices == null)
            {
                return Problem("Aucunne éducatrices trouvés");
            }
            var educatrice = await _context.Educatrices.FindAsync(id);
            if(educatrice != null)
            {
                _context.Educatrices.Remove(educatrice);
            }
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        //Get: Details
        public async Task<IActionResult> Details(int? id)
        {
            if(id == null || _context.Educatrices == null)
            {
                return NotFound();
            }
            var educatrice = await _context.Educatrices
                .FirstOrDefaultAsync(e => e.Id == id);
            if (educatrice == null)
            {
                return NotFound();
            }
            return View(educatrice);
        }
        private bool educatriceExists(int id)
        {
            return _context.Educatrices.Any(e => e.Id == id);
        }
    }
}
