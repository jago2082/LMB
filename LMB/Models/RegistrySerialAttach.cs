using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMB.Models
{
    public class RegistrySerialAttach
    {
        [Key]
        public int IdRegistrySerialAttach { get; set; }
        public int IdInspection { get; set; }
        public int IdRegistSerial { get; set; }
        public string ImageString { get; set; }
    }
}
