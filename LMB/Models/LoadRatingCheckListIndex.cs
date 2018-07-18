using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LMB.Models
{
    public class LoadRatingCheckListIndex
    {

        public InspectionDaily InspectionDaily { get; set; }

        public ICollection<Insp_Question_Attach> Insp_Question_Attach { get; set; }

        public CheckListQuestion CheckListQuestion { get; set; }

   
        public string Appraisal { get; set; }
        public string Misce { get; set; }


    }
}