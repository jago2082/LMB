using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LMB.Models
{
    public class ReportUnderClear
    {
        [Key]
        public int IdUnderClearReport { get; set; }
        public IEnumerable<InspectionDaily> IEInspectionDaily { get; set; }

        public List<UnderClearValues> UnderClearValues { get; set; }
    }
}