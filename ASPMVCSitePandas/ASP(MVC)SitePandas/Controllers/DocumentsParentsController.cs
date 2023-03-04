using ASP_MVC_SitePandas.Models;
using FileSignatures.Formats;
using FileSignatures;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Security.Claims;
using NuGet.Protocol.Plugins;
using Microsoft.AspNetCore.Authorization;

namespace ASP_MVC_SitePandas.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]
    [Authorize]
    public class DocumentsParentsController : Controller
    {
        private readonly LesPetitsPandasContext _context;
        private readonly IWebHostEnvironment environment;
        public DocumentsParentsController(LesPetitsPandasContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            environment = hostEnvironment;
        }
        [HttpGet("download")]
        public IActionResult Download(int? id)
        {
            var docParent = _context.DocumentsParents.Find(id);
            var filepath = Path.Combine(environment.WebRootPath, "DocumentsGenerales", docParent.DocumentLien);
            return File(System.IO.File.ReadAllBytes(filepath), "*/pdf", System.IO.Path.GetFileName(filepath));
        }
        public async Task<IActionResult> Index()
        {
            var temp = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (User.IsInRole("Admin"))
            {
                return View(await _context.DocumentsParents.Include(r => r.Repondant).ToListAsync());
            }
            else
            {
                return View(await _context.DocumentsParents.Include(r => r.Repondant).Where( r => r.RepondantId == (_context.Repondants.Where(r => r.UserId == temp).Single().Id)).ToListAsync());
            }    
        }

        //Upload
        private string UploadedDocument(DocumentsParentViewModel documents)
        {
            string uniqueFileName = "";

            if (documents.DocFile != null)
            {
                string uploadsFolder = "wwwroot/DocumentsGenerales/";
                uniqueFileName = Guid.NewGuid().ToString() + "_" + documents.DocFile.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    documents.DocFile.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }

        //Get: Create
        public IActionResult Create()
        {
            ViewData["RepondantId"] = new SelectList(_context.Repondants, "Id", nameof(Repondant.Prenom));
            return View();
        }

        //Post: Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DocumentsParentViewModel documents)
        {
            if(ModelState.IsValid)
            {
                string uri = "";

                using (var ms = new MemoryStream())
                {
                    documents.DocFile.CopyTo(ms);

                    //var inspector = new FileFormatInspector();
                    //var format = inspector.DetermineFileFormat(ms);
                    uri = UploadedDocument(documents);
                    //if (format is Pdf)
                    //{
                    //    uri = UploadedDocument(documents);
                    //}
                    //else
                    //{
                        
                    //    ViewData["typeError"] = "Type de fichier invalide.. Sélectionné un fichier de type PDF..";
                    //    return View();
                    //}
                }

                var doc = new DocumentsParent();
                doc.Nom = documents.DocNom;
                doc.RepondantId = documents.FkRepondant;
                doc.DocumentLien = uri;

                _context.Add(doc);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["RepondantId"] = new SelectList(_context.Repondants, "Id", nameof(Repondant.Prenom), documents.FkRepondant);
            return RedirectToAction(nameof(Index));
        }

        //Get: Delete
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.DocumentsParents == null)
            {
                return NotFound();
            }
            var docRepondant = await _context.DocumentsParents
                .Include(r => r.Repondant)
                .FirstOrDefaultAsync(d => d.Id == id);
            if (docRepondant == null)
            {
                return NotFound();
            }
            return View(docRepondant);
        }

        //Post: Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.DocumentsParents == null)
            {
                return Problem("Document introuvable..");
            }

            var docRepondant = await _context.DocumentsParents.FindAsync(id);
            if (docRepondant != null)
            {
                _context.Remove(docRepondant);
            }
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
