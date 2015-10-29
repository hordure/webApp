using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApp.Controllers
{
    public class OtherViewsController : Controller
    {
        // GET: OtherViews
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Employees ()
        {
            ViewBag.Title = " Employees";
            return View();
        }

        public ActionResult EmployeeDetails()
        {
            ViewBag.Title = "Employee details";
            return View();
        }

        public ActionResult EditEmployee()
        {
            ViewBag.Title = "Edit employee";
            return View();
        }

        public ActionResult EditedEmployee()
        {
            ViewBag.Title = "Edited employee";
            return View();
        }

        public ActionResult ProjectMessages()
        {
            ViewBag.Title = "All Project Messages";
            return View();
        }

        public ActionResult ProjectMessageDetail()
        {
            ViewBag.Title = "Project Details";
            return View();
        }

        public ActionResult EditProjectMessage()
        {
            ViewBag.Title = "Edit project message";
            return View();
        }

        public ActionResult EditedProjectMessage()
        {
            ViewBag.Title = "Edited project message";
            return View();
        }

        public ActionResult ProjectCosts()
        {
            ViewBag.Title = "All Project Costs";
            return View();
        }

        public ActionResult ProjectCostDetail()
        {
            ViewBag.Title = "Project Cost Details";
            return View();
        }

        public ActionResult EditProjectCost()
        {
            ViewBag.Title = "Edit project cost";
            return View();
        }

        public ActionResult EditedProjectCost()
        {
            ViewBag.Title = "Edited project cost";
            return View();
        }

        public ActionResult ProjectHours()
        {
            ViewBag.Title = "Project Hours";
            return View();
        }

        public ActionResult ProjectHourDetails ()
        {
            ViewBag.Title = "Project hour details";
            return View();
        }

        public ActionResult EditProjectHours ()
        {
            ViewBag.Title= "Edit project hours";
            return View();
        }

        public ActionResult EditedProjectHours()
        {
            ViewBag.Title = "Edited project hours";
            return View();
        }
    }
}