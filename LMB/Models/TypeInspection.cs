using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMB.Models
{
    public class TypeInspection
    {
        [Key]
        public int IdTypeInspection { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public bool Active { get; set; }
    }
}
