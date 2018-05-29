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

        public string Description { get; set; }

        public string Value { get; set; }

        public virtual ICollection<BridgeInspectionFollowUp> BridgeInspectionFollowUps { get; set; }
    }
}