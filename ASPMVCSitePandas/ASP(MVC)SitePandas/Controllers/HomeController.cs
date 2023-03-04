using ASP_MVC_SitePandas.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ASP_MVC_SitePandas.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly LesPetitsPandasContext _context;

        public HomeController(ILogger<HomeController> logger, LesPetitsPandasContext context)
        {
            _logger = logger;
            _context= context;
        }

        public IActionResult Index()
        {
            return View();
        }

        //InscriptionPost
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

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}