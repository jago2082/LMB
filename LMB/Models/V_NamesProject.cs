using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMB.Models
{
    public class V_NamesProject
    {
        [Key]
        public int IdProject { get; set; }
        public string NameProject { get; set; }
        public int IdClient { get; set; }
        public Nullable<int> Active { get; set; }
        public Nullable<int> Status { get; set; }
        public Nullable<int> TypeProject { get; set; }
        public int IdUser { get; set; }
    }
}
