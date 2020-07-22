namespace Models.Migrations
{
    using global::Models.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<WebDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(WebDbContext context)
        {
           
            var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new WebDbContext()));

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new WebDbContext()));

            var user = new ApplicationUser()
            {
                UserName = "Hoan",
                Email = "hoanluffy1999@gmail.com",
                EmailConfirmed = true,
                BirthDay = DateTime.Now,
                FullName = "Nguyen Van"

            };

            manager.Create(user, "123654$");

            if (!roleManager.Roles.Any())
            {
                roleManager.Create(new IdentityRole { Name = "Admin" });
                roleManager.Create(new IdentityRole { Name = "User" });
            }

            var adminUser = manager.FindByEmail("hoanluffy1999@gmail.com");

            manager.AddToRoles(adminUser.Id, new string[] { "Admin", "User" });

            var user1 = new ApplicationUser()
            {
                UserName = "Hoan1",
                Email = "hoanluffy1990@gmail.com",
                EmailConfirmed = true,
                BirthDay = DateTime.Now,
                FullName = "Nguyen Van"

            };

            manager.Create(user1, "123654$");

            if (!roleManager.Roles.Any())
            {
                roleManager.Create(new IdentityRole { Name = "Admin" });
                roleManager.Create(new IdentityRole { Name = "User" });
            }

            var adminUser1 = manager.FindByEmail("hoanluffy1999@gmail.com");

            manager.AddToRoles(adminUser.Id, new string[] { "User" });
        }
        private void CreateBookCategory(WebDbContext context)
        {

            List<BookCategory> listCategory = new List<BookCategory>()
            {
                new BookCategory() { Name="Sách thiếu nhi",Status=true },
                 new BookCategory() { Name="Sách kinh tế",Status=true },
                  new BookCategory() { Name="Văn học",Status=true },
                   new BookCategory() { Name="Sách nấu ăn",Status=true }
            };
            context.BookCategories.AddRange(listCategory);
            context.SaveChanges();


        }
    }
}
