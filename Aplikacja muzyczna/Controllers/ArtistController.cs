using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Aplikacja_muzyczna.Models;
using Aplikacja_muzyczna.DBConnect.Artist;
using AutoMapper;
using AutoMapper.Configuration;

namespace Aplikacja_muzyczna.Controllers
{
    public class ArtistController : Controller
    {
        // GET: Artysta
        public ActionResult Index()
        {
            return View();
        }

        // GET: Artysta/Details/5
        public ActionResult Details(DetailArtist model)
        {
            if (TempData["JustAddedArtist"] != null)
            {
                model = TempData["JustAddedArtist"] as DetailArtist;
            }

            return View(model);
        }

        // GET: Artysta/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Artysta/Create
        [HttpPost]
        public ActionResult Create(AddArtist model, HttpPostedFileBase file)
        {
            model.File = file;
            if (ModelState.IsValid)
            {

                if (model.File != null)
                {
                    model.Photo = ArtFunction.PhotoBytefromfile(file);
                    if (model.Photo.Length == 1)
                    {
                        if (model.Photo.ToString() == "S")
                        {

                            ModelState.AddModelError("CustomError", "File to large");
                            return View();
                        }
                        else if (model.Photo.ToString() == "F")
                        {
                            ModelState.AddModelError("CustomError", "Bad format ");
                            return View();
                        }
                    }
                    else if (model.Photo.Length == 0)
                    {
                        ModelState.AddModelError("CustomError", "Something went wrong");
                        return View();
                    }
                }

                Add.SaveArtisttoDB(model);
                var ConfigAddtoDetail = new MapperConfiguration(cfg => cfg.CreateMap<AddArtist, DetailArtist>());
                var MapAddtoDetail = ConfigAddtoDetail.CreateMapper();
                var modelDetail = MapAddtoDetail.Map<DetailArtist>(model);
                TempData["JustAddedArtist"]= modelDetail;

                return RedirectToAction("Details");
            }
                return View();
        }

        // GET: Artysta/Edit/5
        public ActionResult Edit()
        {

            return View();
        }

        // POST: Artysta/Edit/5
        [HttpPost]
        public ActionResult Edit(AddArtist model)
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
        public ActionResult Delete(AddArtist model)
        {
                return View();
        }

        
        public ActionResult List()
        {
            return View();
        }

    }
}
