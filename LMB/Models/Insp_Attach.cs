using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMB.Models
{
    public class Insp_Attach
    {
        [Key]
        public int IDAttach { get; set; }
        public int IDInspection { get; set; }
        public string ImageString { get; set; }

        public int IdDirectionPhoto { get; set; }

        public string PhotoCamera { get; set; }

        public string CaptionAdd { get; set; }

        public string Comment { get; set; }
    }
}
