using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMB.Models
{
    public class CamposClient
    {
        [Key]
        public int IdField { get; set; }
        public int IdClient { get; set; }
        public int IdProject { get; set; }
        public Nullable<int> Active { get; set; }
        public Nullable<int> Sequence { get; set; }
    }
}
