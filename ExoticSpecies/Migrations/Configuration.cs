namespace ExoticSpeciesOfTheNorth.Migrations
{
    using ExoticSpeciesOfTheNorth.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ExoticSpeciesOfTheNorth.Models.ExoticSpeciesDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        // Seed Homelands and Species tables:
        protected override void Seed(ExoticSpeciesOfTheNorth.Models.ExoticSpeciesDbContext context)
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

            context.MyHomelands.AddOrUpdate(mh => mh.HomelandId,
                new Homeland()
                {
                    HomelandId = 1,
                    HomelandName = "North America"
                },
                new Homeland()
                {
                    HomelandId = 2,
                    HomelandName = "South America"
                },
                new Homeland()
                {
                    HomelandId = 3,
                    HomelandName = "Europe"
                },
                new Homeland()
                {
                    HomelandId = 4,
                    HomelandName = "Russia"
                },
                new Homeland()
                {
                    HomelandId = 5,
                    HomelandName = "Middle East"
                },
                new Homeland()
                {
                    HomelandId = 6,
                    HomelandName = "Asia"
                },
                new Homeland()
                {
                    HomelandId = 7,
                    HomelandName = "Africa"
                },
                new Homeland()
                {
                    HomelandId = 8,
                    HomelandName = "Australia"
                }
            );

            context.SaveChanges();

            context.MySpecies.AddOrUpdate(ms => ms.SpeciesId,
                new Species()
                {
                    SpeciesId = 1,
                    SpeciesName = "House Sparrow",
                    DateIntroduced = new DateTime(1850, 1, 1, 0, 0, 0),
                    SpeciesHomeland = context.MyHomelands.Where(mh => mh.HomelandName == "Europe").SingleOrDefault()
                },
                new Species()
                {
                    SpeciesId = 2,
                    SpeciesName = "European Starling",
                    DateIntroduced = new DateTime(1890, 1, 1, 0, 0, 0),
                    SpeciesHomeland = context.MyHomelands.Where(mh => mh.HomelandName == "Europe").SingleOrDefault()
                },
                new Species()
                {
                    SpeciesId = 3,
                    SpeciesName = "Emerald Ash Borer",
                    DateIntroduced = new DateTime(2002, 1, 1, 0, 0, 0),
                    SpeciesHomeland = context.MyHomelands.Where(mh => mh.HomelandName == "Asia").SingleOrDefault()
                },
                new Species()
                {
                    SpeciesId = 4,
                    SpeciesName = "Asian Longhored Beetle",
                    DateIntroduced = new DateTime(1980, 1, 1, 0, 0, 0),
                    SpeciesHomeland = context.MyHomelands.Where(mh => mh.HomelandName == "Asia").SingleOrDefault()
                },
                new Species()
                {
                    SpeciesId = 5,
                    SpeciesName = "Broad-leaved Paperbark",
                    DateIntroduced = new DateTime(1900, 1, 1, 0, 0, 0),
                    SpeciesHomeland = context.MyHomelands.Where(mh => mh.HomelandName == "Australia").SingleOrDefault()
                },
                new Species()
                {
                    SpeciesId = 6,
                    SpeciesName = "American Bullfrog",
                    DateIntroduced = new DateTime(1900, 1, 1, 0, 0, 0),
                    SpeciesHomeland = context.MyHomelands.Where(mh => mh.HomelandName == "Australia").SingleOrDefault()
                },
                new Species()
                {
                    SpeciesId = 7,
                    SpeciesName = "Burmese Python",
                    DateIntroduced = new DateTime(2000, 1, 1, 0, 0, 0),
                    SpeciesHomeland = context.MyHomelands.Where(mh => mh.HomelandName == "Australia").SingleOrDefault()
                }
            );

            context.SaveChanges();
        }
    }
}
