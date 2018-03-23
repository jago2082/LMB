using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LMB.Models
{
    public class UnderClearanceRecord
    {
        [Key]
        public int IdUnderClearanceRecord { get; set; }

        public int IdInspection { get; set; }
        public string Feadturexed { get; set; }

        public string PSN { get; set; }

        public int IdPosition { get; set; }

        public string FieldData { get; set; }

        public int IdRefFeature { get; set; }

        public int IdItem { get; set; }
    }
}