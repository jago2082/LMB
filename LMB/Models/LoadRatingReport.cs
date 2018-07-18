using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LMB.Models
{
    public class LoadRatingReport
    {
        [Key]
        public int IdLoadRating { get; set; }
        public InspectionDaily InspectionDaily { get; set; }

        public Configuration Configuration { get; set; }

        public ComponentSummary ComponentSummary { get; set; }

        public Reports Reports { get; set; }

        public string Item58 { get; set; }
        public string Item59 { get; set; }
        public string Item60 { get; set; }
        public string Item62 { get; set; }

        public UserDB User { get; set; }


    }
}