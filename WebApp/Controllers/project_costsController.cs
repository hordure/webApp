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

namespace WebApp.Controllers
{


    public class project_costsController : ApiController
    {
        private ProjectEntities db = new ProjectEntities();
        private Queries q = new Queries();

        // GET: api/project_costs
        [Route("~/Api/all/project_costs")]
        public IQueryable<project_costs> GetAllproject_costs()
        {
            //Get all project costs with employee name and project title
            var pcWEmp = q.GetAllproject_costs();

            return pcWEmp;
        }

        // GET: api/project_costs
        public IQueryable<project_costs> Getproject_costs()
        {
            // Get all project costs attached to currentProject with employee name and project title
            var ppcWEmp = q.Getproject_costs();

            return ppcWEmp;
        }

        [HttpGet]
        [Route("~/Api/sum/project_costs")]
        public IHttpActionResult SumOfProject_costs()
        {
            //Sum of project_costs
            var sumOfCosts = q.SumOfCosts();

            return Ok(sumOfCosts);
        }

        // GET: api/project_costs/5
        [ResponseType(typeof(project_costs))]
        public IHttpActionResult Getproject_costs(int id)
        {
            project_costs project_costs = db.project_costs.Find(id);


            return Ok(project_costs);
        }

        // PUT: api/project_costs/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putproject_costs(int id, project_costs project_costs)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != project_costs.pcid)
            {
                return BadRequest();
            }

            db.Entry(project_costs).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!project_costsExists(id))
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

        // POST: api/project_costs
        [ResponseType(typeof(project_costs))]
        public IHttpActionResult Postproject_costs(project_costs project_costs)
        {
            Queries q = new Queries();

            project_costs.project_pid = projectsController.CurrentProjectId;

            project_costs.employee_eid = q.GetUserId();
            project_costs.costtimestamp = DateTime.Now;
           
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.project_costs.Add(project_costs);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = project_costs.pcid }, project_costs);
        }

        // DELETE: api/project_costs/5
        [ResponseType(typeof(project_costs))]
        public IHttpActionResult Deleteproject_costs(int id)
        {
            project_costs project_costs = db.project_costs.Find(id);
            if (project_costs == null)
            {
                return NotFound();
            }

            db.project_costs.Remove(project_costs);
            db.SaveChanges();

            return Ok(project_costs);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool project_costsExists(int id)
        {
            return db.project_costs.Count(e => e.pcid == id) > 0;
        }
    }
}