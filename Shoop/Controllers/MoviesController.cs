using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Shoop.Models;

namespace Shoop.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Movies
        public ActionResult Index()
        {
            return View(db.Movies.ToList());
        }

        public ActionResult MostPopular()
        {

            var MovieList = (from m in db.Movies
                             join r in db.OrderRows on m.Id equals r.MovieId
                             orderby m.Title descending
                             group r by r.MovieId into g
                             orderby g.Count()
                             from res in g
                             select new
                             {
                                 res.Movie.MovieImageUrl,
                                 res.Movie.Title,
                                 Count = g.Count()
                             }).Distinct().OrderByDescending(M => M.Count).ToList().Take(5);

            
            return View(MovieList);
        }

        public ActionResult MostRecent()
        {
            var MovieList = (from m in db.Movies orderby m.ReleaseYear descending select m).Take(5).ToList();

            return View(MovieList);
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
    
    // GET: Movies/Details/5
    public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        // GET: Movies/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Movies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,Director,ReleaseYear,Price,MovieImageUrl,IMDBUrl,StatusFlag")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                db.Movies.Add(movie);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(movie);
        }

        // GET: Movies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        // POST: Movies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,Director,ReleaseYear,Price,MovieImageUrl,IMDBUrl,StatusFlag")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                db.Entry(movie).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(movie);
        }

        // GET: Movies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        // POST: Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Movie movie = db.Movies.Find(id);
            db.Movies.Remove(movie);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
