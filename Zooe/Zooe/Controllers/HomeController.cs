using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Zooe.Models;

namespace Zooe.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Sourvenirs()
        {
            return View();
        }

        public IActionResult Index()
        {
            return View();
        }

        //Do not move, we need to make a database entity, model, and controller for ticket.
        public IActionResult TicketIndex()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Cart()
        {
            return View();
        }
        public IActionResult Checkout()
        {
            return View();
        }
        public IActionResult Admin()
        {
            return View();
        }
        public IActionResult TicketCheckout()
        {
            return View();
        }
        public IActionResult Card()
        {
            return View();
        }
        
        public IActionResult Report()
        {
            Models.ReportContext context = HttpContext.RequestServices.GetService(typeof(Models.ReportContext)) as Models.ReportContext;

            return View(context.GetReports());
        }

        [HttpPost]
        public IActionResult Report(Models.ReportModel model)
        {
            Models.ReportContext context = HttpContext.RequestServices.GetService(typeof(Models.ReportContext)) as Models.ReportContext;

            return View(context.GetReports(model));
        }

        public IActionResult ReportT()
        {
            Models.ReportContext context = HttpContext.RequestServices.GetService(typeof(Models.ReportContext)) as Models.ReportContext;

            return View(context.GetReportsT());
        }

        [HttpPost]
        public IActionResult ReportT(Models.ReportModelT model)
        {
            Models.ReportContext context = HttpContext.RequestServices.GetService(typeof(Models.ReportContext)) as Models.ReportContext;

            return View(context.GetReportsT(model));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
