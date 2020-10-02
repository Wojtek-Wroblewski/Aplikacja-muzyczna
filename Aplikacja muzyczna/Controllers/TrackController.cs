using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Aplikacja_muzyczna.Functions;
using Aplikacja_muzyczna.Models;
using Aplikacja_muzyczna.DBConnect.Artist;
using Aplikacja_muzyczna.DBConnect.Track;

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
                        int JustaddedTrack = AddTrackDB.SaveTracktoDB(model);
                        if (JustaddedTrack != 0 )
                        {
                            return RedirectToAction("DetailsTrack", new { TrackId = JustaddedTrack });
                        }else
                        {
                            return RedirectToAction("FailedTrack");
                        }
                    }
                    break;
                case "Search":
                    if (model.Title != null)
                        TempData["TrackTitle"] = model.Title;
                    if (model.ReleaseDate != null)
                    {
                        TempData["TrackDate"] = model.ReleaseDate;
                    }
                    return RedirectToAction("SearchArtistAdd", new { searchString = model.SearchString });

                default:
                    break;
            }
            return View();
        }
        public ActionResult SearchArtistAdd (string searchString)
        {
            List<DetailArtist> model = new List<DetailArtist>();
            model = DBConnect.Artist.ListingArtistDB.SearchArtist(searchString);
            return View(model);
        }
        public ActionResult DetailsTrack (DetailTrackWithArtist model)
        {
            if (model.TrackId != 0)
            {
                model = DetailTrackDB.DetailFromId(model.TrackId);
            }
            else
            {
                return RedirectToAction("ListTrack");
            }

            return View(model);
        }
        
        public ActionResult ListTrack (List<DetailTrackWithArtist> List)
        {
            if (List != null)
            {
                return View(List);
            }
            else
            {
                List = DetailTrackDB.ListAll();
                return View(List);
            }
        }
        public ActionResult EditTrack (EditTrack model)
        {
            if (model.TrackId != 0)
            {
                model = DetailTrackDB.DetailTracktoEdit(model.TrackId);
                return View(model);
            }
            else
            {
                //model = DetailTrackDB.DetailTracktoEdit(13);
              //  return View(model);
                return RedirectToAction("ListTrack");
            }

        }
        [HttpPost]
        public ActionResult EditTrack(DetailTrackWithArtist model,string submit, string Search)
        {
            if (model.TrackId != 0)
            {
                switch (submit)
                {
                    case "Save":
                        if (ModelState.IsValid)
                        {
                            model = EditTrackDB.EditTrack(model);
                        }
                        break;
                    case "Search":

                        /*TODO cały mechanizm od szukajki */
                        if (model.Title != null)
                              TempData["TrackTitle"] = model.Title;
                            if (model.ReleaseDate != null)
                            {
                                TempData["TrackDate"] = model.ReleaseDate;
                            }
                        return RedirectToAction("SearchArtistEdit", new { searchString = model.SearchString });
                        
                    default:
                        break;
                }
            }
            else
            {
                return RedirectToAction("ListTrack");
            }
            return View();

        }
        public ActionResult SearchArtistEdit(string searchString)
        {
            List<DetailArtist> model = new List<DetailArtist>();
            model = DBConnect.Artist.ListingArtistDB.SearchArtist(searchString);
            return View(model);
        }
        public ActionResult FailedTrack ()
        {
            return View();
        }
    }
}