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

        public string Description { get; set; }

        public int IdReferenceFeatureType { get; set; }

        public int IdRecommendationType { get; set; }

        public int InspectionRaitingType { get; set; }

        
        public ReferenceFeatureType ReferenceFeatureType { get; set; }

        public RecommendationType RecommendationType { get; set; }

        public InspectionRaiting InspectionRaiting { get; set; }

        public int IdInspection { get; set; }

    }
}