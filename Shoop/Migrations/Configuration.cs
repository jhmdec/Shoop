namespace Shoop.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    //Add namespace
    using Shoop.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<Shoop.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Shoop.Models.ApplicationDbContext context) // context refers to database tables
        {
            //  This method will be called after migrating to the latest version.

            //Make sure to include the table contents, every record can be specified here
            //Another option is to create a SQL file with the data
            //Put all the data in a separate file and then call on the file here
            context.Customers.AddOrUpdate(
                //Specify details
                c => c.FirstName,
                new Customer
                {
                    FirstName = "Janne",
                    LastName = "Ek",
                    BillingAddress = "North Street 1",
                    BillingPostalCode = "12345",
                    BillingCity = "City1",
                    PhoneNumber = "0123456789",
                    EmailAddress = "Janne.ek@example.com",
                    DeliveryAddress = "North Street 1",
                    DeliveryPostalCode = "12345",
                    DeliveryCity = "City1",
                }

            context.State.AddOrUpdate(
                s => s.Status,
                new State { Status = "Available" },
                new State { Status = "Retired" },
                new State { Status = "Campaign" }
                );
            context.SaveChanges();

                );
        }
    }
}
