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
    public class PostController : Controller
    {
        private PostDB db = new PostDB();

        // GET: Post
        public ActionResult Index()
        {
            return View(db.PostsDB.ToList());
        }

        // GET: Post/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PostModels postModels = db.PostsDB.Find(id);
            if (postModels == null)
            {
                return HttpNotFound();
            }
            return View(postModels);
        }

        // GET: Post/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Post/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Title,Author,Content,ReleaseDate")] PostModels postModels)
        {
            if (ModelState.IsValid)
            {
                db.PostsDB.Add(postModels);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(postModels);
        }

        // GET: Post/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PostModels postModels = db.PostsDB.Find(id);
            if (postModels == null)
            {
                return HttpNotFound();
            }
            return View(postModels);
        }

        // POST: Post/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Title,Author,Content,ReleaseDate")] PostModels postModels)
        {
            if (ModelState.IsValid)
            {
                db.Entry(postModels).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(postModels);
        }

        // GET: Post/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PostModels postModels = db.PostsDB.Find(id);
            if (postModels == null)
            {
                return HttpNotFound();
            }
            return View(postModels);
        }

        // POST: Post/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PostModels postModels = db.PostsDB.Find(id);
            db.PostsDB.Remove(postModels);
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
