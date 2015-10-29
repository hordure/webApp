using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApp.Models;

namespace WebApp.Extra_Entities
{
    public class phoursWEmp : project_hours
    {
        public string employeeName { get; set; }
        public string projectTitle { get; set; }
    }
}