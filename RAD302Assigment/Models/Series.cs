using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace RAD302Assignment.Models
{
    public class Series
    {
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        // Navigation property
        public ICollection<GameCharacter> GameCharacters { get; set; }
    }

    public class GameCharacter
    {
        public int ID { get; set; }
        [Required]
        public int SeriesID { get; set; }
        public string Name { get; set; }
        // Navigation property
        public Series Series { get; set; }
    }

    public class SeriesContext : DbContext
    {
        public DbSet<GameCharacter> GameCharactersDB { get; set; }
        public DbSet<Series> SeriesDB { get; set; }

        public SeriesContext() : base("SeriesContext")
        {
            //this.Configuration.LazyLoadingEnabled = false;
        }
    }
}