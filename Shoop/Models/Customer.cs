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
        // Might be useful:
        // Requires the first character to be upper case and the remaining 
        // characters to be alphabeticalrequires the first character to be 
        // upper case and the remaining characters to be alphabetical
        // [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$")]
        //[Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(100)]
        //[Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [StringLength(250)]
        //[Display(Name = "Billing Address")]
        public string BillingAddress { get; set; }

        [Required]
        [StringLength(10)]
        [DataType(DataType.PostalCode)]
        //[Display(Name = "Billing Postal Code")]
        public string BillingPostalCode { get; set; }

        [Required]
        [StringLength(50)]
        //[Display(Name = "Billing City")]
        public string BillingCity { get; set; }

        [Required]
        [StringLength(250)]
        //[Display(Name = "Delivery Address")]
        public string DeliveryAddress { get; set; }

        [Required]
        [StringLength(10)]
        [DataType(DataType.PostalCode)]
        //[Display(Name = "Delivery Postal Code")]
        public string DeliveryPostalCode { get; set; }

        [Required]
        [StringLength(50)]
        //[Display(Name = "Delivery Address")]
        public string DeliveryCity { get; set; }

        [Required]
        [StringLength(15)]
        [DataType(DataType.PhoneNumber)]
        //[Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        [Required]
        [StringLength(255)]
        [DataType(DataType.EmailAddress)]
        //[Display(Name = "Email Address")]
        public string EmailAddress { get; set; }

        //[Required]
        [StringLength(128)]
        public string UserId { get; set; }   /*Use GUID to create?*/

        public virtual ApplicationUser User {get; set;}
        public virtual ICollection<Order> Orders { get; set; }  //Many to one relation with Orders table, join table will be created automatically
    }
}