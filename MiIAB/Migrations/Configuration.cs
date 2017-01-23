namespace MiIAB.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    internal sealed class Configuration : DbMigrationsConfiguration<MiIAB.Models.MiIABContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(MiIAB.Models.MiIABContext context)
        {            
            SeedRoles(context);
            SeedUsers(context);
            SeedProducts(context);
        }

        private void SeedProducts(MiIABContext context)
        {
            for (int i = 1; i <= 10; i++)
            {
                var product = new Product()
                {
                    Id = i,
                    Name = "Produkt " + i.ToString(),
                    Price = i
                };
                context.Set<Product>().AddOrUpdate(product);
            }
            context.SaveChanges();
        }

        private void SeedUsers(MiIABContext context)
        {
            var store = new UserStore<User>(context);
            var manager = new UserManager<User>(store);
            if (!context.Users.Any(u => u.UserName == "Admin@a.a"))
            {
                var user = new User
                {
                    UserName = "Admin@a.a",
                    Email = "zntklol@gmail.com",
                    EmailConfirmed = true
                };
                var adminresult = manager.Create(user, "12345678");
                if (adminresult.Succeeded) manager.AddToRole(user.Id, "Admin");
            }
            if (!context.Users.Any(u => u.UserName == "Customer@a.a"))
            {
                var user = new User
                {
                    UserName = "Customer@a.a",
                    Email = "zntklol@gmail.com",
                    EmailConfirmed = true
                };
                var adminresult = manager.Create(user, "12345678");
                if (adminresult.Succeeded) manager.AddToRole(user.Id, "Customer");
            }
        }

        private void SeedRoles(MiIABContext context)
        {
            var roleManager = new RoleManager<Microsoft.AspNet.Identity.EntityFramework.IdentityRole>(new RoleStore<IdentityRole>());
            if (!roleManager.RoleExists("Admin"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Admin"; roleManager.Create(role);
            }
            if (!roleManager.RoleExists("Customer"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Customer"; roleManager.Create(role);
            }
        }
    }
}
