using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMB.Models
{
    public class HSEQuestion
    {
        [Key]
        public int IDQuestion { get; set; }
        public Nullable<int> IDTypeInspection { get; set; }
        public Nullable<int> IdClient { get; set; }
        public Nullable<int> IdProject { get; set; }
        public string Question { get; set; }
        public int Active { get; set; }
        public Nullable<int> Sequence { get; set; }
    }
}
