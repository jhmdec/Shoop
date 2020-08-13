
using System;

using System.Collections.Generic;

using System.Linq;

using System.Web;

using Shoop.Models;





namespace Shoop.Models

{

    public class FirstPageViewModels

    {

        public List<Movie> MovieListMostPopular { get; set; }

        public List<Movie> MovieListMostRecent { get; set; }

        public List<Movie> MovieListOldest { get; set; }

        public List<Movie> MovieListCheapest { get; set; }

        public List<Movie> MovieListRecentlyBought { get; set; }
    }
}

