using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using RAD302Assignment.Models;

namespace RAD302Assignment.Controllers
{
    public class GameCharactersController : ApiController
    {
        private SeriesContext db = new SeriesContext();

        // GET: api/GameCharacters
        public IQueryable<Series> GetSeries()
        {
            return db.SeriesDB.Include(c => c.GameCharacters);
        }

        // GET: api/GameCharacters/5
        [ResponseType(typeof(Series))]
        public IHttpActionResult GetSeries(int id)
        {
            Series @series = db.SeriesDB.Find(id);
            if (@series == null)
            {
                return NotFound();
            }

            List<GameCharacter> characters = db.GameCharactersDB.Where(s => s.SeriesID == @series.ID).ToList();
            @series.GameCharacters = characters;

            return Ok(@series);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }      
    }
}