using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
//Add namespace
using Shoop.Models;

namespace Shoop.Models
{
    public class OrderRow
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public int OrderId { get; set; }
        public virtual Order Order { get; set; }   //Foreign key relation

        [Required]
        public int MovieId { get; set; }
        public virtual Movie Movie { get; set; }   //Foreign key relation

        [Required]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        //do we need to add this?
        //public virtual ICollection<Movie> Movies { get; set; }
    }
}