using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TheArmedairProject.Databases;
using TheArmedairProject.Models;

namespace TheArmedairProject.Controllers
{
    public class UsersController : Controller
    {
        private PermDB db = new PermDB();

        // GET: Users
        public ActionResult Index()
        {
            var usersDB = db.UsersDB.Include(u => u.Permissions);
            return View(usersDB.ToList());
        }

        // GET: Users/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UsersModels usersModels = db.UsersDB.Find(id);
            if (usersModels == null)
            {
                return HttpNotFound();
            }
            return View(usersModels);
        }

        // GET: Users/Create
        public ActionResult Create()
        {
            ViewBag.PermID = new SelectList(db.PermissionsDB, "PermID", "PermName");
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserID,Nick,Email,PermID")] UsersModels usersModels)
        {
            if (ModelState.IsValid)
            {
                db.UsersDB.Add(usersModels);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PermID = new SelectList(db.PermissionsDB, "PermID", "PermName", usersModels.PermID);
            return View(usersModels);
        }

        // GET: Users/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UsersModels usersModels = db.UsersDB.Find(id);
            if (usersModels == null)
            {
                return HttpNotFound();
            }
            ViewBag.PermID = new SelectList(db.PermissionsDB, "PermID", "PermName", usersModels.PermID);
            return View(usersModels);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserID,Nick,Email,PermID")] UsersModels usersModels)
        {
            if (ModelState.IsValid)
            {
                db.Entry(usersModels).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PermID = new SelectList(db.PermissionsDB, "PermID", "PermName", usersModels.PermID);
            return View(usersModels);
        }

        // GET: Users/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UsersModels usersModels = db.UsersDB.Find(id);
            if (usersModels == null)
            {
                return HttpNotFound();
            }
            return View(usersModels);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UsersModels usersModels = db.UsersDB.Find(id);
            db.UsersDB.Remove(usersModels);
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
