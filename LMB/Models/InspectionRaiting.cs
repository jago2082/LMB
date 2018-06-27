using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LMB.Models
{
    public class InspectionRaiting
    {
        [Key]
        public int InspectionRaitingType  { get; set; }

        [Display(Name = "Inspection Raiting")]
        public string Description { get; set; }

        public string Value { get; set; }

        public virtual ICollection<BridgeInspectionFollowUp> BridgeInspectionFollowUps { get; set; }

        public virtual ICollection<ComponentSummary> ComponentSummary { get; set; }
    }
}