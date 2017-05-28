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
using Database;

namespace AngielskiWebApi.Controllers
{
    public class WordsController : ApiController
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: api/Words
         [Route("api/Get")]
        public List<Words> GetWords()
        {
            return db.Words.ToList();
        }

         [Route("api/Get2")]
         public string GetWords2()
         {
             return "test";
         }

        // GET: api/Words/5
        [ResponseType(typeof(Words))]
        public IHttpActionResult GetWords(int id)
        {
            Words words = db.Words.Find(id);
            if (words == null)
            {
                return NotFound();
            }

            return Ok(words);
        }

        // PUT: api/Words/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutWords(int id, Words words)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != words.Id)
            {
                return BadRequest();
            }

            db.Entry(words).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WordsExists(id))
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

        // POST: api/Words
        [ResponseType(typeof(Words))]
        public IHttpActionResult PostWords(Words words)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Words.Add(words);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = words.Id }, words);
        }

        // DELETE: api/Words/5
        [ResponseType(typeof(Words))]
        public IHttpActionResult DeleteWords(int id)
        {
            Words words = db.Words.Find(id);
            if (words == null)
            {
                return NotFound();
            }

            db.Words.Remove(words);
            db.SaveChanges();

            return Ok(words);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool WordsExists(int id)
        {
            return db.Words.Count(e => e.Id == id) > 0;
        }
    }
}