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
using APIparcial1.Models;

namespace APIparcial1.Controllers
{
    public class AleMenachoFriendsController : ApiController
    {
        private DataContext db = new DataContext();

        // GET: api/AleMenachoFriends
        public IQueryable<AleMenachoFriends> GetAleMenachoFriends()
        {
            return db.AleMenachoFriends;
        }

        // GET: api/AleMenachoFriends/5
        [ResponseType(typeof(AleMenachoFriends))]
        public IHttpActionResult GetAleMenachoFriends(int id)
        {
            AleMenachoFriends aleMenachoFriends = db.AleMenachoFriends.Find(id);
            if (aleMenachoFriends == null)
            {
                return NotFound();
            }

            return Ok(aleMenachoFriends);
        }

        // PUT: api/AleMenachoFriends/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAleMenachoFriends(int id, AleMenachoFriends aleMenachoFriends)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != aleMenachoFriends.FriendId)
            {
                return BadRequest();
            }

            db.Entry(aleMenachoFriends).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AleMenachoFriendsExists(id))
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

        // POST: api/AleMenachoFriends
        [ResponseType(typeof(AleMenachoFriends))]
        public IHttpActionResult PostAleMenachoFriends(AleMenachoFriends aleMenachoFriends)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.AleMenachoFriends.Add(aleMenachoFriends);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = aleMenachoFriends.FriendId }, aleMenachoFriends);
        }

        // DELETE: api/AleMenachoFriends/5
        [ResponseType(typeof(AleMenachoFriends))]
        public IHttpActionResult DeleteAleMenachoFriends(int id)
        {
            AleMenachoFriends aleMenachoFriends = db.AleMenachoFriends.Find(id);
            if (aleMenachoFriends == null)
            {
                return NotFound();
            }

            db.AleMenachoFriends.Remove(aleMenachoFriends);
            db.SaveChanges();

            return Ok(aleMenachoFriends);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AleMenachoFriendsExists(int id)
        {
            return db.AleMenachoFriends.Count(e => e.FriendId == id) > 0;
        }
    }
}