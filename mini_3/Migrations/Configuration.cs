namespace mini_3.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<mini_3.Database.Databaserepo>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "mini_3.Database.Databaserepo";
        }

        protected override void Seed(mini_3.Database.Databaserepo context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
