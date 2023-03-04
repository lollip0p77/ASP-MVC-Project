using ASP_MVC_SitePandas.Models;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;

namespace ASP_MVC_SitePandas.Controllers
{
    [Authorize]
    //[Produces("application/json")]
    //[Route("api/Events")]
    public class EvenementController : Controller
    {
        private readonly LesPetitsPandasContext _context;

        public EvenementController(LesPetitsPandasContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var events = _context.Evenements.Select(e => new EventListe
            {
                Id = e.Id,
                Titre = e.Titre,
                Description = e.Description,
                HeureDebut = e.HeureDebut,
                HeureFin = e.HeureFin
                //e.HeureDebut.ToString("dd/MM/yyyy"),
                //e.HeureFin.ToString("dd/MM/yyyy")
            });
            return View(await events.ToListAsync());
        }
        public IActionResult EvenementListe()
        {
            return View();
        }
    }
}
