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
    

    public class projectWEmp : project
    {
        public string employee { get; set; }
    }

    public class projectsController : ApiController
    {

        private ProjectEntities db = new ProjectEntities();
        private Queries q = new Queries();
        string username = WebApp.Models.ApplicationUser.CurrentUser;
        

        public static int CurrentProjectId { get; set; }
        public static int CurrentEmpId { get; set; }

        


        

        // GET: api/projects
        [HttpGet]
        public IEnumerable<projectWEmp>Getprojects() 
        {
            //Get all projects where logged in user is owner
            var pWEmp = q.Getprojects();
            return pWEmp;
        }


        [Route("~/Api/affiliate/projects")]
        public IEnumerable<project> GetAffiliateProjects()
        {

            var apWEmp = q.GetAffiliateProjects();

            return apWEmp;
        }


        [Route("~/Api/all/projects")]
        public IEnumerable<project>GetAllProjects()
        {
            return db.projects;
        }

  
        // GET: api/projects/5
        [ResponseType(typeof(project))]
        public IHttpActionResult Getproject(int id)
        {

            CurrentProjectId = id;

            project project = db.projects.Find(id);
            if (project == null)
            {
                return NotFound();
            }

            return Ok(project);
            
         

          
        }



        // PUT: api/projects/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putproject(int id, project project)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != project.pid)
            {
                return BadRequest();
            }

            db.Entry(project).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!projectExists(id))
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

        // POST: api/projects
        [ResponseType(typeof(project))]
        public IHttpActionResult Postproject(project project)
        {
            project.pdate = DateTime.Now;
            project.employee_eid = q.GetUserId();

           
           
            db.projects.Add(project);

            db.SaveChanges();

            project_messages pm = new project_messages();

            pm.project_pid = project.pid;
            pm.projectmessage = "*** Verkefni stofnað ***";
            pm.messagetimestamp = DateTime.Now;
            pm.employee_eid = q.GetUserId();

            db.project_messages.Add(pm);
            db.SaveChanges();
           

            return CreatedAtRoute("DefaultApi", new { id = project.pid }, project);
        }

        // DELETE: api/projects/5
        [ResponseType(typeof(project))]
        public IHttpActionResult Deleteproject(int id)
        {
            project project = db.projects.Find(id);
            if (project == null)
            {
                return NotFound();
            }

            db.projects.Remove(project);
            db.SaveChanges();

            return Ok(project);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool projectExists(int id)
        {
            return db.projects.Count(e => e.pid == id) > 0;
        }
    }
}