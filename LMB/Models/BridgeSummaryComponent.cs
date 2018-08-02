using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LMB.Models
{
    public class BridgeSummaryComponent
    {
        [Key]
        public int IdBScomponent { get; set; }
        public int IdInspection { get; set; }
        public int IdRating { get; set; }
        public string InvH { get; set; }
        public string InvHS { get; set; }
        public string OpH { get; set; }
        public string OpHS { get; set; }
    }

}

