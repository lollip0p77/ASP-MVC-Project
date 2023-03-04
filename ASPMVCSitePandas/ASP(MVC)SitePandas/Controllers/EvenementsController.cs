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
    public class EvenementsController : Controller
    {
        private readonly LesPetitsPandasContext _context;

        public EvenementsController(LesPetitsPandasContext context)
        {
            _context = context;
        }

        // GET: Evenements
        public async Task<IActionResult> Index()
        {
            var lesPetitsPandasContext = _context.Evenements.Include(e => e.Type);
            return View(await lesPetitsPandasContext.ToListAsync());
        }

        // GET: Evenements/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Evenements == null)
            {
                return NotFound();
            }

            var evenement = await _context.Evenements
                .Include(e => e.Type)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (evenement == null)
            {
                return NotFound();
            }

            return View(evenement);
        }

        // GET: Evenements/Create
        public IActionResult Create()
        {
            ViewData["TypeId"] = new SelectList(_context.TypeEvenements, "Id", nameof(TypeEvenement.TypeEvenement1));
            return View();
        }

        // POST: Evenements/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Titre,Description,Cout,HeureDebut,HeureFin,TypeId")] Evenement evenement)
        {
            if (ModelState.IsValid)
            {
                _context.Add(evenement);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TypeId"] = new SelectList(_context.TypeEvenements, "Id", nameof(TypeEvenement.TypeEvenement1), evenement.TypeId);
            return View(evenement);
        }

        // GET: Evenements/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Evenements == null)
            {
                return NotFound();
            }

            var evenement = await _context.Evenements.FindAsync(id);
            if (evenement == null)
            {
                return NotFound();
            }
            ViewData["TypeId"] = new SelectList(_context.TypeEvenements, "Id", nameof(TypeEvenement.TypeEvenement1), evenement.TypeId);
            return View(evenement);
        }

        // POST: Evenements/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Titre,Description,Cout,HeureDebut,HeureFin,TypeId")] Evenement evenement)
        {
            if (id != evenement.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(evenement);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EvenementExists(evenement.Id))
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
            ViewData["TypeId"] = new SelectList(_context.TypeEvenements, "Id", nameof(TypeEvenement.TypeEvenement1), evenement.TypeId);
            return View(evenement);
        }

        // GET: Evenements/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Evenements == null)
            {
                return NotFound();
            }

            var evenement = await _context.Evenements
                .Include(e => e.Type)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (evenement == null)
            {
                return NotFound();
            }

            return View(evenement);
        }

        // POST: Evenements/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Evenements == null)
            {
                return Problem("Entity set 'LesPetitsPandasContext.Evenements'  is null.");
            }
            var evenement = await _context.Evenements.FindAsync(id);
            if (evenement != null)
            {
                _context.Evenements.Remove(evenement);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EvenementExists(int id)
        {
          return _context.Evenements.Any(e => e.Id == id);
        }
    }
}
