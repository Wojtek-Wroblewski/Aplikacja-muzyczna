using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
    }
}