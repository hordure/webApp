using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApp.Models;

namespace WebApp.Extra_Entities
{
    /// <summary>
    /// Return project messages with employee name
    /// </summary>
    public class pmessagesWEmp : project_messages
    {
        public string employeename { get; set; }
    }
}