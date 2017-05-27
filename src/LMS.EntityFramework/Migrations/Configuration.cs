using LMS.Migrations.Seed.Host;
using System.Data.Entity.Migrations;

namespace LMS.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<LMS.EntityFramework.LmsDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "LMS";
        }

        protected override void Seed(LMS.EntityFramework.LmsDbContext context)
        {
            // This method will be called every time after migrating to the latest version.
            // You can add any seed data here...
            new InitialHostDbBuilder(context).Create();
        }
    }
}
