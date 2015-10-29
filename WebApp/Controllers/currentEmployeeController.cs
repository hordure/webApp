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
   



    public class currentEmployeeController : ApiController
    {
        private Queries q = new Queries();


        public IHttpActionResult Getemployee()
        {
            thisEmp e = new thisEmp();

            e = q.GetCurrentEmployee();

            return Ok(e);
        }

  
    }
}