﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shoop.Models;


namespace Shoop.Controllers
{
    public class ShoopCartController : Controller
    {
        ApplicationDbContext context= new ApplicationDbContext();
        ShoopCartViewModels obj = new ShoopCartViewModels();
        // GET: ShoppingCart
        //public ActionResult Index(ShoopCartViewModels shoopcart)
        public ActionResult Index()
        {
            
            return View();
        }


        public ActionResult AddMovieCopy()
        {
            return View();
        }

        public ActionResult RemoveMovieCopy()
        {
            return View();
        }
        public ActionResult Buy()
        {
            return View();
        }
        public ActionResult Add(int id)
        {
            Movie mov = context.Movies.Find(id);
            List<Movie> LM = new List<Movie>();
            LM.Add(mov);
            Session["MovieList"] = LM;
            //obj.CartOrder.Add(mov);
            //obj.NrOfMovieItems++;
            

            return View();
            
        }
    }
}