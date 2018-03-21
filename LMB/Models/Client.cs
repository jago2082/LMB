using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMB.Models
{
    public class Client
    {
        [Key]
        public int IdClient { get; set; }
        public string LogoPicture { get; set; }
        public string NameClient { get; set; }
        public Nullable<int> ByProject { get; set; }
        public Nullable<int> Active { get; set; }

    }
}
