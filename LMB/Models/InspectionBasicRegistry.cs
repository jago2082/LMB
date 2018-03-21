using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMB.Models
{
    public class InspectionBasicRegistry
    {
        [Key]
        public int IdInspBasic { get; set; }
        public Nullable<int> IdProject { get; set; }
        public Nullable<int> IdClient { get; set; }
        public Nullable<int> TypeInspection { get; set; }
        public string NameQuestion { get; set; }
        public string Placeholder { get; set; }
        public Nullable<int> TypeFunction { get; set; }
        public Nullable<int> IsRequired { get; set; }
        public Nullable<int> IsCopied { get; set; }
    }
}
