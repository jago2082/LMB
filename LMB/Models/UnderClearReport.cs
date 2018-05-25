using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LMB.Models
{
    public class UnderClearReport
    {

        public InspectionDaily InspectionDaily { get; set; }

        public string image { get; set; }

        public ICollection<UnderClearValues> UnderClearValues { get; set; }


    }
}