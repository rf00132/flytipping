using DatabaseManager;
using DatabaseManager.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Web.Helpers;

namespace DatabaseManager.Controllers
{
    public class DatabaseManagerController : Controller
    {
        private readonly ILogger<DatabaseManagerController> _logger;
        public static Report reportToDelete = new Report();
        public DatabaseManagerController(ILogger<DatabaseManagerController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            ViewBag.Title = "Report Flytipping In Your Area";
            return RedirectToAction("Dashboard");
        }

        public IActionResult Report()
        {
            ViewBag.Title = "Report Flytipping In Your Area";
            return View();
        }

        public IActionResult Dashboard()
        {
            ViewBag.Title = "Flytipping Dashboard";
            return View();
        }

        [ActionName("Report"), HttpPost]
        public IActionResult Report(string address, string description, string email, string phoneNumber, string coords)
        {
            
            Report reportToAdd = new Report()
            {
                Address = ModelState["Address"].AttemptedValue,
                Coordinates = ModelState["Coords"].AttemptedValue,
                PhoneNumber = ModelState["PhoneNumber"].AttemptedValue,
                Email = ModelState["Email"].AttemptedValue,
                TimeOfReport = DateTime.Now.ToString(),
                Description = ModelState["Description"].AttemptedValue
            };
            DatabaseManagement.AddReportToDb(reportToAdd);
            
            return RedirectToAction("Dashboard");
        }

        public IActionResult ReportDelete()
        {
            ViewBag.Title = "Delete Report";
            return View();
        }

        public ActionResult DeleteReport(string deleteReport)
        {
            using (Context context = new Context())
            {
                DatabaseManagement.SelectedReport = context.Reports.Find(Int32.Parse(deleteReport));
            }
            return RedirectToAction("ReportDelete");

        }

        public ActionResult ConfirmDelete()
        {
            using (Context context = new Context())
            {
                DatabaseManagement.DeleteReportFromDb(DatabaseManagement.SelectedReport);
            }
            return RedirectToAction("Dashboard");
        }
        public IActionResult ReportComplete()
        {
            ViewBag.Title = "Complete Report";
            return View();
        }

        public ActionResult MarkReportCompleted(string completeReport)
        {
            using (Context context = new Context())
            {
                DatabaseManagement.SelectedReport = context.Reports.Find(Int32.Parse(completeReport));
            }
            return RedirectToAction("ReportComplete");
        }

        public ActionResult ConfirmComplete()
        {
            using (Context context = new Context())
            {
                DatabaseManagement.MarkReportComplete(DatabaseManagement.SelectedReport);
            }
            return RedirectToAction("Dashboard");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}