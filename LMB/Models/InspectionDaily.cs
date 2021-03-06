﻿using System;
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

        [Display(Name = "User")]
        public int IDUser { get; set; }
       
        public Nullable<int> IdClient { get; set; }
        public Nullable<int> IdProject { get; set; }
        [StringLength(60)]
        [Index("InspectionDailyNumInspectionIndex",  IsUnique = true)]
        [Display(Name ="Bridge No.          ")]
        public string NumInspection { get; set; }

        [Display(Name = "District")]
        public string DO { get; set; }

        [Display(Name = "County")]
        public string Company { get; set; }

        public string Control { get; set; }

        public string Section { get; set; }
        [Display(Name = "Location")]
        public string Address { get; set; }

        [Display(Name = "Route")]
        public string City { get; set; }
        public Nullable<int> TypeInspection { get; set; }
        [Display(Name = "Feature Crossed")]
        public string Scope { get; set; }
        [Display(Name = "Date Inspection")]
        public Nullable<System.DateTime> Date { get; set; }
        [Display(Name = "Date Build")]
        public string Hour { get; set; }
        public Nullable<int> IdValueCheckList { get; set; }
        public Nullable<int> IdStatus { get; set; }
        public Nullable<double> Longitude { get; set; }
        public Nullable<double> Latitude { get; set; }
        [Display(Name = "Longitude")]
        public Nullable<double> LongitudeIni { get; set; }
        [Display(Name = "Latitude")]
        public Nullable<double> LatitudeIni { get; set; }
        [Display(Name = "Date Assigned")]
        public string DateInspection { get; set; }
        public string CommentGeneral { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdAttach { get; set; }

        public Insp_Type_Attach Insp_Type_Attach { get; set; }
        public string Sync { get; set; }
        public Nullable<double> LongitudeEnd { get; set; }
        public Nullable<double> LatitudeEnd { get; set; }
        public string DateInspectionEnd { get; set; }

        public int? Flag { get; set; }

        public string Structure { get; set; }

        public string MaintanSection { get; set; }

        public string Milepnt { get; set; }

        public string Owner { get; set; }

        public InspectionStates InspectionState { get; set; }

        public UserDB UserDBs { get; set; }

        public Counties Counties { get; set; }

        public District District { get; set; }

    }
}
