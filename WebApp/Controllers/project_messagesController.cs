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
    //public class pmessagesWEmp : project_messages
    //{
    //    public string  employee { get; set; }
    //}
    public class project_messagesController : ApiController
    {
        Queries q = new Queries();

        private ProjectEntities db = new ProjectEntities();

        // GET: api/project_messages
        [Route("~/Api/all/project_messages")]
        public IQueryable<project_messages> GetAllproject_messages()
        {
            // All project messages with employee name added
            var pmWE = q.GetAllproject_messages();

            return pmWE;
        }

        // GET: api/project_messages
        [Route("~/Api/project_messages")]
        public IQueryable<project_messages> Getproject_messages()
        {
            //All Project messages related to a particular project, with employee name added
            var ppmWE = q.Getproject_messages();

            return ppmWE;
        }

        // GET: api/project_messages/5
        [ResponseType(typeof(project_messages))]
        public IHttpActionResult Getproject_messages(int id)
        {
            project_messages project_messages = db.project_messages.Find(id);
            if (project_messages == null)
            {
                return NotFound();
            }

            return Ok(project_messages);
        }

        // PUT: api/project_messages/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putproject_messages(int id, project_messages project_messages)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != project_messages.pmid)
            {
                return BadRequest();
            }

            db.Entry(project_messages).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!project_messagesExists(id))
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

        // POST: api/project_messages
        [AcceptVerbs("GET", "POST")]
        [System.Web.Http.HttpPost]
        [ResponseType(typeof(project_messages))]
        public IHttpActionResult Postproject_messages(project_messages project_messages)
        {

            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}

            db.project_messages.Add(project_messages);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = project_messages.pmid }, project_messages);
        }

        // DELETE: api/project_messages/5
        [ResponseType(typeof(project_messages))]
        public IHttpActionResult Deleteproject_messages(int id)
        {
            project_messages project_messages = db.project_messages.Find(id);
            if (project_messages == null)
            {
                return NotFound();
            }

            db.project_messages.Remove(project_messages);
            db.SaveChanges();

            return Ok(project_messages);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool project_messagesExists(int id)
        {
            return db.project_messages.Count(e => e.pmid == id) > 0;
        }
    }
}