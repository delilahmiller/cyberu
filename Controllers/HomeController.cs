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
        private readonly ApplicationDbContext _db;
        public IConfiguration Configuration { get; }

        [BindProperty]
        public Credential Credential { get; set; }

        [BindProperty]
        public EmailCheckModel EmailCheckModel { get; set; }

        [BindProperty]
        public Breach Breach { get; set; }

        [BindProperty]
        public List<Breach> BreachList { get; set; }

        public HomeController(ILogger<HomeController> logger, IConfiguration configuration, ApplicationDbContext db)
        {
            _logger = logger;
            Configuration = configuration;
            _db = db;
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
            BreachList = _db.Breaches.ToList();
            return View(BreachList);
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

        public IActionResult Admin()
        {
            BreachList = _db.Breaches.ToList();
            return View(BreachList);
        }

        public IActionResult AdminEdit(int? id)
        {
            Breach = new Breach();

            if (id == null)
            {
                return View(Breach);
            }

            Breach = _db.Breaches.FirstOrDefault(x => x.Id == id);

            if (id == null)
            {
                Breach = new Breach();
                return View(Breach);
            }

            return View(Breach);
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
                return RedirectToAction("Admin");
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

        [HttpPost]
        public IActionResult UpsertBreach()
        {
            if (Breach.Id == 0)
            {
                _db.Breaches.Add(Breach);
            }
            else
            {
                _db.Breaches.Update(Breach);
            }

            _db.SaveChanges();

            return RedirectToAction("Admin");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
