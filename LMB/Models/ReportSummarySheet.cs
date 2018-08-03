using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LMB.Models
{
    public class ReportSummarySheet
    {
        public Configuration Configuration { get; set; }
        public InspectionDaily InspectionDaily { get; set; }
        public Reports Reports { get; set; }
        public UserDB Usuario { get; set; }

       public ICollection<BridgeSummaryComponent> BridgeSummaryComponent { get; set; }
       public ICollection<BridgeSummaryComments> BridgeSummaryComments { get; set; }

       public BridgeSummaryData BridgeSummaryData { get; set; }
    }
}