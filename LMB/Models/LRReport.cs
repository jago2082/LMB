using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LMB.Models
{
    public class LRReport
    {
        public ConfigurationApp ConfigurationApp { get; set; }

        public LoadRatingReport LoadRatingReport { get; set; }

        public InspectionDaily InspectionDaily { get; set; }
    }
}