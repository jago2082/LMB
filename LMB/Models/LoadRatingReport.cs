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

        public ICollection<ValueCheckList> ValuesCheclist { get; set; }
    }
}