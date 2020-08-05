using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
//Add namespace
using Shoop.Models;

namespace Shoop.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        [Required]
        [StringLength(150)]
        public string Director { get; set; }

        [Required]
        public DateTime ReleaseYear { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }
        
        [StringLength(255)]
        [DataType(DataType.ImageUrl)]
        public string MovieImageUrl { get; set; }

        [StringLength(255)]
        [DataType(DataType.Url)]
        public string IMDBUrl { get; set; }

        [Required]
        public int StatusFlag { get; set; }

        //Add 1 to many relation with OrderRows table, autogenerate jointable
        public virtual ICollection<OrderRow> OrderRows { get; set; }  


    }
}