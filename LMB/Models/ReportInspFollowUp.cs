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
    }
}