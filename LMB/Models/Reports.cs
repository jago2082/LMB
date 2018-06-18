using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LMB.Models
{
    public class Reports
    {
        [Key]
        public int IdReports { get; set; }

        public string Title { get; set; }

        public string FormName { get; set; }

        public string Revision { get; set; }

        public string TeamLeader { get; set; }

        public string Engineerofrecord { get; set; }

        public string FirmN { get; set; }
    }
}