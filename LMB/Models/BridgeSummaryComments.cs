using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LMB.Models
{
    public class BridgeSummaryComments
    {
        [Key]
        public int IdBSComment { get; set; }
        public int IdInspection { get; set; }
        public string Comment { get; set; }
    }
}