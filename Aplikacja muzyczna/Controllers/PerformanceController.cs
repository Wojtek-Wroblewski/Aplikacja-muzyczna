using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Aplikacja_muzyczna.Functions;
using Aplikacja_muzyczna.Models;
using Aplikacja_muzyczna.DBConnect.Artist;
using Aplikacja_muzyczna.DBConnect.Track;

namespace Aplikacja_muzyczna.Controllers
{
    public class PerformanceController : Controller
    {
        // GET: Performance
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult CreatePerformance()
        {

            return View();
        }
        [HttpPost]
        public ActionResult CreatePerformance(AddPerformance model,  string submit)
        {

            switch (submit)
            {
                case "Create":
                    if (ModelState.IsValid)
                    {
                        //int JustaddedTrack = AddTrackDB.SaveTracktoDB(model);
                        if (true)
                        {
                            return RedirectToAction("DetailsTrack", new { TrackId = 2137 });
                        }
                        else
                        {
                            return RedirectToAction("FailedTrack");
                        }
                    }
                    break;
                case "Search":

                   // if (model.Title != null)
                     //   TempData["TrackTitle"] = model.Title;
                    if (model.UploadDate != null)
                    {
                        model.UploadDate = DateTimeOffset.Now;
                    }
                    return RedirectToAction("SearchArtistAdd", new { searchString = model.SearchString });

                default:
                    break;
            }


            return RedirectToAction("DetailsPerformance", new { PerformenceId = model.PerformanceId });
        }

        public ActionResult DetailsPerformance()
        {

            return View();
        }

    }
}