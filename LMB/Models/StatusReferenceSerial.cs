using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMB.Models
{
    public class StatusReferenceSerial
    {
        [Key]
        public int IdStatusReference { get; set; }
        public string StatusReference { get; set; }
        public Nullable<int> IdBodega { get; set; }
        public Nullable<bool> IsActive { get; set; }
    }
}
