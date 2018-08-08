using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LMB.Models
{
    public class QuestionDetails
    {
        public InspectionDaily InspectionDaily { get; set; }

        public string Question { get; set; }

        public int? value { get; set; }


    }
}