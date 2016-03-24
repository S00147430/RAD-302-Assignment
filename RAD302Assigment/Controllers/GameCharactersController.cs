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

namespace RAD302Assigment.Controllers
{
    public class GameCharactersController : ApiController
    {
        private SeriesContext db = new SeriesContext();

        // GET: api/GameCharacters
        public IQueryable<Series> GetSeries()
        {
            return db.Series.Include(c => c.Characters);
        }

        // GET: api/GameCharacters/5
        [ResponseType(typeof(Series))]
        public IHttpActionResult GetSeries(int id)
        {
            Series @series = db.Series.Find(id);
            if (@series == null)
            {
                return NotFound();
            }

            //  For each student where student.ClassID == class id, save student to a list
            List<GameCharacter> characters = db.GameCharacters.Where(s => s.SeriesID == @series.ID).ToList();
            @series.Characters = characters;

            return Ok(@series);
        }

        // PUT: api/GameCharacters/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutGameCharacter(int id, GameCharacter gameCharacter)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != gameCharacter.ID)
            {
                return BadRequest();
            }

            db.Entry(gameCharacter).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GameCharacterExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/GameCharacters
        [ResponseType(typeof(GameCharacter))]
        public IHttpActionResult PostGameCharacter(GameCharacter gameCharacter)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.GameCharacters.Add(gameCharacter);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = gameCharacter.ID }, gameCharacter);
        }

        // DELETE: api/GameCharacters/5
        [ResponseType(typeof(GameCharacter))]
        public IHttpActionResult DeleteGameCharacter(int id)
        {
            GameCharacter gameCharacter = db.GameCharacters.Find(id);
            if (gameCharacter == null)
            {
                return NotFound();
            }

            db.GameCharacters.Remove(gameCharacter);
            db.SaveChanges();

            return Ok(gameCharacter);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool GameCharacterExists(int id)
        {
            return db.GameCharacters.Count(e => e.ID == id) > 0;
        }
    }

    public class ClassesController : ApiController
    {
        private SeriesContext db = new SeriesContext();

        // GET: api/Classes
        public IQueryable<Series> GetClasses()
        {
            return db.Series.Include(c => c.Characters);
        }

        // GET: api/Classes/5
        [ResponseType(typeof(Series))]
        public IHttpActionResult GetClass(int id)
        {
            Series @series = db.Series.Find(id);
            if (@series == null)
            {
                return NotFound();
            }

            //  For each student where student.ClassID == class id, save student to a list
            List<GameCharacter> students = db.GameCharacters.Where(s => s.SeriesID == @series.ID).ToList();
            @series.Characters = students;

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