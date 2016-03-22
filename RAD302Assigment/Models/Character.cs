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
        public ICollection<GameCharacter> Characters { get; set; }
    }

    public class GameCharacter
    {
        public int ID { get; set; }
        [Required]
        public int SeriesID { get; set; }
        public string Name { get; set; }
        // Navigation property
        public GameCharacter series { get; set; }
    }

    public class SeriesContext : DbContext
    {
        public DbSet<Series> Series { get; set; }
        public DbSet<GameCharacter> GameCharacters { get; set; }

        public SeriesContext() : base("SeriesConnection")
        {

        }
    }
}