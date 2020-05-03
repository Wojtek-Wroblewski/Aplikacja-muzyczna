﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Aplikacja_muzyczna.Models;
using Aplikacja_muzyczna.DBConnect.Artist;

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
                        if (model.Photo.ToString() == "s")
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
                    Add.SaveArtisttoDB(model);
                }
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
