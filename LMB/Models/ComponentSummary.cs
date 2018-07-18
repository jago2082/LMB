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

        /*  public int InspectionRaitingType { get; set; }

        public string InvRatingH { get; set; }
        
        public string InvRatingHS { get; set; }
        public string OpRatingH { get; set; }
        public string OpRatingHS { get; set; }*/

        public string CSJ { get; set; }

        [Display(Name = "design load of")]
        public string Loadof { get; set; }

        [Display(Name = "Assigned Load Rating Statement")]
        
        public Boolean ALRS { get; set; }
        [Display(Name = "Assumed Load Rating Statement")]
        public Boolean ASLRS { get; set; }
        [Display(Name = "Load Rating Concurrence Statement")]
        public Boolean LRCS { get; set; }
        [Display(Name = "Item 66")]
        public string Item66 { get; set; }
        [Display(Name = "Item 64")]
        public string Item64 { get; set; }

        public InspectionRaiting InspectionRaiting { get; set; }
    }
}