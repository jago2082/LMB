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
        public int IdStatus { get; set; }

        [Display(Name ="Status")]
        public string Description { get; set; }

        public virtual ICollection<InspectionDaily> InspectionDailys { get; set; }
    }
}