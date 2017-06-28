namespace Rhythm.Domain.Migrations
{
    using Entities;
    using Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System.Data.Entity.Migrations;
    using Microsoft.AspNet.Identity;

    internal sealed class Configuration : DbMigrationsConfiguration<Rhythm.Domain.Context.DogCodingContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Rhythm.Domain.Context.DogCodingContext context)
        {
            var userManager = new DogUserManager(new UserStore<User>(context));

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            var role = new IdentityRole { Name = "admin" };

            roleManager.Create(role);


            var admin = new User { Email = "makarevich@admin.com", UserName = "makarevich@admin.com" };
            string password = "qwerty123456!@#$%^";
            var result = userManager.Create(admin, password);

            if (result.Succeeded)
            {
                userManager.AddToRole(admin.Id, role.Name);
            }

            base.Seed(context);
        }
    }
}
