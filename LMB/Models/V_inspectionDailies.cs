﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMB.Models
{
    public class V_inspectionDailies
    {
        [Key]
        public int IdInspection { get; set; }
        public int IDUser { get; set; }
        public Nullable<int> IdClient { get; set; }
        public Nullable<int> IdProject { get; set; }
        public string NumInspection { get; set; }
        public string DO { get; set; }
        public string Company { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Image { get; set; }
        public string Scope { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public string Hour { get; set; }
        public Nullable<int> IdValueCheckList { get; set; }
        public Nullable<int> Status { get; set; }
        public Nullable<double> Longitude { get; set; }
        public Nullable<double> Latitude { get; set; }
        public string DateInspection { get; set; }
        public string CommentGeneral { get; set; }
        public Nullable<int> IdAttach { get; set; }
        public string Sync { get; set; }
        public Nullable<int> TypeInspection { get; set; }
        public string Description { get; set; }
    }
}
