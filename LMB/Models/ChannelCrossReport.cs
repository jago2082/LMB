using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LMB.Models
{
    public class ChannelCrossReport
    {

        public InspectionDaily InspectionDaily { get; set; }

        public Configuration Configuration { get; set; }
        
        public Reports Reports { get; set; }
        public UserDB Usuario { get; set; }
        public ICollection<CrossSectionValues> CrossSectionValues { get; set; }


    }
}