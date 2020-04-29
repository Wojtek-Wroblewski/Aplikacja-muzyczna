using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Aplikacja_muzyczna.Models;

namespace Aplikacja_muzyczna.Controllers
{
    public class ArtystaController : Controller
    {
        // GET: Artysta
        public ActionResult Index()
        {
            return View();
        }

        // GET: Artysta/Details/5
        public ActionResult Details()
        {
            return View();
        }

        // GET: Artysta/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Artysta/Create
        [HttpPost]
        public ActionResult Create(DodajArtysta model)
        {
            
                return View();
        }

        // GET: Artysta/Edit/5
        public ActionResult Edit()
        {
            return View();
        }

        // POST: Artysta/Edit/5
        [HttpPost]
        public ActionResult Edit(DodajArtysta model)
        {
                return View();
        }

        // GET: Artysta/Delete/5
        public ActionResult Delete()
        {
            return View();
        }

        // POST: Artysta/Delete/5
        [HttpPost]
        public ActionResult Delete(DodajArtysta model)
        {
                return View();
        }



        public ActionResult Dupa()
        {
            
                return View();
        }

    }
}
