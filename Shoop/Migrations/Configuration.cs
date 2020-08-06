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
                    BillingCity = "Linköping",
                    PhoneNumber = "0123456789",
                    EmailAddress = "janne.ek@example.com",
                    DeliveryAddress = "North Street 1",
                    DeliveryPostalCode = "12345",
                    DeliveryCity = "Linköping",
                },
                new Customer
                {
                    FirstName = "Jacqueline",
                    LastName = "de Caluwe",
                    BillingAddress = "South Street 2",
                    BillingPostalCode = "22233",
                    BillingCity = "Linköping",
                    PhoneNumber = "+4673987766",
                    EmailAddress = "jacqueline.de.caluwe@shoop.com",
                    DeliveryAddress = "",
                    DeliveryPostalCode = "",
                    DeliveryCity = "",
                },
                new Customer
                {
                    FirstName = "Tony",
                    LastName = "Lundén",
                    BillingAddress = "East Street 3",
                    BillingPostalCode = "99911",
                    BillingCity = "Linköping",
                    PhoneNumber = "+46709552288",
                    EmailAddress = "tony.lunden@shoop.com",
                    DeliveryAddress = "East Street 3",
                    DeliveryPostalCode = "99911",
                    DeliveryCity = "+46709552288",
                });
            context.SaveChanges();

            context.State.AddOrUpdate(
                s => s.Status,
                new State { Status = "Available" },
                new State { Status = "Retired" },
                new State { Status = "Campaign" }
                );
            context.SaveChanges();

            //Comment to let Tony get the original file back

            context.Movies.AddOrUpdate(
                m => m.Title,
                new Movie
                {
                    Title = "Serenity",
                    Director = "Joss Whedon",
                    ReleaseYear = new DateTime(2006, 4, 12),
                    Price = 49,
                    MovieImageUrl = "https://m.media-amazon.com/images/M/MV5BOWE2MDAwZjEtODEyOS00ZjYyLTgzNDUtYmNiY2VmNWRiMTQxXkEyXkFqcGdeQXVyNTIzOTk5ODM@._V1_UX182_CR0,0,182,268_AL_.jpg",
                    IMDBUrl = "https://www.imdb.com/title/tt0379786/?ref_=fn_al_tt_1",
                    State = context.State.FirstOrDefault(st => st.Status == "Retired")
                    // Genre: Sci-Fi, Action, Adventure
                },
                new Movie
                {
                    Title = "Joker",
                    Director = "Todd Phillips",
                    ReleaseYear = new DateTime(2020, 2, 10),
                    Price = 99,
                    MovieImageUrl = "https://m.media-amazon.com/images/M/MV5BNGVjNWI4ZGUtNzE0MS00YTJmLWE0ZDctN2ZiYTk2YmI3NTYyXkEyXkFqcGdeQXVyMTkxNjUyNQ@@._V1_UX182_CR0,0,182,268_AL_.jpg",
                    IMDBUrl = "https://www.imdb.com/title/tt7286456/?ref_=fn_al_tt_1",
                    State = context.State.FirstOrDefault(st => st.Status == "Available")
                    // Genre: Drama, Thriller, Crime
                //},
                //new Movie
                //{
                //    Title = "Serenity",
                //    Director = "Joss Whedon",
                //    ReleaseYear = new DateTime(2006, 4, 12),
                //    Price = 49,
                //    MovieImageUrl = "",
                //    IMDBUrl = "",
                //    State = context.State.FirstOrDefault(st => st.Status == "Available")
                });
            context.SaveChanges();
        }
    }
}
