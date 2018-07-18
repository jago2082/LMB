using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMB.Models
{
    public class InspectionBasicRegistryValue
    {
        [Key]
        public int IdInspectionBV { get; set; }
        public Nullable<int> IdInspection { get; set; }
        public Nullable<int> idInspBasic { get; set; }
        public string Value { get; set; }

        public virtual InspectionBasicRegistry InspectionBasicRegistries { get; set; }

    }
}
