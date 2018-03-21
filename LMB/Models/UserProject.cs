using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMB.Models
{
    public class UserProject
    {
        [Key]
        public int IdUser { get; set; }
        public int IdClient { get; set; }
        public int IdProject { get; set; }
        public Nullable<int> IsActive { get; set; }
        public int IdProjectUser { get; set; }
    }
}
