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
    public class project_employeesController : ApiController
    {
        private ProjectEntities db = new ProjectEntities();
        private Queries q = new Queries();

        // GET: api/project_employees
        public IQueryable<tempEmp> Getproject_employees()
        {
            var projectemployees = q.GetProjectEmployees();

            return projectemployees;
        }

        //// GET: api/project_employees/5
        //[ResponseType(typeof(project_employees))]
        //public IHttpActionResult Getproject_employees(int id)
        //{
        //    project_employees project_employees = db.project_employees.Find(id);
        //    if (project_employees == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(project_employees);
        //}

        // GET: api/project_employees/5
        [ResponseType(typeof(tempEmp))]
        public IHttpActionResult Getproject_employees(int id)
        {
            tempEmp t = q.GetProjectEmployee(id);

            return Ok(t);
        }

        // PUT: api/project_employees/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putproject_employees(int id, project_employees project_employees)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != project_employees.peid)
            {
                return BadRequest();
            }

            db.Entry(project_employees).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!project_employeesExists(id))
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

        // POST: api/project_employees
        [ResponseType(typeof(project_employees))]
        public IHttpActionResult Postproject_employees(project_employees project_employees)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.project_employees.Add(project_employees);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = project_employees.peid }, project_employees);
        }

        // DELETE: api/project_employees/5
        [ResponseType(typeof(project_employees))]
        public IHttpActionResult Deleteproject_employees(int id)
        {
            project_employees project_employees = db.project_employees.Find(id);
            if (project_employees == null)
            {
                return NotFound();
            }

            db.project_employees.Remove(project_employees);
            db.SaveChanges();

            return Ok(project_employees);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool project_employeesExists(int id)
        {
            return db.project_employees.Count(e => e.peid == id) > 0;
        }
    }
}