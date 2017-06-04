using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TheArmedairProject.Controllers
{
    public class ErrorsController : Controller
    {
        // GET: Errors
        public ActionResult Err404()
        {
            Response.StatusCode = 404;
            return View();
        }
    }
}