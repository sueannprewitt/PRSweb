namespace PRSweb.Migrations
{
    using PRSweb.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<PRSweb.Models.PRSwebContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(PRSweb.Models.PRSwebContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            context.Users.AddOrUpdate(
                u => u.UserName,
                     new User { UserName = "admin", Password = "admin",
                                  FirstName = "System", LastName = "Admin",
                                  Phone = "513-555-1212", Email = "system@admin.com",
                                  IsReviewer = true, IsAdmin = true },

                     new User { UserName = "user", Password = "user",
                                 FirstName = "Normal", LastName = "User",
                                 Phone = "513-555-1111",
                                 Email = "normal@user.com",
                                 IsReviewer = false, IsAdmin = false
                     }
                );
            context.Vendors.AddOrUpdate(
                v => v.Name,
                    new Vendor {
                        Code = "AMAZ",
                        Name = "Amazon",
                        Address = "123 Any Street",
                        City = "AnyCity",
                        State = "ST",
                        Zip = "45202",
                        Phone = "513-555-0000",
                        Email = "info@Amazon.com",
                        IsPreapproved = true
                    },

                     new Vendor
                     {
                         Code = "WAL",
                         Name = "Walmart",
                         Address = "123 Every Street",
                         City = "ACity",
                         State = "CA",
                         Zip = "12345",
                         Phone = "513-555-3333",
                         Email = "info@Walmart.com",
                         IsPreapproved = true
                     }
                );


            
        }
    }
}
