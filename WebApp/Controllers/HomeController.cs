using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        public ActionResult Project()
        {
            ViewBag.Title = "Projects";

            return View();
        }

        public ActionResult Login()
        {
            ViewBag.Title = "Login";

            return View();
        }

        public ActionResult AllProjects()
        {
            ViewBag.Title = "All Projects";

            return View();
        }

        public ActionResult ProjectDetails()
        {
            ViewBag.Title = "Project details";
            return View();
        }

        public ActionResult CreateProject()
        {
            ViewBag.Title = "Create Project";
            return View();
        }

        public ActionResult EditProject()
        {
            ViewBag.Title = "Edit Project";
            return View();
        }

        public ActionResult EditedProject()
        {
            ViewBag.Title = "Edited Project";
            return View();
        }

    }
}
