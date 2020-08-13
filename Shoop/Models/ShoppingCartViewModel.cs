using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Shoop.Models;


namespace Shoop.Models
{
    public class ShoppingCartViewModel
    {
        public List<Movie> CartOrder { get; set; }
        public int NrOfMovieItems { get; set; }
    }
}