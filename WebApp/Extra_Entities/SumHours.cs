using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Extra_Entities
{
    public class SumHours
    {
        public decimal TotalHours { get; set; }

        public SumHours (decimal totalHours)
        {
            this.TotalHours = totalHours;
        }

        public SumHours()
        {

        }
    }
}