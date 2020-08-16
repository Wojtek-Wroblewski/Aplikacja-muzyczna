using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Aplikacja_muzyczna.Functions;
using Aplikacja_muzyczna.Models;
using Aplikacja_muzyczna.DBConnect.Artist;

namespace Aplikacja_muzyczna.Controllers
{
    public class TrackController : Controller
    {
        // GET: Track
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CreateTrack ()
        {
            string url = Request.Url.AbsoluteUri;
            string[] temp = url.Split('=');
            if (temp.Length > 1)
            {
                TempData["JustSearchedArtist"]=ListingArtistDB.SingleNamesFromId(temp[1]);
            }

            Cookies.Today();
            return View();
        }

        [HttpPost]
        public ActionResult CreateTrack(AddTracks model, string submit, string Search)
        {
            switch (submit)
            {
                case "Create":
                    if (ModelState.IsValid)
                    {
                        var dupa = model;
                        var f = dupa;
                        
                    }
                    break;
                case "Search":
                    if (model.Title != null)
                        TempData["TrackTitle"] = model.Title;
                    if (model.ReleaseDate != null)
                    {
                        TempData["TrackDate"] = TrackFunctions.Format_rrrrmmdd(model.ReleaseDate);
                    }
                    return RedirectToAction("SearchArtist", new { searchString = model.SearchString });
                    break;
                default:
                    break;
            }
            return View();
        }
        public ActionResult SearchArtist (string searchString)
        {
            List<DetailArtist> model = new List<DetailArtist>();
            model = DBConnect.Artist.ListingArtistDB.SearchArtist(searchString);
            return View(model);
        }
        public ActionResult DetailsArtist (DetailTracks model)
        {
            return View();
        }
    }
}