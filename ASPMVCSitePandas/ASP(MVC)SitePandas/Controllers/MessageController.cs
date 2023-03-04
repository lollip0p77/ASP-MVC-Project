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
    public class MessageController : Controller
    {
        private readonly LesPetitsPandasContext _context;
        public MessageController(LesPetitsPandasContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            if (User.IsInRole("Admin"))
            {
                var nameLists = _context.Repondants.Select(r => new NameList
                {
                    Nom = r.Nom,
                    Prenom = r.Prenom,
                    UserId = r.Id
                });
                return View(await nameLists.ToListAsync());
            }
            else
            {
                var nameLists = _context.Educatrices.Select(r => new NameList
                {
                    Nom = r.Nom,
                    Prenom = r.Prenom,
                    UserId = r.Id
                });
                return View(await nameLists.ToListAsync());
            }


        }
        public async Task<IActionResult> Message(int? Id)
        {
            var temp = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (User.IsInRole("Admin"))
            {
                var connectedId = _context.Educatrices.Where(e => e.UserId == temp).Select(e => e.Id).FirstOrDefault();
                ViewData["Educatrice"] = _context.Educatrices.Where(e => e.UserId == temp).Select(e => e.Prenom + " " + e.Nom).FirstOrDefault().ToString();
                ViewData["Repondant"] = _context.Repondants.Where(r => r.Id == Id).Select(r => r.Prenom + " " + r.Nom).FirstOrDefault().ToString();
                ViewData["Role"] = "E";
                ViewData["IDeducatrice"] = connectedId;
                ViewData["IDrepondant"] = _context.Repondants.Where(r => r.Id == Id).Select(r => r.Id).FirstOrDefault();
                return View(await _context.Messages.Where(m => m.EducatriceId == connectedId && m.RepondantId == Id).ToListAsync());
            }
            else
            {
                var connectedId = _context.Repondants.Where(r => r.UserId == temp).Select(r => r.Id).FirstOrDefault();
                ViewData["Educatrice"] = _context.Educatrices.Where(e => e.Id == Id).Select(e => e.Prenom + " " + e.Nom).FirstOrDefault().ToString();
                ViewData["Repondant"] = _context.Repondants.Where(r => r.UserId == temp).Select(r => r.Prenom + " " + r.Nom).FirstOrDefault().ToString();
                ViewData["Role"] = "R";
                ViewData["IDeducatrice"] = _context.Educatrices.Where(e => e.Id == Id).Select(e => e.Id).FirstOrDefault();
                ViewData["IDrepondant"] = connectedId;
                return View(await _context.Messages.Where(m => m.EducatriceId == Id && m.RepondantId == connectedId).ToListAsync());
            }
        }
    }
}
