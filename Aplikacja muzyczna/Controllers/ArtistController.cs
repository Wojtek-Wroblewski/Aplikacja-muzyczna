﻿using System;
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

            if (TempData["JustAddedArtist"] != null)
            {
                model = TempData["JustAddedArtist"] as DetailArtist;
                TempData.Remove("JustAddedArtist");
            }
            else
            { 
                int ArtId = (int)Double.Parse(Url.RequestContext.RouteData.Values["id"].ToString());
                model = DetailArtistDB.DetailFromId(ArtId);
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
                    var Photo_error = new Tuple< byte[],string>(null, null);
                    Photo_error = ArtistFunction.VerifyPhoto( model.File);
                    if (Photo_error.Item1 != null)
                    { 
                    ModelState.AddModelError("", Photo_error.Item2);
                        return View();
                    }
                    model.Photo = Photo_error.Item1;
                }
                AddArtistDB.SaveArtisttoDB(model);
                var ConfigAddtoDetail = new MapperConfiguration(cfg => cfg.CreateMap<Models.AddArtist, DetailArtist>());
                var MapAddtoDetail = ConfigAddtoDetail.CreateMapper();
                var modelDetail = MapAddtoDetail.Map<DetailArtist>(model);
                TempData["JustAddedArtist"] = modelDetail;
                return RedirectToAction("Details");
            }
                return View();
        }

        // GET: Artysta/Edit
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

        // POST: Artysta/Edit
        [HttpPost]
        public ActionResult Edit(DetailArtist model, HttpPostedFileBase file)
        {
            if (Url.RequestContext.RouteData.Values["id"] != null)
            {
                model.ArtId = (int)Double.Parse(Url.RequestContext.RouteData.Values["id"].ToString());
            }

            if (model.File != null)
            {
                var Photo_error = new Tuple<byte[], string>(null, null);
                Photo_error = ArtistFunction.VerifyPhoto(model.File);
                if (Photo_error.Item2 != null)
                {
                    ModelState.AddModelError("", Photo_error.Item2);
                    return View();
                }
                model.Photo = Photo_error.Item1;
            }


            DetailArtist NewModelfromDB = new DetailArtist();
            NewModelfromDB = EditArtistDB.EditArtist(model);
            if (model != NewModelfromDB)
            {
                return RedirectToAction("Details", new { id = NewModelfromDB .ArtId});
            }
            return View(NewModelfromDB);
        }

        // GET: Artysta/Delete
        public ActionResult Delete()
        {
            return View();
        }

        // POST: Artysta/Delete
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
