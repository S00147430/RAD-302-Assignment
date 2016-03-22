namespace RAD302Assignment.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Models;

    internal sealed class Configuration : DbMigrationsConfiguration<RAD302Assignment.Models.SeriesContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(RAD302Assignment.Models.SeriesContext context)
        {
            List<Series> Series = new List<Series>()
            {
                new Series {Name = "Devil May Cry" },
                new Series {Name = "Metal Gear Solid" },
                new Series {Name = "Prince of Persia" }
            };

            Series.ForEach(s => context.Series.Add(s));

            List<GameCharacter> gamecharacters = new List<GameCharacter>()
            {
                new GameCharacter {Name = "Dante", SeriesID = 1 },
                new GameCharacter {Name = "Solid Snake", SeriesID = 2 },
                new GameCharacter {Name = "The Prince", SeriesID = 3 },
            };

            gamecharacters.ForEach(c => context.GameCharacters.Add(c));
        }
    }
}
