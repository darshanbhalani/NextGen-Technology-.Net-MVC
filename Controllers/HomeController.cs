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
        public IActionResult Contactus(Query data)
        {
            if(ModelState.IsValid)
            {
                _queryHandler.saveData(data);
                TempData["SuccessMessage"] = "Record saved successfully.";
                _queryHandler.sendEmailToClient(data);
                ModelState.Clear();
            }

            return View();
        }

        public IActionResult Careers()
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
