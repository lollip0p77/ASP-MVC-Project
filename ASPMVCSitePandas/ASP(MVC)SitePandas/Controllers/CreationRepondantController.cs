using Microsoft.AspNetCore.Mvc;
using ASP_MVC_SitePandas.Models;
namespace ASP_MVC_SitePandas.Controllers
{
    public class CreationRepondantController : Controller
    {
        private readonly LesPetitsPandasContext _lesPetitsPandasContext;

        public CreationRepondantController(LesPetitsPandasContext context)
        {
            _lesPetitsPandasContext = context;
        }
        public IActionResult Index()
        {
            
            return View();
        }
    }
}
