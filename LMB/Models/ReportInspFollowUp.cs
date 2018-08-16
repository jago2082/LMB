using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LMB.Models
{
    public class ReportInspFollowUp
    {
        public Configuration Configuration { get; set; }
        public InspectionDaily InspectionDaily { get; set; }
        public Reports Reports { get; set; }
        public UserDB Usuario { get; set; }
        public ICollection<BridgeInspectionFollowUp> BridgeInspectionFollowUps { get; set; }
        public FollowUpOther FollowUpOther { get; set; }
        public ICollection<NoveltyInspection> NoveltyInspection { get; set; }
        public string ComentGeneral { get; set; }
        public string Dato1 { get; set; }
        public string Dato2 { get; set; }

        public int accion { get; set; }

    }
}