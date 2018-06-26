using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LMB.Models
{
    public class FollowUpOther
    {
        [Key]
        public int IdFollowUpOther { get; set; }

        public int IdBridgeInspectionFollowUp { get; set; }

        public string Descriptiongeneral { get; set; }

        public string Owner { get; set; }

        public string ComentsMantenimiento { get; set; }

        public string Supervisor { get; set; }

        public DateTime DateComment { get; set; }

        public string DescriptionFoll { get; set; }

        public DateTime Datefoll { get; set; }

        public string CheckFoll { get; set; }

        public UserDB User { get; set; }

        public DateTime date { get; set; }

        public BridgeInspectionFollowUp bridgeInspectionFollowUp { get; set; }
    }
}