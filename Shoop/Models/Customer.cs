using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
//Add namespace
using Shoop.Models;

namespace Shoop.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(100)]
        public string LastName { get; set; }

        [Required]
        [StringLength(250)]
        public string BillingAddress { get; set; }

        [Required]
        [StringLength(10)]
        [DataType(DataType.PostalCode)]
        public string BillingPostalCode { get; set; }

        [Required]
        [StringLength(50)]
        public string BillingCity { get; set; }

        [Required]
        [StringLength(250)]
        public string DeliveryAddress { get; set; }

        [Required]
        [StringLength(10)]
        [DataType(DataType.PostalCode)]
        public string DeliveryPostalCode { get; set; }

        [Required]
        [StringLength(50)]
        public string DeliveryCity { get; set; }

        [Required]
        [StringLength(15)]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        [Required]
        [StringLength(255)]
        [DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; }

        
        public string UserId { get; set; }   /*ASPNETUser table*/
        public virtual ApplicationUser User {get; set;}

        public virtual ICollection<Order> Orders { get; set; }  //Many to one relation with Orders table, join table will be created automatically
                                                                //One customer can have many orders
    }
}