using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Aplikacja_muzyczna.Functions;
using Aplikacja_muzyczna.Models;

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
            Cookies.Today();
            return View();
        }

        [HttpPost]
        public ActionResult CreateTrack(AddTracks model, string submit, string Search)
        {
            switch (submit)
            {
                case "Create":
                    // Do something
                    break;
                case "Search":
                    return SearchArtist(model.SearchString);
                    break;
                default:
                    break;
            }
            return View();
        }
        public ActionResult SearchArtist (string searchString)
        {
            List<DetailArtist> model = new List<DetailArtist>();
            model = ArtistFunction.Search(searchString);
            return View(model);
        }
    }
}