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
    public class SeriesController : ApiController
    {
        private SeriesContext db = new SeriesContext();

        // GET: api/Series
        public IQueryable<Series> GetSeriesDB()
        {
            return db.SeriesDB;
        }

        // GET: api/Series/5
        [ResponseType(typeof(Series))]
        public IHttpActionResult GetSeries(int id)
        {
            Series series = db.SeriesDB.Find(id);
            if (series == null)
            {
                return NotFound();
            }

            return Ok(series);
        }

        // PUT: api/Series/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSeries(int id, Series series)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != series.ID)
            {
                return BadRequest();
            }

            db.Entry(series).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SeriesExists(id))
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

        // POST: api/Series
        [ResponseType(typeof(Series))]
        public IHttpActionResult PostSeries(Series series)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.SeriesDB.Add(series);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = series.ID }, series);
        }

        // DELETE: api/Series/5
        [ResponseType(typeof(Series))]
        public IHttpActionResult DeleteSeries(int id)
        {
            Series series = db.SeriesDB.Find(id);
            if (series == null)
            {
                return NotFound();
            }

            db.SeriesDB.Remove(series);
            db.SaveChanges();

            return Ok(series);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SeriesExists(int id)
        {
            return db.SeriesDB.Count(e => e.ID == id) > 0;
        }
    }
}