using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMB.Models
{
    public class InspectionDaily
    {
        [Key]
        public int IdInspection { get; set; }
        public int IDUser { get; set; }
        public Nullable<int> IdClient { get; set; }
        public Nullable<int> IdProject { get; set; }
        [StringLength(60)]
        [Index("InspectionDailyNumInspectionIndex",  IsUnique = true)]
        [Display(Name ="Bridge No.")]
        public string NumInspection { get; set; }

        [Display(Name = "District")]
        public string DO { get; set; }

        [Display(Name = "County")]
        public string Company { get; set; }

        public int Control { get; set; }

        public string Section { get; set; }
        [Display(Name = "Location")]
        public string Address { get; set; }

        [Display(Name = "7 Fac Carried")]
        public string City { get; set; }
        public Nullable<int> TypeInspection { get; set; }
        public string Scope { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public string Hour { get; set; }
        public Nullable<int> IdValueCheckList { get; set; }
        public Nullable<int> Status { get; set; }

        public Nullable<double> Longitude { get; set; }
        public Nullable<double> Latitude { get; set; }
        public Nullable<double> LongitudeIni { get; set; }
        public Nullable<double> LatitudeIni { get; set; }
        public string DateInspection { get; set; }
        public string CommentGeneral { get; set; }
        public Nullable<int> IdAttach { get; set; }
        public string Sync { get; set; }
        public Nullable<double> LongitudeEnd { get; set; }
        public Nullable<double> LatitudeEnd { get; set; }
        public string DateInspectionEnd { get; set; }



    }
}
