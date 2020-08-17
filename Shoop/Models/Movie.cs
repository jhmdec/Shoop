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
        [DisplayFormat(DataFormatString = "{0:yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.DateTime)]
        public DateTime ReleaseYear { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }
        
        //[StringLength(255)] Need more than 255 characters
        [DataType(DataType.ImageUrl)]
        public string MovieImageUrl { get; set; }

        //[StringLength(255)] Need more than 255 characters
        [DataType(DataType.Url)]
        public string IMDBUrl { get; set; }

        /// <summary>
        /// Changed from StatusFlag to State
        /// </summary>
        //[Required]
        public int StateId { get; set; }

        public virtual State State { get; set; }   //Foreign key relation
        //Add 1 to many relation with OrderRows table, autogenerate jointable
        public virtual ICollection<OrderRow> OrderRows { get; set; }
    }
}