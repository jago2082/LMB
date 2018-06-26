using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LMB.Models
{
    public class LoadRatingReport
    {

        [Key]
        public int IdLoadRating { get; set; }

        public string Descripcion { get; set; }
        public InspectionDaily InspectionDaily { get; set; }

        public string CSJ { get; set; }

        public string Loadof { get; set; }

        public string ALRS { get; set; }

        public string ASLRS { get; set; }

        public string LRCS { get; set; }
        public ICollection<CheckListSection> CheckListSections { get; set; }

        public Configuration Configuration { get; set; }

        public Reports Reports { get; set; }

        public string Item58 { get; set; }
        public string Item59 { get; set; }
        public string Item60 { get; set; }
        public string Item62 { get; set; }
        public string Item66 { get; set; }
        public string Item64 { get; set; }
        public ICollection<ValueCheckList> ValuesCheclist { get; set; }

        public UserDB User { get; set; }


    }
}