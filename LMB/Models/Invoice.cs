using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMB.Models
{
    public class Invoice
    {
        public Configuration Configuration { get; set; }
        public virtual ICollection<InspectionDaily> InspectionDaily { get; set; }
        public UserDB Usuario { get; set; }

        public int IdInspection { get; set; }

        public int TotalA { get; set; }

        public int TotalB { get; set; }

        public DateTime InitialDate { get; set; }
        public DateTime FinalDate { get; set; }
        public int TotalAA { get; set; }
        public int TotalAB { get; set; }
        public int TotalAC { get; set; }
        public int TotalAD { get; set; }
        public int TotalAE { get; set; }
        public int TotalAF { get; set; }
        public int TotalAG { get; set; }
        public int TotalAH { get; set; }
        public int TotalAX { get; set; }

        public int TotalBA { get; set; }
        public int TotalBB { get; set; }
        public int TotalBC { get; set; }
        public int TotalBD { get; set; }
        public int TotalBE { get; set; }
        public int TotalBF { get; set; }
        public int TotalBG { get; set; }
        public int TotalBH { get; set; }
        public int TotalBX { get; set; }

    }
}
