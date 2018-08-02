using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LMB.Models
{
    public class BridgeInspectionFollowUp
    {
        [Key]
        public int IdBridgeInspectionFollowUp { get; set; }
        [Display(Name = "Action/Comments")]
        public string Description { get; set; }

        [Display(Name = "Reference Features")]
        public int IdReferenceFeatureType { get; set; }
        [Display(Name = "Recomendation Type")]
        public int IdRecommendationType { get; set; }
        [Display(Name = "1085 Ratings")]
        public int InspectionRaitingType { get; set; }

        
        public ReferenceFeatureType ReferenceFeatureType { get; set; }

        public RecommendationType RecommendationType { get; set; }

        public InspectionRaiting InspectionRaiting { get; set; }

        public int IdInspection { get; set; }

        [Display(Name ="Owner")]
        public string InspectionOwner  { get; set; }

        public string InspectionDescription { get; set; }

    }
}