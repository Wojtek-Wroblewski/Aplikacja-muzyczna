using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Aplikacja_muzyczna.Controllers
{
    public class TrackController : Controller
    {
        // GET: Track
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create ()
        {
            return View();
        }
    }
}