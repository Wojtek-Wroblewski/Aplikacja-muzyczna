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
using PagedList;

namespace Aplikacja_muzyczna.Controllers
{
    [Authorize]
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
        public ActionResult CreateTrack(AddTracks model, string submit)
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
                        Cookies.RememberDateFromModel(model.ReleaseDate);
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
            if (Request.QueryString["TrackId"]!=null)
            model.TrackId = (int)double.Parse(Request.QueryString["TrackId"]);
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
        [AllowAnonymous]
        public ActionResult ListTrack (List<DetailTrackWithArtist> List, int? Page, string sortOrder)
        {
            int PageSize = 10;
            int PageNumber = (Page ?? 1);
            if (List != null)
            {
                return View(List.ToPagedList(PageNumber, PageSize));
            }
            else
            {
                List = DetailTrackDB.ListAll();


                ViewBag.TitleSortParm = String.IsNullOrEmpty(sortOrder) ? "TitleDesc" : "Title";
                ViewBag.FirstNameSortParm = sortOrder == "FirstName" ? "FirstNameDesc" : "FirstName";
                ViewBag.LastNameSortParm = sortOrder == "LastName" ? "LastNameDesc" : "LastName";
                ViewBag.DateSortParm = sortOrder == "Date" ? "DateDesc" : "Date";
                List = TrackFunctions.OrderListTrack(List, sortOrder);
                return View(List.ToPagedList(PageNumber, PageSize));
            }
        }
        public ActionResult EditTrack (EditTrack model)
        {
            /*TODO 
             jak wracamy z wyboru nowego artysty to żeby wrócić do miejsca edycjia, a nie listy od nowa, bo w sumie wtedy co klikneliśmy to sobie tak zniknęło i trochę bez sensu :/ */
            int NewArtist = 0; 
            if (Request.QueryString["TrackId"]!=null)
            model.TrackId = (int) double.Parse(Request.QueryString["TrackId"]);
            if (Request.QueryString["ArtistId"] != null)
                 NewArtist = (int)double.Parse(Request.QueryString["ArtistId"]);

            if (TempData["TrackInEdit"] != null)
            {
               // model.TrackId = (int)TempData["TrackInEdit"];
            }
            /*
             * 
             * 
            http://localhost:58803/Track/EditTrack?TrackId=2137&ArtistId=1488
            Tak powinien wygladać zawsze link do  edycji track,a bedzie chyabtak łatwiej
            */

            if (model.TrackId != 0)
            {
                model = DetailTrackDB.DetailTracktoEdit(model.TrackId);

                if (model.ArtistId == 0)
                { 
                var Artist = DetailArtistDB.DetailFromId(0);
                    model.Firstname = Artist.Firstname;
                    model.Lastname = Artist.Lastname;
                }
                Cookies.RememberDateFromModel(model.ReleaseDate);
                Cookies.Today();
                TempData["TrackInEdit"] = model.TrackId;
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

            if (TempData["TrackInEdit"] != null)
            {
                model.TrackId = (int)TempData["TrackInEdit"];
            }

            if (model.TrackId != 0)
            {
                switch (submit)
                {
                    case "Save":
                        if (ModelState.IsValid)
                        {
                            model = EditTrackDB.EditTrack(model);//zmapować ten model, na taki, żeby widok chciał go widziec, albo przejśc na strone z detalami, to w sumie dobry pomysł chyba tak zaaraz zrobię

                            return RedirectToAction("DetailsTrack", new { TrackId = model.TrackId});
                        }
                        break;
                    case "Search":

                        /*TODO cały mechanizm od szukajki */
                        if (model.Title != null)
                        { 
                              TempData["TrackTitle"] = model.Title;
                        }
                            if (model.ReleaseDate != null)
                        {
                            Cookies.RememberDateFromModel(model.ReleaseDate);
                        }
                        TempData["TrackInEdit"] = model.TrackId;
                        return RedirectToAction("SearchArtistEdit", new { searchString = model.SearchString});
                        
                    default:
                        break;
                }
            }
            else
            {
                return RedirectToAction("ListTrack");
            }
            return View(model);

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