using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Extra_Entities
{
    public class tempEmp
    {
        public int peid { get; set; }
        public int eid { get; set; }
        public string name { get; set; }
        public string profession { get; set; }
        
    }

    public class empComparer : IEqualityComparer<tempEmp>
    {
        public bool Equals(tempEmp x, tempEmp y)
        {
            if (x.eid == y.eid)
                return true;

            return false;

        }

        public int GetHashCode(tempEmp obj)
        {
            return obj.GetHashCode();
        }
    }
}