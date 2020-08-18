namespace Shoop.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Validation;
    using System.Linq;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Shoop.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<Shoop.Models.ApplicationDbContext>
    {
        ApplicationDbContext context = new ApplicationDbContext();
        List<string> roles = new List<string>() {
                //"SU",
                "Admin",
                "Manager",
                "Customer",
                "User",
                "Guest"
            };
        string userId1;
        string userId2;
        string userId3;
        string userId4;
        string userId5;

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

            CreateInitialRolesAndUsesrs();
            //CreateRoles(context);     // WORKS, BUT NOT USING ATM
            //CreateUsers(context);     // NOT WORKING !!!
            CreateCustomers(context);   // FIXING THE DELIVERY NOT REQUIRED
            CreateMovies(context);      // WORKS
            //CreateOrders(context);    // NOTE COMPLETED AND NOT USED
            //CreateOrderRows(context); // NOTE COMPLETED AND NOT USED
        }

        public void CreateInitialRolesAndUsesrs()
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var userStore = new UserStore<ApplicationUser>(context);
            var userManager = new UserManager<ApplicationUser>(userStore);
            // Creating superuser as the only one having exclusive 
            if (!roleManager.RoleExists("SU"))
            {
                // Create Role   
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "SU";
                roleManager.Create(role);

                // Create SU user                   
                var user = new ApplicationUser
                {
                    //UserName = "ShoopSuper",
                    UserName = "super.user@shoop.com",
                    FirstName = "Super",
                    LastName = "User",
                    Email = "super.user@shoop.com",
                    EmailConfirmed = true
                };

                var checkUser = userManager.Create(user, "Sup123_");
                // Add user to Role SU    
                if (checkUser.Succeeded)
                {
                    var result = userManager.AddToRole(user.Id, "SU");  // Do we need to capture return?
                }
            }

            // Creating roles  
            foreach (var newRole in roles)
            {
                if (!roleManager.RoleExists(newRole))
                {
                    var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                    role.Name = newRole;
                    roleManager.Create(role);
                }
            }

            // Add a User
            if (roleManager.RoleExists("User"))
            {
                // Fetch the role User
                var role = roleManager.FindByName("User");

                // Create an ordinary User                  
                var user = new ApplicationUser
                {
                    UserName = "User",
                    FirstName = "Allan",
                    LastName = "Svensson",
                };

                var checkUser = userManager.Create(user, "AllSve51");
                // Add user to role User    
                if (checkUser.Succeeded)
                {
                    var result = userManager.AddToRole(user.Id, "User");  // Do we need to capture return?
                }
            }
        }

        private void CreateCustomers(ApplicationDbContext context)
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var userStore = new UserStore<ApplicationUser>(context);
            var userManager = new UserManager<ApplicationUser>(userStore);
            var user1 = new ApplicationUser();
            var user2 = new ApplicationUser();
            var user3 = new ApplicationUser();
            var user4 = new ApplicationUser();
            var user5 = new ApplicationUser();

            if (roleManager.RoleExists("User"))
            {
                // Fetch the role User
                var role = roleManager.FindByName("User");

                user1 = new ApplicationUser
                {
                    FirstName = "Nisse",
                    LastName = "Pettersson",
                    UserName = "Nisse" + "Pettersson"
                };
                var checkUser = userManager.Create(user1, "Nisse1");
                // Add user to role User   
                if (checkUser.Succeeded)
                {
                    var result = userManager.AddToRole(user1.Id, "User");  // Do we need to capture return?
                }
                userId1 = user1.Id;

                user2 = new ApplicationUser
                {
                    FirstName = "Olle",
                    LastName = "Olsson",
                    UserName = "Olle" + "Olsson"
                };
                checkUser = userManager.Create(user2, "OlleO2");
                // Add user to role User   
                if (checkUser.Succeeded)
                {
                    var result = userManager.AddToRole(user2.Id, "User");  // Do we need to capture return?
                }
                userId2 = user2.Id;

                user3 = new ApplicationUser
                {
                    FirstName = "Angelica",
                    LastName = "Karlsson",
                    UserName = "Angelica" + "Karlsson"
                };
                checkUser = userManager.Create(user3, "Angel3");
                // Add user to role User   
                if (checkUser.Succeeded)
                {
                    var result = userManager.AddToRole(user3.Id, "User");  // Do we need to capture return?
                }
                userId3 = user3.Id;

                user4 = new ApplicationUser
                {
                    FirstName = "Anna",
                    LastName = "Paulsson",
                    UserName = "Anna" + "Paulsson"
                };
                checkUser = userManager.Create(user4, "AnnaP4");
                // Add user to role User   
                if (checkUser.Succeeded)
                {
                    var result = userManager.AddToRole(user4.Id, "User");  // Do we need to capture return?
                }
                userId4 = user4.Id;

                user5 = new ApplicationUser
                {
                    FirstName = "Allan",
                    LastName = "Posset",
                    UserName = "Allan" + "Posset"
                };
                checkUser = userManager.Create(user5, "Allan5");
                // Add user to role User   
                if (checkUser.Succeeded)
                {
                    var result = userManager.AddToRole(user5.Id, "User");  // Do we need to capture return?
                }
                userId5 = user5.Id;
                context.SaveChanges();
            }

            context.Customers.AddOrUpdate(
                //Specify details
                c => c.FirstName,
                new Customer
                {
                    FirstName = "Nisse",
                    LastName = "Pettersson",
                    BillingAddress = "Strandvägen 14",
                    BillingPostalCode = "12345",
                    BillingCity = "Sigtuna",
                    DeliveryAddress = "Strandvägen 14",
                    DeliveryPostalCode = "12345",
                    DeliveryCity = "Sigtuna",
                    PhoneNumber = "07065165161",
                    EmailAddress = "nisse@gmail.com",
                    UserId = userId1
                },
                new Customer
                {
                    FirstName = "Olle",
                    LastName = "Olsson",
                    BillingAddress = "Hamngatan 23",
                    BillingPostalCode = "18299",
                    BillingCity = "Ludvika",
                    DeliveryAddress = "Hamngatan 23",
                    DeliveryPostalCode = "18299",
                    DeliveryCity = "Ludvika",
                    PhoneNumber = "0645547181",
                    EmailAddress = "olle@hotmail.com",
                    UserId = userId2
                },
                new Customer
                {
                    FirstName = "Angelica",
                    LastName = "Karlsson",
                    BillingAddress = "Furirgatan 8",
                    BillingPostalCode = "12098",
                    BillingCity = "Linköping",
                    DeliveryAddress = "",
                    DeliveryPostalCode = "",
                    DeliveryCity = "",
                    PhoneNumber = "013168472",
                    EmailAddress = "angelica@hotmail.com",
                    UserId = userId3
                },
                new Customer
                {
                    FirstName = "Anna",
                    LastName = "Paulsson",
                    BillingAddress = "Moränvägen 90",
                    BillingPostalCode = "27493",
                    BillingCity = "Jordbro",
                    DeliveryAddress = "Moränvägen 90",
                    DeliveryPostalCode = "27493",
                    DeliveryCity = "Jordbro",
                    PhoneNumber = "086516843",
                    EmailAddress = "anna74@gmail.com",
                    UserId = userId4
                },
                new Customer
                {
                    FirstName = "Allan",
                    LastName = "Posset",
                    BillingAddress = "Folkungagatan 2",
                    BillingPostalCode = "11630",
                    BillingCity = "Stockholm",
                    DeliveryAddress = "Folkungagatan 2",
                    DeliveryPostalCode = "11630",
                    DeliveryCity = "Stockholm",
                    PhoneNumber = "0705516487",
                    EmailAddress = "allan@gmail.com",
                    UserId = userId5
                });
            context.SaveChanges();
        }

        private void CreateMovies(ApplicationDbContext context)
        {
            context.Movies.AddOrUpdate(
                m => m.Title,
                new Movie
                {
                    Title = "The Godfather",
                    Director = "Francis Ford Coppola",
                    ReleaseYear = new DateTime(1972, 1, 1),
                    Price = 99,
                    MovieImageUrl = "https://m.media-amazon.com/images/M/MV5BM2MyNjYxNmUtYTAwNi00MTYxLWJmNWYtYzZlODY3ZTk3OTFlXkEyXkFqcGdeQXVyNzkwMjQ5NzM@._V1_SY1000_CR0,0,704,1000_AL_.jpg",
                    IMDBUrl = "https://www.imdb.com/title/tt0068646/?ref_=fn_al_tt_1",
                    
                    // Genre: Crime, Drama
                },
                new Movie
                {
                    Title = "The Godfather 2",
                    Director = "Francis Ford Coppola",
                    ReleaseYear = new DateTime(1974, 1, 1),
                    Price = 79,
                    MovieImageUrl = "https://m.media-amazon.com/images/M/MV5BMWMwMGQzZTItY2JlNC00OWZiLWIyMDctNDk2ZDQ2YjRjMWQ0XkEyXkFqcGdeQXVyNzkwMjQ5NzM@._V1_SY1000_CR0,0,701,1000_AL_.jpg",
                    IMDBUrl = "https://www.imdb.com/title/tt0071562/?ref_=fn_al_tt_2 ",
                    
                    // Genre: Crime, Drama
                },
                new Movie
                {
                    Title = "The Godfather 3",
                    Director = "Francis Ford Coppola",
                    ReleaseYear = new DateTime(1990, 1, 1),
                    Price = 79,
                    MovieImageUrl = "https://m.media-amazon.com/images/M/MV5BNTc1YjhiNzktMjEyNS00YmNhLWExYjItZDhkNWJjZjYxOWZiXkEyXkFqcGdeQXVyNzkwMjQ5NzM@._V1_SY1000_CR0,0,667,1000_AL_.jpg",
                    IMDBUrl = "https://www.imdb.com/title/tt0099674/?ref_=fn_al_tt_1",
                    
                    // Genre: Crime, Drama
                },
                new Movie
                {
                    Title = "Jaws",
                    Director = "Steven Spielberg",
                    ReleaseYear = new DateTime(1975, 1, 1),
                    Price = 49,
                    MovieImageUrl = "https://m.media-amazon.com/images/M/MV5BMmVmODY1MzEtYTMwZC00MzNhLWFkNDMtZjAwM2EwODUxZTA5XkEyXkFqcGdeQXVyNTAyODkwOQ@@._V1_SX651_CR0,0,651,999_AL_.jpg",
                    IMDBUrl = "https://www.imdb.com/title/tt0073195/?ref_=fn_al_tt_1",
                    
                    // Genre: Adventure, Thriller
                },
                new Movie
                {
                    Title = "Star Wars",
                    Director = "George Lucas",
                    ReleaseYear = new DateTime(1975, 1, 1),
                    Price = 99,
                    MovieImageUrl = "https://m.media-amazon.com/images/M/MV5BNzVlY2MwMjktM2E4OS00Y2Y3LWE3ZjctYzhkZGM3YzA1ZWM2XkEyXkFqcGdeQXVyNzkwMjQ5NzM@._V1_SY1000_CR0,0,643,1000_AL_.jpg",
                    IMDBUrl = "https://www.imdb.com/title/tt0076759/?pf_rd_m=A2FGELUUNOQJNL&pf_rd_p=706e19a4-e4ad-4659-b087-ffc80ad81fcb&pf_rd_r=J0A8MRHEMNYJ5CDNZ4GE&pf_rd_s=center-5&pf_rd_t=60601&pf_rd_i=star-wars&ref_=fea_sw_advs_t1",
                    
                    // Genre: Action, Adventure
                },
                new Movie
                {
                    Title = "The Green Mile",
                    Director = "Frank Darabont",
                    ReleaseYear = new DateTime(1999, 1, 1),
                    Price = 99,
                    MovieImageUrl = "https://m.media-amazon.com/images/M/MV5BMTUxMzQyNjA5MF5BMl5BanBnXkFtZTYwOTU2NTY3._V1_.jpg",
                    IMDBUrl = "https://www.imdb.com/title/tt0120689/?ref_=nv_sr_srsg_0",
                    
                    // Genre: Drama, Crime
                },
                new Movie
                {
                    Title = "Il Postino",
                    Director = "Michael Radford",
                    ReleaseYear = new DateTime(1994, 1, 1),
                    Price = 99,
                    MovieImageUrl = "https://m.media-amazon.com/images/M/MV5BZmVhNWIzOTMtYmVlZC00ZDVmLWIyODEtODEzOTAxYjAwMzVlXkEyXkFqcGdeQXVyMzIwNDY4NDI@._V1_.jpg",
                    IMDBUrl = "https://www.imdb.com/title/tt0110877/?ref_=fn_al_tt_1",
                    
                    // Genre: Biography, Comedy
                },
                new Movie
                {
                    Title = "Alien",
                    Director = "Ridley Scott",
                    ReleaseYear = new DateTime(1979, 1, 1),
                    Price = 99,
                    MovieImageUrl = "https://m.media-amazon.com/images/M/MV5BMmQ2MmU3NzktZjAxOC00ZDZhLTk4YzEtMDMyMzcxY2IwMDAyXkEyXkFqcGdeQXVyNzkwMjQ5NzM@._V1_SY1000_CR0,0,678,1000_AL_.jpg",
                    IMDBUrl = "https://www.imdb.com/title/tt0078748/?ref_=nv_sr_srsg_0",
                    
                    // Genre: Horror, Sci-Fi
                },
                new Movie
                {
                    Title = "Mrs Doubtfire",
                    Director = "Chris Columbus",
                    ReleaseYear = new DateTime(1993, 1, 1),
                    Price = 99,
                    MovieImageUrl = "https://m.media-amazon.com/images/M/MV5BMjExMDUzODE1N15BMl5BanBnXkFtZTgwNTU5NTYxMTE@._V1_.jpg",
                    IMDBUrl = "https://www.imdb.com/title/tt0107614/?ref_=nv_sr_srsg_0 ",
                    
                    // Genre: Comedy, Drama
                },
                new Movie
                {
                    Title = "Serenity",
                    Director = "Joss Whedon",
                    ReleaseYear = new DateTime(2006, 4, 12),
                    Price = 49,
                    MovieImageUrl = "https://m.media-amazon.com/images/M/MV5BOWE2MDAwZjEtODEyOS00ZjYyLTgzNDUtYmNiY2VmNWRiMTQxXkEyXkFqcGdeQXVyNTIzOTk5ODM@._V1_UX182_CR0,0,182,268_AL_.jpg",
                    IMDBUrl = "https://www.imdb.com/title/tt0379786/?ref_=fn_al_tt_1",
                    
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
                    
                    // Genre: Drama, Thriller, Crime
                    //},
                    //new Movie
                    //{
                    //    Title = "",
                    //    Director = "",
                    //    ReleaseYear = new DateTime(1975, 1, 1),
                    //    Price = 9,
                    //    MovieImageUrl = "",
                    //    IMDBUrl = "",
                    //    State = context.State.FirstOrDefault(st => st.Status == "Retired")
                    //    // Genre: 
                });
            context.SaveChanges();
        }

        /// <summary>
        /// Not working and will not be used
        /// </summary>
        /// <param name="context"></param>
        private void CreateOrders(ApplicationDbContext context)
        {
            var cust = this.context.Customers.FirstOrDefault(c => c.User.Id == userId1);
            var cust1 = context.Customers.FirstOrDefault(c => c.EmailAddress == "janne.ek@example.com");
            //var query = from c in context.Customers where c.ApplicationUser.UserName == "JanneEk" select c.Id;
            //join o in context.Orders on c.Id equals o.CustomerId
            //join or in db.OrderRows on o.Id equals or.OrderId
            //join m in db.Movies on or.MovieId equals m.Id
            //where m.Id == 1
            //select c).Distinct();

            context.Orders.AddOrUpdate(
                o => o.CustomerId,
                new Order
                {
                    CustomerId = cust1.Id,
                    OrderDate = new DateTime(2020, 8, 9),
                    NrOfItems = 1,
                });
            context.SaveChanges();
        }

        private void CreateOrderRows(ApplicationDbContext context)
        {

        }

        /// <summary>
        /// GENERATED IN Startup.cs. DO NOT USE FOR NOW !!!
        /// Creating Roles in table dbo.AspNetRoles
        /// </summary>
        /// <param name="context"></param>
        private void CreateRoles(ApplicationDbContext context)
        {
            var roleStore = new RoleStore<IdentityRole>(context);
            var roleManager = new RoleManager<IdentityRole>(roleStore);
            var newRole = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();

            foreach (var role in roles)
            {
                newRole = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                newRole.Name = role;
                if (!roleManager.RoleExists(role))
                {
                    roleManager.Create(newRole);
                }
            }
            context.SaveChanges();
        }

        /// <summary>
        /// THIS METHOD IS NOT WORKING AT THE MOMENT. DO NOT USE FOR NOW!
        /// </summary>
        /// <param name="context"></param>
        private void CreateUsers(ApplicationDbContext context)
        {
            var userStore = new UserStore<ApplicationUser>(context);
            var userManager = new UserManager<ApplicationUser>(userStore);
            var roleStore = new RoleStore<IdentityRole>(context);
            var roleManager = new RoleManager<IdentityRole>(roleStore);
            ApplicationUser userSU = null;
            string userPWD = "";

            if (userSU == null)
            {
                userSU = new ApplicationUser
                {
                    Email = "super@shoop.com",         // Nullable
                    EmailConfirmed = true,
                    //EmailConfirmed = false,         // NOT NULL
                    //PasswordHash = null,            // Nullable
                    //SecurityStamp = null,           // Nullable
                    //PhoneNumber = null,             // Nullable
                    //PhoneNumberConfirmed = false,   // NOT NULL
                    //TwoFactorEnabled = false,       // NOT NULL
                    //LockoutEndDateUtc = null,       // Nullable
                    //LockoutEnabled = false,         // NOT NULL
                    //AccessFailedCount = 0,          // NOT NULL
                    UserName = "super"                // NOT NULL
                };
            }

            userPWD = "Sup123";
            //var chkUser = userManager.Create(userSU, userPWD);
            userManager.Create(userSU, userPWD);

            var rolesForUser = userManager.GetRoles(userSU.Id);
            if (!rolesForUser.Contains("SU"))
            {
                var result = userManager.AddToRole(userSU.Id, "SU");
            }
            //userManager.AddToRole(userSU.Id, "SU");
            //userManager.SetLockoutEnabled(userSU.Id, false);

            //context.SaveChanges();
        }
    }
}