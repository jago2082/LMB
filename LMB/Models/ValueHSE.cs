using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMB.Models
{
    public class ValueHSE
    {
        [Key]
        public int IDValueHSE { get; set; }
        public int IDQuestion { get; set; }
        public int IdProject { get; set; }
        public Nullable<int> IdInspection { get; set; }
        public Nullable<int> Value { get; set; }
        public Nullable<System.DateTime> DateHSEQuestion { get; set; }
        public string Comment { get; set; }
    }
}
