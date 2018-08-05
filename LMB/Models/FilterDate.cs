using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LMB.Models
{
    public class FilterDate
    {
        [Key]
        public int IdFilterDate { get; set; }
        [Display(Name = "initial Date")]
        [DataType(DataType.DateTime)]
        public string dateini { get; set; }
        [Display(Name = "final Date")]
        [DataType(DataType.DateTime)]
        public string datefin { get; set; }
        [Display(Name = "User")]
        public int? IDUser { get; set; }
        public virtual UserDB UserDBs { get; set; }
    }
}