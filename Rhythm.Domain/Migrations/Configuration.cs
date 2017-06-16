namespace Rhythm.Domain.Migrations
{
    using Entities;
    using Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    using System.Security.Claims;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.Owin;
    using Microsoft.Owin;
    using Microsoft.Owin.Security;
    using System.Web;

    internal sealed class Configuration : DbMigrationsConfiguration<Rhythm.Domain.Context.DogCodingContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Rhythm.Domain.Context.DogCodingContext context)
        {
        }
    }
}
