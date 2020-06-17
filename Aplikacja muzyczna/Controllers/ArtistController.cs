using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Aplikacja_muzyczna.Models;
using Aplikacja_muzyczna.DBConnect.Artist;
using AutoMapper;
using AutoMapper.Configuration;
using Aplikacja_muzyczna.Functions;

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

            int ArtId = (int)Double.Parse(Url.RequestContext.RouteData.Values["id"].ToString());
            model = DetailArtistDB.DetailFromId(ArtId); 

            if (TempData["JustAddedArtist"] != null)
            {
                model = TempData["JustAddedArtist"] as DetailArtist;
                TempData.Remove("JustAddedArtist");
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
        public ActionResult Create(Models.AddArtist model, HttpPostedFileBase file)
        {
            model.File = file;
            if (ModelState.IsValid)
            {

                if (model.File != null)
                {
                    model.Photo = ArtistFunction.PhotoBytefromfile(file);
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

                AddArtistDB.SaveArtisttoDB(model);
                var ConfigAddtoDetail = new MapperConfiguration(cfg => cfg.CreateMap<Models.AddArtist, DetailArtist>());
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

            if (Url.RequestContext.RouteData.Values["id"] != null)
            {

                int ArtId = (int)Double.Parse(Url.RequestContext.RouteData.Values["id"].ToString());
                DetailArtist model = DetailArtistDB.DetailFromId(ArtId);
                return View(model);

            }
            else
            {
                return RedirectToAction("List");
            }
        }

        // POST: Artysta/Edit/5
        [HttpPost]
        public ActionResult Edit(DetailArtist model, HttpPostedFileBase file)
        {
            if (Url.RequestContext.RouteData.Values["id"] != null)
            {
                int ArtId = (int)Double.Parse(Url.RequestContext.RouteData.Values["id"].ToString());
                model.ArtId = ArtId;
            }
            DetailArtist Updatedmodel = new DetailArtist();
            Updatedmodel = EditArtistDB.EditArtist(model);
            if (model!= Updatedmodel)
            {
                return RedirectToAction("Details");
            }
            return View();
        }

        // GET: Artysta/Delete/5
        public ActionResult Delete()
        {
            return View();
        }

        // POST: Artysta/Delete/5
        [HttpPost]
        public ActionResult Delete(Models.AddArtist model)
        {
            return RedirectToAction("List");
        }

        
        public ActionResult List()
        {

            List<DetailArtist> List = new List<DetailArtist>();
            List = ListingArtistDB.SelectAll();

            return View(List);
        }
        [HttpPost]
        public ActionResult List(List<DetailArtist> Lista)
        {



            return View(Lista);
        }

    }
}
