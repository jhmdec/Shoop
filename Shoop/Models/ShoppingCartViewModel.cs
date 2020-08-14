using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Shoop.Models;


namespace Shoop.Models
{
    public class ShoppingCartViewModel
    {
        [Required]
        public int CustId { get; set; }
        public List<Movie> CartOrder { get; set; }
        public int NrOfMovieItems { get; set; }
        
    }
}