using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;
using WrocSharpCompetition.Migrations;
using WrocSharpCompetition.Models;

namespace WrocSharpCompetition
{
    public class ApplicatioDbInitializer : MigrateDatabaseToLatestVersion<ApplicationDbContext, WrocSharpCompetition.Migrations.Configuration>
    {
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            LoadModelMappings(modelBuilder);
        }

        private void LoadModelMappings(DbModelBuilder modelBuilder)
        {
            // Load all EntityTypeConfiguration<T> from current assembly and add to configurations
            var mapTypes = from t in typeof(ApplicationDbContext).Assembly.GetTypes()
                           where t.BaseType != null && t.BaseType.IsGenericType && t.BaseType.GetGenericTypeDefinition() == typeof(MappingBase<>)
                           select t;

            foreach (var mapType in mapTypes)
            {
                dynamic mapInstance = Activator.CreateInstance(mapType);
                modelBuilder.Configurations.Add(mapInstance);
            }
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}