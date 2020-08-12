using Shoop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shoop.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
       
            return View();
        }

        public ActionResult About()
        {
            var UserId = User.Identity;
            ViewBag.UserId = UserId;
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


        //public ActionResult MostPopular()
        //{
        //    var OrderedMost = (from m in db.Movies
        //                       join r in db.OrderRows on m.Id equals r.MovieId
        //                       )
        //    return View();
        //}

        public ActionResult MostRecent()
        {
            var MovieList = (from m in db.Movies orderby m.ReleaseYear descending select m).Take(5).ToList();
            
            return View(ViewBag(MovieList));
        }

        public ActionResult Oldest()
        {
            var MovieList = (from m in db.Movies orderby m.ReleaseYear select m).Take(5).ToList();

            return View(MovieList);
        }

        public ActionResult Cheapest()
        {
            var MovieList = (from m in db.Movies orderby m.Price select m).Take(5).ToList();

            return View(MovieList);
        }

        public ActionResult RecentlyBought()
        {
            var RecentlyBought = (from m in db.Movies
                                  join r in db.OrderRows on m.Id equals r.MovieId
                                  join o in db.Orders on r.OrderId equals o.Id
                                  orderby o.OrderDate descending
                                  select new { m.Title }).Take(5).ToList();

            return View(RecentlyBought);
        }
    }
}