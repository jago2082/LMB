using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LMB.Models
{
    public class UnderClearValues
    {
        [Key]
        public int IdUndCValue { get; set; }
        public int IdInspection { get; set; }
        public string FeatureXed { get; set; }
        public string PSN { get; set; }
        public string FieldDataRLC { get; set; }
        public int RefFeRLC { get; set; }
        public int ItemRLC { get; set; }
        public string FieldDataLLC { get; set; }
        public int RefFeLLC { get; set; }
        public int ItemLLC { get; set; }
        public string FieldDataTHC { get; set; }
        public int RefFeTHC { get; set; }
        public int ItemTHC { get; set; }
        public string FieldDataMPV { get; set; }
        public int RefFeMPV { get; set; }
        public int ItemMPV { get; set; }
        public string FieldDataMMV { get; set; }
        public int RefFeMMV { get; set; }
        public int ItemMMV { get; set; }
        public string FieldDataSVC { get; set; }
        public int RefFeSVC { get; set; }
        public int ItemSVC { get; set; }

        public int RefFeRLCTo { get; set; }
        public int RefFeLLCTo { get; set; }
        public int RefFeTHCTo { get; set; }
        public int RefFeMPVTo { get; set; }
        public int RefFeMMVTo { get; set; }
        public int RefFeSVCTo { get; set; }
    }
}