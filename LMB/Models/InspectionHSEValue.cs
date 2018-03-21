using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMB.Models
{
    public class InspectionHSEValue
    {
        [Key]
        public int IdIHSEV { get; set; }
        public Nullable<int> IDHSEInspection { get; set; }
        public Nullable<int> IdInspection { get; set; }
        public Nullable<int> IdHSEQuestion { get; set; }
        public Nullable<int> Value { get; set; }
        
    }
}
