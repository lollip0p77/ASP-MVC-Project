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

namespace ASP_MVC_SitePandas.Controllers
{
    [Authorize]
    public class ListeAttenteController : Controller
    {
        private readonly LesPetitsPandasContext _context;

        public ListeAttenteController(LesPetitsPandasContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.ListeDattentes.ToListAsync());
        }

        //Get: Create
        public IActionResult Create()
        {
            return View();
        }

        //Post: Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index([Bind("Id,Nom,Prenom,Telephone,Couriel,NombreEnfants,Description")] ListeDattente listeDattente)
        {
            if (ModelState.IsValid)
            {
                _context.Add(listeDattente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(listeDattente);
        }

        //Get: Edit
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ListeDattentes == null) 
            { 
                return NotFound();
            }

            var listAttente = await _context.ListeDattentes.FindAsync(id);
            if (listAttente == null)
            {
                return NotFound();
            }
            return View(listAttente);
        }

        //Post: Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nom,Prenom,Telephone,Couriel,NombreEnfants,Description")] ListeDattente listeDattente)
        {
            if (id != listeDattente.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(listeDattente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if(!ListeDattenteExist(listeDattente.Id))
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
            return View(listeDattente);
        }

        //Get: Delete
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ListeDattentes == null) 
            { 
                return NotFound();
            }

            var listDattente = await _context.ListeDattentes
                .FirstOrDefaultAsync(x => x.Id == id);
            if (listDattente == null)
            {
                return NotFound();
            }

            return View(listDattente);
        }

        //Post: Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ListeDattentes == null)
            {
                return Problem("Client introuvable..");
            }

            var listDattente = await _context.ListeDattentes.FindAsync(id);
            if (listDattente != null)
            {
                _context.ListeDattentes.Remove(listDattente);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        //Get: Details
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ListeDattentes == null)
            {
                return NotFound();
            }

            var listDattente = await _context.ListeDattentes
                .FirstOrDefaultAsync(c => c.Id == id);
            if (listDattente == null)
            {
                return NotFound();
            }

            return View(listDattente);
        }

        private bool ListeDattenteExist(int id)
        {
            return _context.ListeDattentes.Any(l => l.Id == id);
        }
    }
}
