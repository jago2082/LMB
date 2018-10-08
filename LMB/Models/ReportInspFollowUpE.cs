using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LMB.Models
{
    public class ReportInspFollowUpE
    {
        [Key]
        public int IdReportInspFollowUpE { get; set; }
        public Configuration Configuration { get; set; }
        public InspectionDaily InspectionDaily { get; set; }
        public Reports Reports { get; set; }
        public UserDB Usuario { get; set; }
        public BridgeInspectionFollowUp BridgeInspectionFollowUp1 { get; set; }
        public BridgeInspectionFollowUp BridgeInspectionFollowUp2 { get; set; }
        public BridgeInspectionFollowUp BridgeInspectionFollowUp3 { get; set; }
        public BridgeInspectionFollowUp BridgeInspectionFollowUp4 { get; set; }
        public BridgeInspectionFollowUp BridgeInspectionFollowUp5 { get; set; }
        public BridgeInspectionFollowUp BridgeInspectionFollowUp6 { get; set; }
        public BridgeInspectionFollowUp BridgeInspectionFollowUp7 { get; set; }
        public BridgeInspectionFollowUp BridgeInspectionFollowUp8 { get; set; }
        public FollowUpOther FollowUpOther { get; set; }
        public ICollection<NoveltyInspection> NoveltyInspection { get; set; }
        public string ComentGeneral { get; set; }
        public string Dato1 { get; set; }
        public string Dato2 { get; set; }

        public int accion { get; set; }
    }
}