using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebApp.Models;
using WebApp.Extra_Entities;

namespace WebApp.Controllers
{

    public class project_hoursController : ApiController
    {
        private ProjectEntities db = new ProjectEntities();
        private Queries q = new Queries();

        // GET: api/project_costs
        [Route("~/Api/all/project_hours")]
        public IQueryable<project_hours> GetAllproject_hours()
        {
            //Get all project costs with employee name and project title
            var aphWEmp = q.GetAllproject_hours();

            return aphWEmp;
        }

        [HttpGet]
        [Route("~/Api/sum/project_hours")]
        public IHttpActionResult SumOfProject_hours()
        {
            //Sum of project_hours
            var sumOfHours = q.SumOfProject_hours();

            return Ok(sumOfHours);
        }

        // GET: api/project_hours
        public IQueryable<project_hours> Getproject_hours()
        {
            var phWEmp = q.Getproject_hours();

            return phWEmp;
        }

        // GET: api/project_hours/5
        [ResponseType(typeof(project_hours))]
        public IHttpActionResult Getproject_hours(int id)
        {
            project_hours project_hours = db.project_hours.Find(id);
            if (project_hours == null)
            {
                return NotFound();
            }

            return Ok(project_hours);
        }

        // PUT: api/project_hours/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putproject_hours(int id, project_hours project_hours)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != project_hours.phid)
            {
                return BadRequest();
            }

            db.Entry(project_hours).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!project_hoursExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/project_hours
        [ResponseType(typeof(project_hours))]
        public IHttpActionResult Postproject_hours(project_hours project_hours)
        {
            
            

            Queries q = new Queries();

            project_hours.project_pid = projectsController.CurrentProjectId;

            project_hours.employee_eid = q.GetUserId();
            project_hours.hourtimestamp = DateTime.Now;
            
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.project_hours.Add(project_hours);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = project_hours.phid }, project_hours);
        }

        // DELETE: api/project_hours/5
        [ResponseType(typeof(project_hours))]
        public IHttpActionResult Deleteproject_hours(int id)
        {
            project_hours project_hours = db.project_hours.Find(id);
            if (project_hours == null)
            {
                return NotFound();
            }

            db.project_hours.Remove(project_hours);
            db.SaveChanges();

            return Ok(project_hours);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool project_hoursExists(int id)
        {
            return db.project_hours.Count(e => e.phid == id) > 0;
        }
    }
}