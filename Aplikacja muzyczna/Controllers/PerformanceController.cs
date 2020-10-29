using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Aplikacja_muzyczna.Functions;
using Aplikacja_muzyczna.Models;
using Aplikacja_muzyczna.DBConnect.Artist;
using Aplikacja_muzyczna.DBConnect.Track;

namespace Aplikacja_muzyczna.Controllers
{
    public class PerformanceController : Controller
    {
        // GET: Performance
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Create(AddPerformance model)
        {
            

            return RedirectToAction("Details", new { PerformenceId = model.PerformanceId });
        }

        public ActionResult Details()
        {

            return View();
        }

    }
}