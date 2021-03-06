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
using PagedList;

namespace Aplikacja_muzyczna.Controllers
{
    public class ArtistController : Controller
    {
        // GET: Artysta
        public ActionResult IndexArtist()
        {
            return View();
        }

        // GET: Artysta/Details/5
        public ActionResult DetailsArtist(DetailArtist model)
        {

            if (Url.RequestContext.RouteData.Values["id"] != null )
            { 
                int ArtistId = (int)Double.Parse(Url.RequestContext.RouteData.Values["id"].ToString());
                model = DetailArtistDB.DetailFromId(ArtistId);
            }
            else
            {
               return RedirectToAction("ListArtist");
            }
            var dupa = model.Birthdate.ToString();
            var ad = dupa;
            /*
             Po create
            "31.12.2020 00:00:00 +01:00" 

             */
            return View(model);
        }

        // GET: Artysta/Create
        public ActionResult CreateArtist()
        {
            Cookies.Today();
            return View();
        }

        // POST: Artysta/Create
        [Authorize]
        [HttpPost]
        public ActionResult CreateArtist(Models.AddArtist model, HttpPostedFileBase file)
        {
            var dupa= model.Birthdate.ToString();
            var ad = dupa;

            /*
             "31.12.2020 00:00:00 +01:00"
             */

            model.File = file;
            if (ModelState.IsValid)
            {
                if (model.File != null)
                {

                    /*TODO zamienic tuple na OUT*/

                    byte[] Photo = null;
                    string Error = null;
                    //Tuple<byte[], string> Photo_error = ArtistFunctions.VerifyPhoto(model.File);
                     ArtistFunctions.VerifyPhoto(model.File, out Photo, out Error);

                   // if (Photo_error.Item1 == null)
                    if (Photo == null)
                    {
                        ModelState.AddModelError("", Error);
                       // ModelState.AddModelError("", Photo_error.Item2);
                        return View();
                    }
                    model.Photo = Photo;
                    //model.Photo = Photo_error.Item1;
                }

                model.AddedBy = User.Identity.Name.ToString();

                int NewId =  AddArtistDB.SaveArtisttoDB(model);
                if (NewId !=0)
                {
                return RedirectToAction("DetailsArtist", new { id = NewId });
                }
                else
                {
                    /*TODO 
                     Jakiś error skrein do dodawania artysty*/
                }

            }
                return View();
        }

        // GET: Artysta/Edit
        [Authorize (Roles = "Admin, Mod")]
        public ActionResult EditArtist()
        {
            if (Url.RequestContext.RouteData.Values["id"] != null)
            {
                int ArtistId = (int)Double.Parse(Url.RequestContext.RouteData.Values["id"].ToString());
                DetailArtist model = DetailArtistDB.DetailFromId(ArtistId);
                Cookies.CreateDay(model.Birthdate);
                Cookies.Today();
                return View(model);
            }
            else
            {
                return RedirectToAction("ListArtist");
            }
        }

        // POST: Artysta/Edit
        [HttpPost]
        [Authorize(Roles = "Admin, Mod")]
        public ActionResult EditArtist(DetailArtist model, HttpPostedFileBase file)
        {
            if (Url.RequestContext.RouteData.Values["id"] != null)
            {
                model.ArtistId = (int)Double.Parse(Url.RequestContext.RouteData.Values["id"].ToString());
            }

            if (model.File != null)
            {
                var Photo_error = new Tuple<byte[], string>(null, null);
               // Photo_error = ArtistFunctions.VerifyPhoto(model.File);
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
                Cookies.RemoveCookie("BirthDate");
                return RedirectToAction("DetailsArtist", new { id = NewModelfromDB .ArtistId });
            }
            return View(NewModelfromDB);
        }

        // GET: Artysta/Delete
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteArtist()
        {
            /*TODO
            Znajdz artyste po id 
            wyjątke na brak id 
            sprawdz czy ma uprawnienia, obsłużyc rolami?
             */
            return View();
        }

        // POST: Artysta/Delete
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteArtist(AddArtist model)
        {
            /*TODO
            cały mózg usuwania, sprawdzenie czy usunięto pomyślnie, i ekran po usuniciu udanym i po failu 
             */
            return RedirectToAction("ListArtist");
        }

        
        public ActionResult ListArtist(int? Page, string sortOrder, List<DetailArtist> List)
        {
            int PageSize = 10;
            int PageNumber = (Page ?? 1);
            if (List!= null)
            {
                return View(List.ToPagedList(PageNumber, PageSize));
            }
            else
            {

            List = ListingArtistDB.SelectAll();

            ViewBag.LastNameSortParm = String.IsNullOrEmpty(sortOrder) ? "LastNameDesc" : "LastName";
            ViewBag.DateSortParm = sortOrder == "Date" ? "DateDesc" : "Date";
            ViewBag.FirstNameSortParm = sortOrder == "FirstName" ? "FirstNameDesc" : "FirstName";

            List = ArtistFunctions.OrderListArtist(List, sortOrder);

            return View(List.ToPagedList(PageNumber, PageSize));
            }

        }



    }
}
