using ASP_MVC_SitePandas.Models;
using FileSignatures.Formats;
using FileSignatures;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using Microsoft.AspNetCore.Authorization;

namespace ASP_MVC_SitePandas.Controllers
{
    [Authorize]
    public class DocumentsGeneralesController1 : Controller
    {
        private readonly LesPetitsPandasContext _context;
        private readonly IWebHostEnvironment environment;
        public DocumentsGeneralesController1(LesPetitsPandasContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            environment = hostEnvironment;
        }

        [HttpGet("download2")]
        public IActionResult Download(int? id)
        {
            var docGeneral = _context.DocumentsGenerales.Find(id);
            var filepath = Path.Combine(environment.WebRootPath, "DocumentsGenerales", docGeneral.DocumentLien);
            return File(System.IO.File.ReadAllBytes(filepath), "*/pdf", System.IO.Path.GetFileName(filepath));
        }
        public async Task<IActionResult> Index()
        {
            return View(await _context.DocumentsGenerales.ToListAsync());
        }

        private string UploadedDocument(DocumentsViewModel documents)
        {
            string uniqueFileName = "";

            if(documents.DocFile != null)
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
            return View();
        }

        //Post: Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DocumentsViewModel documents)
        {
            if(ModelState.IsValid)
            {
                string uri = "";

                using (var ms = new MemoryStream())
                {
                    documents.DocFile.CopyTo(ms);
                    uri = UploadedDocument(documents);
                    //var inspector = new FileFormatInspector();
                    //var format = inspector.DetermineFileFormat(ms);

                    //if(format is Pdf) 
                    //{
                    //    uri = UploadedDocument(documents);
                    //}
                    //else
                    //{
                    //    ViewData["typeError"] = "Type de fichier invalide.. Sélectionné un fichier de type PDF..";
                    //    return View();
                    //}
                }

                var doc = new DocumentsGenerale();
                doc.Nom = documents.DocNom;
                doc.DocumentLien = uri;

                _context.Add(doc);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index));
        }

        //Get: Delete
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.DocumentsGenerales == null)
            {
                return NotFound();
            }
            var docGenerale = await _context.DocumentsGenerales
                .FirstOrDefaultAsync(d => d.Id == id);
            if (docGenerale == null)
            {
                return NotFound();
            }
            return View(docGenerale);
        }

        //Post: Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.DocumentsGenerales == null)
            {
                return Problem("Document introuvable..");
            }

            var docGenerale = await _context.DocumentsGenerales.FindAsync(id);
            if(docGenerale != null)
            {
                _context.Remove(docGenerale);
            }
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
