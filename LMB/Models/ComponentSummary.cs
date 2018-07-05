using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LMB.Models
{
    public class ComponentSummary
    {
        [Key]
        public int IdComponentSummary { get; set; }

        public int IdInspection { get; set; }
        public string Description { get; set; }

        public int InspectionRaitingType { get; set; }

        public string InvRatingH { get; set; }
        
        public string InvRatingHS { get; set; }
        public string OpRatingH { get; set; }
        public string OpRatingHS { get; set; }

        public string CSJ { get; set; }

        public string Loadof { get; set; }

        public Boolean ALRS { get; set; }

        public Boolean ASLRS { get; set; }

        public Boolean LRCS { get; set; }
        public string Item66 { get; set; }
        public string Item64 { get; set; }

        public InspectionRaiting InspectionRaiting { get; set; }
    }
}