using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMB.Models
{
    public class ValueCheckList
    {
        [Key]
        public int IdValueCheckList { get; set; }
        public string Sync { get; set; }
        public string IdUser { get; set; }
        public string DateCheckList { get; set; }
        public Nullable<int> IdChecklistQuestion { get; set; }
        public Nullable<int> IdInspection { get; set; }
        public Nullable<int> IdCheckList { get; set; }
        public Nullable<int> RowIDQuestion { get; set; }
        public string Comment { get; set; }
        public Nullable<int> Value { get; set; }
    }
}
