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
            ViewBag.PageTitle = "Dashboard";
            ViewBag.Description = "Manage Your Site";
            return View();
        }

        public ActionResult Pages()
        {
            ViewBag.PageTitle = "Pages";
            ViewBag.Description = "Pages Management";
            return View();
        }

        public ActionResult Posts()
        {
            ViewBag.PageTitle = "Posts";
            ViewBag.Description = "Posts Management";
            return View(db.PostsDB.ToList());
        }

        public ActionResult CreatePage()
        {
            ViewBag.PageTitle = "Create New Page";
            ViewBag.Description = "Let's develop out site...";
            return View();
        }

        public ActionResult CreatePost()
        {
            ViewBag.PageTitle = "Create New Post";
            ViewBag.Description = "Add Your Post...";
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