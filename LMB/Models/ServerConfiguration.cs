using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMB.Models
{
    public class ServerConfiguration
    {
        [Key]
        public int IdConfiguration { get; set; }
        public string IPServidor { get; set; }
        public string Manual { get; set; }
        public string AccentColor { get; set; }
        public string TextColor { get; set; }
        public string BackGround { get; set; }
        public string emailAdmin { get; set; }
    }
}
