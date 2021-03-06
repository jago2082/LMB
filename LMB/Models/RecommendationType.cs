﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LMB.Models
{
    public class RecommendationType
    {
        [Key]
        public int IdRecommendationType  { get; set; }
        public string idvalue { get; set; }

        [Display(Name = "Recommendation Type")]
        public string Description { get; set; }

        public virtual ICollection<BridgeInspectionFollowUp> BridgeInspectionFollowUps { get; set; }
    }
}