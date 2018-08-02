using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LMB.Models
{
    public class BridgeSummaryData
    {
        [Key]
        public int IdBSData { get; set; }
        public int IdInspection { get; set; }
        public string InvGross { get; set; }
        public string InvTandem { get; set; }
        public string InvAxle { get; set; }
        public string InvSign { get; set; }
        public string OpGross { get; set; }
        public string OpTandem { get; set; }
        public string OpAxle { get; set; }
        public string OpSign { get; set; }
        public string PrevR122bT { get; set; }
        public string PrevR122cT { get; set; }
        public string PrevR124Tb { get; set; }
        public string PrevNone { get; set; }
        public string PrevGross { get; set; }
        public string PrevTandem { get; set; }
        public string PrevAxle { get; set; }
        public string ObsR122bT { get; set; }
        public string ObsR122cT { get; set; }
        public string ObsR124Tb { get; set; }
        public string ObsNone { get; set; }
        public string ObsGross { get; set; }
        public string ObsTandem { get; set; }
        public string ObsAxle { get; set; }
        public string OtherDesc { get; set; }
        public string MatR122bT { get; set; }
        public string MatR122cT { get; set; }
        public string MatR124Tb { get; set; }
        public string MatW125 { get; set; }
        public string MatPosts { get; set; }
        public string MatHardware { get; set; }

        public string MatDecals { get; set; }
        public string SignCode { get; set; }
        public string CondCode { get; set; }
        public string MaintNeed { get; set; }
    }
}