using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVCparcial1F.Models;

namespace MVCparcial1F.Controllers
{
    public class AleMenachoFriendsController : Controller
    {
        private DataContext db = new DataContext();

        // GET: AleMenachoFriends
        public ActionResult Index()
        {
            return View(db.AleMenachoFriends.ToList());
        }

        // GET: AleMenachoFriends/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AleMenachoFriend aleMenachoFriend = db.AleMenachoFriends.Find(id);
            if (aleMenachoFriend == null)
            {
                return HttpNotFound();
            }
            return View(aleMenachoFriend);
        }

        // GET: AleMenachoFriends/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AleMenachoFriends/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FriendId,Name,Nickname,Birthday,Type")] AleMenachoFriend aleMenachoFriend)
        {
            if (ModelState.IsValid)
            {
                db.AleMenachoFriends.Add(aleMenachoFriend);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(aleMenachoFriend);
        }

        // GET: AleMenachoFriends/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AleMenachoFriend aleMenachoFriend = db.AleMenachoFriends.Find(id);
            if (aleMenachoFriend == null)
            {
                return HttpNotFound();
            }
            return View(aleMenachoFriend);
        }

        // POST: AleMenachoFriends/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FriendId,Name,Nickname,Birthday,Type")] AleMenachoFriend aleMenachoFriend)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aleMenachoFriend).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(aleMenachoFriend);
        }

        // GET: AleMenachoFriends/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AleMenachoFriend aleMenachoFriend = db.AleMenachoFriends.Find(id);
            if (aleMenachoFriend == null)
            {
                return HttpNotFound();
            }
            return View(aleMenachoFriend);
        }

        // POST: AleMenachoFriends/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AleMenachoFriend aleMenachoFriend = db.AleMenachoFriends.Find(id);
            db.AleMenachoFriends.Remove(aleMenachoFriend);
            db.SaveChanges();
            return RedirectToAction("Index");
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
