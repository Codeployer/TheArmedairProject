using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TheArmedairProject.Databases;
using TheArmedairProject.Models;

namespace TheArmedairProject.Controllers
{
    public class AdminPanelController : Controller
    {
        private PostDB db = new PostDB();

        // GET: AdminPanel
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Pages()
        {
            return View();
        }

        public ActionResult Posts()
        {
            return View(db.PostsDB.ToList());
        }

        public ActionResult CreatePage()
        {
            return View();
        }

        public ActionResult CreatePost()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreatePost([Bind(Include = "ID,Title,Author,Content,ReleaseDate")] PostModels postModels)
        {
            if (ModelState.IsValid)
            {
                db.PostsDB.Add(postModels);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(postModels);
        }
    }
}