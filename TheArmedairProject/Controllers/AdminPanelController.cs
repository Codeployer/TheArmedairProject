using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TheArmedairProject.Controllers
{
    public class AdminPanelController : Controller
    {
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
            return View();
        }

        public ActionResult CreatePage()
        {
            return View();
        }

        public ActionResult CreatePost()
        {
            return View();
        }
    }
}