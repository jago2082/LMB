using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMB.Models
{
    public class RegistrySerial
    {
        [Key]
        public int IdRegSerial { get; set; }
        public int IdInspection { get; set; }
        public string StatusReference { get; set; }
        public string Reference { get; set; }
        public string Serial { get; set; }
        public string Observation { get; set; }
    }
}
