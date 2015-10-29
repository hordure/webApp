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
    public class addproject_messageController : ApiController
    {
        private ProjectEntities db = new ProjectEntities();

        //// GET: api/addproject_message
        //public IQueryable<project_messages> Getproject_messages()
        //{
        //    return db.project_messages;
        //}

        //// GET: api/addproject_message/5
        //[ResponseType(typeof(project_messages))]
        //public IHttpActionResult Getproject_messages(int id)
        //{
        //    project_messages project_messages = db.project_messages.Find(id);
        //    if (project_messages == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(project_messages);
        //}

        //// PUT: api/addproject_message/5
        //[ResponseType(typeof(void))]
        //public IHttpActionResult Putproject_messages(int id, project_messages project_messages)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != project_messages.pmid)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(project_messages).State = EntityState.Modified;

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!project_messagesExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return StatusCode(HttpStatusCode.NoContent);
        //}

        // POST: api/addproject_message
        [ResponseType(typeof(project_messages))]
        public IHttpActionResult Postproject_messages(project_messages project_messages)
        {
            Queries q = new Queries();

            project_messages.project_pid = projectsController.CurrentProjectId;
            
            project_messages.employee_eid = q.GetUserId();
            project_messages.messagetimestamp = DateTime.Now;
            
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            

            db.project_messages.Add(project_messages);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = project_messages.pmid }, project_messages);
        }

        //// DELETE: api/addproject_message/5
        //[ResponseType(typeof(project_messages))]
        //public IHttpActionResult Deleteproject_messages(int id)
        //{
        //    project_messages project_messages = db.project_messages.Find(id);
        //    if (project_messages == null)
        //    {
        //        return NotFound();
        //    }

        //    db.project_messages.Remove(project_messages);
        //    db.SaveChanges();

        //    return Ok(project_messages);
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

        //private bool project_messagesExists(int id)
        //{
        //    return db.project_messages.Count(e => e.pmid == id) > 0;
        //}
    }
}