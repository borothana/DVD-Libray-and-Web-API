namespace DVDWEBAPIData.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DVDWEBAPIData.EF.DvdContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DVDWEBAPIData.EF.DvdContext context)
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
            context.Rating.AddOrUpdate(r => r.Description,
                new DVDWebAPIModels.Rating { Description = "G" },
                new DVDWebAPIModels.Rating { Description = "PG" },
                new DVDWebAPIModels.Rating { Description = "PG-13" }
                );

            context.Director.AddOrUpdate(d => d.Description,
                new DVDWebAPIModels.Director { Description = "Steven Spielberg" },
                new DVDWebAPIModels.Director { Description = "Martin Scorsese" },
                new DVDWebAPIModels.Director { Description = "Quentin Tarantino" }
                );

            context.SaveChanges();

            context.Dvd.AddOrUpdate(
                m => m.Title,
                    new DVDWebAPIModels.Dvd
                    {
                        Title = "Saving Private Ryan",
                        ReleaseYear = 2017,
                        DirectorId = context.Director.First(d => d.Description == "Steven Spielberg").DirectorId,
                        RatingId = context.Rating.First(r => r.Description == "G").RatingId,
                        Note = ""
                    },
                    new DVDWebAPIModels.Dvd
                    {
                        Title = "The Wolf of Wall Street",
                        ReleaseYear = 2016,
                        DirectorId = context.Director.First(d => d.Description == "Martin Scorsese").DirectorId,
                        RatingId = context.Rating.First(r => r.Description == "PG").RatingId,
                        Note = ""
                    },
                    new DVDWebAPIModels.Dvd
                    {
                        Title = "Pulp Fiction",
                        ReleaseYear = 2015,
                        DirectorId = context.Director.First(d => d.Description == "Quentin Tarantino").DirectorId,
                        RatingId = context.Rating.First(r => r.Description == "PG-13").RatingId,
                        Note = ""
                    }

                );
        }
    }
}
