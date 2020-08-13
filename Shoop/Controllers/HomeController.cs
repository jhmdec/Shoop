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
            FirstPageViewModels obj= new FirstPageViewModels();
            obj.MovieListMostRecent = MostRecent();
            obj.MovieListMostPopular = MostPopular();
            obj.MovieListCheapest = Cheapest();
            obj.MovieListOldest = Oldest();
            obj.MovieListRecentlyBought = RecentlyBought();
            return View(obj);  //obj is singular item! That means that the view should be of 
                               //a single item as well:
                               //@model Shoop.Models.FirstPageViewModels in the Index.cshtml page
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


        public List<Movie> MostPopular()
        {

            var MovieListMostPopular = (from m in db.Movies
                                        join r in db.OrderRows on m.Id equals r.MovieId
                                        orderby m.Title descending
                                        group r by r.MovieId into g
                                        orderby g.Count() descending
                                        from res in g
                                        select res.Movie).Distinct().Take(5).ToList();
                             //{
                             //    res.Movie.MovieImageUrl,
                             //    res.Movie.Title,
                             //    //Count = g.Count()
                             //}).Distinct().Take(5).ToList();


            return MovieListMostPopular;
        }

        public List<Movie> MostRecent()
        {
            var MovieListMostRecent = (from m in db.Movies orderby m.ReleaseYear descending select m).Take(5).ToList();
            
            return MovieListMostRecent;
        }

        public List<Movie> Oldest()
        {
            var MovieListOldest = (from m in db.Movies orderby m.ReleaseYear select m).Take(5).ToList();

            return MovieListOldest;
        }

        public List<Movie> Cheapest()
        {
            var MovieListCheapest = (from m in db.Movies orderby m.Price select m).Take(5).ToList();

            return MovieListCheapest;
        }

        public List<Movie> RecentlyBought()
        {
            var MovieListRecentlyBought = (from m in db.Movies
                                  join r in db.OrderRows on m.Id equals r.MovieId
                                  join o in db.Orders on r.OrderId equals o.Id
                                  orderby o.OrderDate descending
                                  select m).Take(5).ToList();

            return MovieListRecentlyBought;
        }

    }

}