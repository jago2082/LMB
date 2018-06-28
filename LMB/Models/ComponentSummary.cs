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

        public int InspeRating { get; set; }

        public string InvRatingH { get; set; }
        
        public string InvRatingHS { get; set; }
        public string OpRatingH { get; set; }
        public string OpRatingHS { get; set; }

        public InspectionRaiting InspectionRaiting { get; set; }
    }
}