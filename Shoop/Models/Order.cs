using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
//Add namespace
using Shoop.Models;

namespace Shoop.Models
{
    public class Order
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.DateTime)]   /*We can change to DataTime.Date as well if we decide we don't need time*/
        public DateTime OrderDate { get; set; }

        public int NrOfItems { get; set; }

        // This is required to have this as a foreign key 
        // Virtual creates a VIRTUAL MAPPING between the tables
        public virtual Customer Customer { get; set; }   
        //Add 1 to many relation with OrderRows table
        public virtual ICollection<OrderRow> OrderRows { get; set; }  

    }
}