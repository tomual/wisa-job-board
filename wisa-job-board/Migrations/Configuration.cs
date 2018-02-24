namespace WisaJobBoard.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using WisaJobBoard.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<WisaJobBoard.Models.JobDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(WisaJobBoard.Models.JobDBContext context)
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

            context.Jobs.AddOrUpdate(i => i.Title,
                new Job
                {
                    Title = "IT Manager",
                    Location = "Adelaide",
                    DatePosted = DateTime.Parse("2018-02-01"),
                    Description = "We are looking for an IT Manager"
                },
                new Job
                {
                    Title = "Accountant",
                    Location = "Adelaide",
                    DatePosted = DateTime.Parse("2018-02-10"),
                    Description = "We are looking for an IT Manager"
                },
                new Job
                {
                    Title = "Project Manager",
                    Location = "Adelaide",
                    DatePosted = DateTime.Parse("2018-02-11"),
                    Description = "We are looking for an IT Manager"
                },
                new Job
                {
                    Title = "Python Developer",
                    Location = "Adelaide",
                    DatePosted = DateTime.Parse("2018-02-23"),
                    Description = "We are looking for an IT Manager"
                }
            );
        }
    }
}
