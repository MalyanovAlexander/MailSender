namespace MailSender.ConsoleTest2.Data.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    //В консоли диспетчера пакетов NuGet: Enable-Migrations -MigrationsDirectory Data\Migrations 
    internal sealed class Configuration : DbMigrationsConfiguration<SongsDB>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            MigrationsDirectory = @"Data\Migrations";
        }

        protected override void Seed(SongsDB db)
        {
            for (int i = 1; i <= 3; i++)
            {
                var artist = new Artist
                {
                    Name = $"Artist_name {i}",
                    Birthday = DateTime.Now.Subtract(TimeSpan.FromDays(365 * (i + 20))),
                    Tracks = new List<Track>()
                };
                artist.Tracks = new List<Track>();

                for (int j = 1; j <= 3; j++)
                {
                    var track = new Track
                    {
                        Name = $"Track {i + j}",
                        Length = j * 456
                    };
                    artist.Tracks.Add(track);
                }
                db.Artists.Add(artist);
            }
            db.SaveChanges();
        }
    }
}
