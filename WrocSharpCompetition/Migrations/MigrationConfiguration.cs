using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using WrocSharpCompetition.Models;

namespace WrocSharpCompetition.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<WrocSharpCompetition.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(WrocSharpCompetition.ApplicationDbContext context)
        {
            CreateAdminUser(context);
            CreateTests(context);
        }

        private void CreateAdminUser(ApplicationDbContext context)
        {
            context.Users.AddOrUpdate(u => u.Email,
                new ApplicationUser()
                {
                    UserName = "wrocsharpcompetition@gmail.com",
                    Email = "wrocsharpcompetition@gmail.com",
                    PasswordHash = new PasswordHasher().HashPassword("wrocsharp321_"),
                    SecurityStamp = Guid.NewGuid().ToString(),
                    EmailConfirmed = true
                }
            );

            context.Roles.AddOrUpdate(r => r.Name,
                  new IdentityRole()
                  {
                      Name = "Admin"
                  }
              );

            context.SaveChanges();


            var user = context.Users.First(el => el.Email == "wrocsharpcompetition@gmail.com");
            var role = context.Roles.First(el => el.Name == "Admin");
            context.Set<IdentityUserRole>().AddOrUpdate(ur => new { ur.RoleId, ur.UserId }, new IdentityUserRole() { RoleId = role.Id, UserId = user.Id });
        }
        private void CreateTests(ApplicationDbContext context)
        {
            var tests = Enumerable.Range(1, 6).Select(i => new Test() {Number = i}).ToArray();

            var databaseTests = context.Set<Test>().ToList();
            foreach (var test in tests)
            {
                if(!databaseTests.Select(el => el.Number).Contains(test.Number))
                    context.Set<Test>().Add(test);

            }
        }

    }
}
