namespace HomeWork_06.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<HomeWork_06.EF.MusicLibrary>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "HomeWork_06.EF.MusicLibrary";
        }

        protected override void Seed(HomeWork_06.EF.MusicLibrary context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
