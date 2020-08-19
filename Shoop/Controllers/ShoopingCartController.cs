using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shoop.Models;

namespace Shoop.Controllers
{
    public class ShoopingCartController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();

        public List<Movie> ShoopCartList = new List<Movie>();

        // GET: ShoopCart
        public ActionResult Index()
        {
                        return View();
        }
            
            public ActionResult AddToCart(int id)
            {
                var movie = db.Movies.FirstOrDefault(m => m.Id == id);

                if (Session["ShoopCart"] == null)
                {
                    ShoopCartList.Add(movie);
                    Session["ShoopCart"] = ShoopCartList;
                }
                else
                {
                    ShoopCartList = (List<Movie>)Session["ShoopCart"];
                    ShoopCartList.Add(movie);
                    Session["ShoopCart"] = ShoopCartList;
                }

                return RedirectToAction("Index", "Movies");
            }
           public ActionResult DisplayCart()
            {
                ShoopCartList = (List<Movie>)Session["ShoopCart"];

                return View(ShoopCartList);
            }        
    }
}