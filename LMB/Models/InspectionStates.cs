using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LMB.Models
{
    public class InspectionStates
    {
        [Key]
        public int IdInspectionStates { get; set; }

        [Display(Name ="State")]
        public string Description { get; set; }

        public virtual ICollection<InspectionDaily> InspectionDailys { get; set; }
    }
}