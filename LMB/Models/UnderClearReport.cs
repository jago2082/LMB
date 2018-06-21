using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LMB.Models
{
    public class UnderClearReport
    {

        public InspectionDaily InspectionDaily { get; set; }

        public string image { get; set; }

        public Configuration Configuration { get; set; }
        public Reports Reports { get; set; }
        public UserDB Usuario { get; set; }

        public List<UnderClearValues> UnderClearValuesFeat { get; set; }
        public List<UnderClearValues> UnderClearValuesPSN { get; set; }
        
        public ICollection<UnderClearValues> UnderClearValues { get; set; }


    }
}