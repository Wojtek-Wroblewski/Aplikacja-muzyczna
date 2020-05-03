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
            DodajArtysta model = new DodajArtysta()
            {
                ArtId = 1,
                DataUr = DateTime.Now,
                Nazwa1 = "ASD",
                Nazwa2 = "fgh",
                Uwaga = "dhfg"
            };

            return View(model);
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



        public ActionResult List()
        {
            List<DodajArtysta> lista = new List<DodajArtysta>();

            DodajArtysta model1 = new DodajArtysta()
            {
                ArtId = 1,
                DataUr = DateTime.Now,
                Nazwa1 = "1ASD",
                Nazwa2 = "1fgh",
                Uwaga = "1dhfg"
            };
            DodajArtysta model2 = new DodajArtysta()
            {
                ArtId = 2,
                DataUr = DateTime.Now,
                Nazwa1 = "2ASD",
                Nazwa2 = "2fgh",
                Uwaga = "2dhfg"
            };
            DodajArtysta model3 = new DodajArtysta()
            {
                ArtId = 3,
                DataUr = DateTime.Now,
                Nazwa1 = "3ASD",
                Nazwa2 = "3fgh",
                Uwaga = "3dhfg"
            };
            DodajArtysta model4 = new DodajArtysta()
            {
                ArtId = 4,
                DataUr = DateTime.Now,
                Nazwa1 = "4ASD",
                Nazwa2 = "4fgh",
                Uwaga = "4dhfg"
            };
            DodajArtysta model5 = new DodajArtysta()
            {
                ArtId = 5,
                DataUr = DateTime.Now,
                Nazwa1 = "4ASD",
                Nazwa2 = "4fgh",
                Uwaga = "4dhfg"
            };
            lista.Add(model1);
            lista.Add(model2);
            lista.Add(model3);
            lista.Add(model4);
            lista.Add(model5);

            return View(lista);
        }

    }
}
