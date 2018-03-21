using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMB.Models
{
    public class CheckListQuestion
    {
        [Key]
        public int IdCheckListQuestion { get; set; }
        public Nullable<int> IdProject { get; set; }
        public Nullable<int> IdClient { get; set; }
        public Nullable<int> IdCheckList { get; set; }
        public int IDQuestion { get; set; }
        public Nullable<int> IdCheckListSection { get; set; }
        public string Question { get; set; }
        public Nullable<int> IDTypeFuncionality { get; set; }
        public Nullable<int> Sequence { get; set; }
        public Nullable<int> Active { get; set; }
    }
}
