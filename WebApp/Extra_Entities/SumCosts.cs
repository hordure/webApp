using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Extra_Entities
{
    public class SumCosts
    {
        public int TotalCosts { get; set; }

        public SumCosts ( int sum)
        {
            this.TotalCosts = sum;
        }

        public SumCosts() { }
    }
}