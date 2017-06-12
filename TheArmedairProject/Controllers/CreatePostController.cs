using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TheArmedairProject.Databases;
using TheArmedairProject.Models;

namespace TheArmedairProject.Controllers
{
    public class CreatePostController : Controller
    {
        private PostDB db = new PostDB();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index([Bind(Include = "ID,Title,Author,Content,ReleaseDate")] PostModels postModels)
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