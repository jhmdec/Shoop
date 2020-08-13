using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shoop.Models;

namespace Shoop.Controllers
{
    public class ShoppingCartController : Controller
    {
        // GET: ShoppingCart
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
    }
}