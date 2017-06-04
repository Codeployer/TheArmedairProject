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
    public class PermissionsController : Controller
    {
        private PermDB db = new PermDB();

        // GET: Permissions
        public ActionResult Index()
        {
            return View(db.PermissionsDB.ToList());
        }

        // GET: Permissions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PermissionsModels permissionsModels = db.PermissionsDB.Find(id);
            if (permissionsModels == null)
            {
                return HttpNotFound();
            }
            return View(permissionsModels);
        }

        // GET: Permissions/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Permissions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PermID,PermName")] PermissionsModels permissionsModels)
        {
            if (ModelState.IsValid)
            {
                db.PermissionsDB.Add(permissionsModels);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(permissionsModels);
        }

        // GET: Permissions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PermissionsModels permissionsModels = db.PermissionsDB.Find(id);
            if (permissionsModels == null)
            {
                return HttpNotFound();
            }
            return View(permissionsModels);
        }

        // POST: Permissions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PermID,PermName")] PermissionsModels permissionsModels)
        {
            if (ModelState.IsValid)
            {
                db.Entry(permissionsModels).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(permissionsModels);
        }

        // GET: Permissions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PermissionsModels permissionsModels = db.PermissionsDB.Find(id);
            if (permissionsModels == null)
            {
                return HttpNotFound();
            }
            return View(permissionsModels);
        }

        // POST: Permissions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PermissionsModels permissionsModels = db.PermissionsDB.Find(id);
            db.PermissionsDB.Remove(permissionsModels);
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
