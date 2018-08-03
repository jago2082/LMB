using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LMB.Models
{
    public class FollowUpOptional
    {
        [Key]
        public int IdFUOpt { get; set; }
        public int IdInspection { get; set; }
        public string Data1 { get; set; }
        public string Data2 { get; set; }
    }
}