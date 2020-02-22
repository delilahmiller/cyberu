using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CyberU.Models;

namespace CyberU.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Education()
        {
            return View();
        }

        public IActionResult Check()
        {
            return View();
        }
        public IActionResult Breaches()
        {
            return View();
        }

        public IActionResult Passwords()
        {
            return View();
        }
        public IActionResult AntiVirus()
        {
            return View();
        }
        public IActionResult Backups()
        {
            return View();
        }
        public IActionResult HTTPS()
        {
            return View();
        }
        public IActionResult Phishing()
        {
            return View();
        }
        public IActionResult SafeBrowsing()
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
