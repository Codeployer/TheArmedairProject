using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TheArmedairProject.Databases;

namespace TheArmedairProject.Controllers
{
    public class HomeController : Controller
    {
        private PostDB db = new PostDB();

        public ActionResult Index()
        {
            return View(db.PostsDB.ToList());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}