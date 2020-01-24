using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AspNetTest.Models;
using AspNetTest.Repository;

namespace AspNetTest.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private SqlRepository repository;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            repository = new SqlRepository(logger);
        }

        public IActionResult Index()
        {
            var model = new HomeViewModel();
            model.Users = repository.GetUsers();
            return View(model);
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

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(User user)
        {
            repository.CreateUser(user);
            return RedirectToAction("Index");
        }
    }
}
