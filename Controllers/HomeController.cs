using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CyberU.Models;
using Microsoft.Extensions.Configuration;

namespace CyberU.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public IConfiguration Configuration { get; }

        [BindProperty]
        public Credential Credential { get; set; }

        [BindProperty]
        public EmailCheckModel EmailCheckModel { get; set; }

        public HomeController(ILogger<HomeController> logger, IConfiguration configuration)
        {
            _logger = logger;
            Configuration = configuration;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Education()
        {
            return View();
        }

        public IActionResult Check(EmailCheckModel emailCheckModel)
        {
            return View(emailCheckModel);
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
        public IActionResult About()
        {
            return View();
        }

        public IActionResult Login(Credential credential)
        {
            return View(credential);
        }
        public IActionResult Resources()
        {
            return View();
        }


        public ActionResult GetPartialView(string partialViewName)
        {
            return PartialView(partialViewName);
        }

        [HttpPost]
        public IActionResult LoginAttempt()
        {
            if (Credential.Username != Configuration.GetValue<string>("Username1") || Credential.Password != Configuration.GetValue<string>("Password"))
            {

                Credential = new Credential();
                Credential.Error = "Username or password was incorrect.";
                return RedirectToAction("Login", Credential);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public async Task<IActionResult> CheckEmail()
        {
            if (String.IsNullOrEmpty(EmailCheckModel.Email))
            {
                return RedirectToAction("Check");
            }
            else
            {
                var results = new EmailCheckModel();
                results.Email = EmailCheckModel.Email;
                results.Results = await EmailCheck.CheckEmailAsync(EmailCheckModel.Email);
                return View("Check", results);
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
