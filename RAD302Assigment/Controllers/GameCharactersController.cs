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
        public IQueryable<GameCharacter> GetGameCharactersDB()
        {
            return db.GameCharactersDB;
        }

        // GET: api/GameCharacters/5
        [ResponseType(typeof(GameCharacter))]
        public IHttpActionResult GetGameCharacter(int id)
        {
            GameCharacter gameCharacter = db.GameCharactersDB.Find(id);
            if (gameCharacter == null)
            {
                return NotFound();
            }

            return Ok(gameCharacter);
        }

        //For selected Characters.
        //public IQueryable<GameCharacter> GetGameCharactersDB()
        //{
        //    return db.GameCharactersDB.Include(c => c.Name);
        //}

        //// GET: api/GameCharacters/5
        //[ResponseType(typeof(Series))]
        //public IHttpActionResult GetGameCharacter(int id)
        //{
        //    Series @series = db.SeriesDB.Find(id);
        //    if (@series == null)
        //    {
        //        return NotFound();
        //    }

        //    List<GameCharacter> gameCharacters = db.GameCharactersDB.Where(s => s.SeriesID == @series.ID).ToList();
        //    @series.GameCharacters = gameCharacters;

        //    return Ok(gameCharacters);
        //}

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

            db.GameCharactersDB.Add(gameCharacter);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = gameCharacter.ID }, gameCharacter);
        }

        // DELETE: api/GameCharacters/5
        [ResponseType(typeof(GameCharacter))]
        public IHttpActionResult DeleteGameCharacter(int id)
        {
            GameCharacter gameCharacter = db.GameCharactersDB.Find(id);
            if (gameCharacter == null)
            {
                return NotFound();
            }

            db.GameCharactersDB.Remove(gameCharacter);
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
            return db.GameCharactersDB.Count(e => e.ID == id) > 0;
        }
    }
}