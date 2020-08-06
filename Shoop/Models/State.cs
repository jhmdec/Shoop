using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Shoop.Models
{
    /// <summary>
    /// Different status on a movie
    /// 
    /// </summary>
    public class State
    {
        public int Id { get; set; }
        [Required]
        [StringLength(20)]
        public string Status { get; set; }

        //Many to one relation with Movie table
        public virtual ICollection<Order> Movies { get; set; }
    }
}