using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LMB.Models
{
    public class CrossSectionValues
    {
        [Key]
        public int IdCrossSecValue { get; set; }

        public int IdInspection { get; set; }

        public string Bendt { get; set; }

        public string Notes { get; set; }

        public float TotalHorDistance { get; set; }

        public DateTime Date { get; set; }

        public Boolean Upstream { get; set; }

        public Boolean Downstream { get; set; }

        public float DistanLastBent { get; set; }

        public int IDTopRef { get; set; }

        public int IDBottonRef { get; set; }

        public float VertDistance { get; set; }
    }
}