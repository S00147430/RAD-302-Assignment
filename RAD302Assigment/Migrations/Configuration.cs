using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using RAD302Assignment.Models;

namespace RAD302Assignment.Migrations
{

    internal sealed class Configuration : DbMigrationsConfiguration<RAD302Assignment.Models.SeriesContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(RAD302Assignment.Models.SeriesContext context)
        {
            List<Series> series = new List<Series>()
            {
                new Series {Name = "Devil May Cry", ID = 1 },
                new Series {Name = "Metal Gear Solid", ID = 2 },
                new Series {Name = "Prince of Persia", ID = 3 }
            };

            series.ForEach(s => context.SeriesDB.Add(s));

            //List<GameCharacter> gamecharacters = new List<GameCharacter>()
            //{
            //    new GameCharacter {Name = "Dante", SeriesID = 1 },
            //    new GameCharacter {Name = "Solid Snake", SeriesID = 2 },
            //    new GameCharacter {Name = "The Prince", SeriesID = 3 },
            //};

            //gamecharacters.ForEach(c => context.GameCharactersDB.Add(c));
            context.SaveChanges();
        }
    }
}
