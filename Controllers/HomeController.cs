using Humanizer;
using Microsoft.AspNetCore.Mvc;
using NextGen_Technology.Models;
using NextGen_Technology.Repo.Classes;
using NextGen_Technology.Repo.Interfaces;
using Npgsql;
using System.Diagnostics;

namespace NextGen_Technology.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IQueryHandler _queryHandler = new QueryHandler();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public IActionResult Contactus()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Contactus(Query data)
        {
            
             _queryHandler.saveData(data);
            _queryHandler.sendEmailToClient(data);

            return Json(new { success = true, message = "Login successful" });
        }

        public IActionResult Careers()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Error(int? statusCode = null)
        {
            if (statusCode.HasValue && statusCode == 404)
            {
                return View("NotFound");
            }
            return View();
        }

    }
}
