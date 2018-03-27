using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LMB.Models
{
    public class CustomInspDaily
    {
        public IEnumerable<InspectionDaily> IEInspectionDaily { get; set; }

        public InspectionDaily InspectionDaily { get; set; }
    }
}