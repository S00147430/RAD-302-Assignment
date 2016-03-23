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
        public IQueryable<GameCharacter> GetGameCharacters()
        {
            return db.GameCharacters;
        }

        // GET: api/GameCharacters/5
        [ResponseType(typeof(GameCharacter))]
        public IHttpActionResult GetGameCharacter(int id)
        {
            GameCharacter gameCharacter = db.GameCharacters.Find(id);
            if (gameCharacter == null)
            {
                return NotFound();
            }

            return Ok(gameCharacter);
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
}