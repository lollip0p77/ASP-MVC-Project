using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ASP_MVC_SitePandas.Models;
using Microsoft.AspNetCore.Authorization;

namespace ASP_MVC_SitePandas.Controllers
{
    [Authorize]
    public class TypeEvenementsController : Controller
    {
        private readonly LesPetitsPandasContext _context;

        public TypeEvenementsController(LesPetitsPandasContext context)
        {
            _context = context;
        }

        // GET: TypeEvenements
        public async Task<IActionResult> Index()
        {
              return View(await _context.TypeEvenements.ToListAsync());
        }

        // GET: TypeEvenements/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TypeEvenements == null)
            {
                return NotFound();
            }

            var typeEvenement = await _context.TypeEvenements
                .FirstOrDefaultAsync(m => m.Id == id);
            if (typeEvenement == null)
            {
                return NotFound();
            }

            return View(typeEvenement);
        }

        // GET: TypeEvenements/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TypeEvenements/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TypeEvenement1")] TypeEvenement typeEvenement)
        {
            if (ModelState.IsValid)
            {
                _context.Add(typeEvenement);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(typeEvenement);
        }

        // GET: TypeEvenements/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TypeEvenements == null)
            {
                return NotFound();
            }

            var typeEvenement = await _context.TypeEvenements.FindAsync(id);
            if (typeEvenement == null)
            {
                return NotFound();
            }
            return View(typeEvenement);
        }

        // POST: TypeEvenements/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TypeEvenement1")] TypeEvenement typeEvenement)
        {
            if (id != typeEvenement.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(typeEvenement);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TypeEvenementExists(typeEvenement.Id))
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
            return View(typeEvenement);
        }

        // GET: TypeEvenements/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TypeEvenements == null)
            {
                return NotFound();
            }

            var typeEvenement = await _context.TypeEvenements
                .FirstOrDefaultAsync(m => m.Id == id);
            if (typeEvenement == null)
            {
                return NotFound();
            }

            return View(typeEvenement);
        }

        // POST: TypeEvenements/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TypeEvenements == null)
            {
                return Problem("Entity set 'LesPetitsPandasContext.TypeEvenements'  is null.");
            }
            var typeEvenement = await _context.TypeEvenements.FindAsync(id);
            if (typeEvenement != null)
            {
                _context.TypeEvenements.Remove(typeEvenement);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TypeEvenementExists(int id)
        {
          return _context.TypeEvenements.Any(e => e.Id == id);
        }
    }
}
