using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LMB.Models
{
    public class District
    {
        [Key]
        public int IdDistrict { get; set; }

        public string COD { get; set; }

        public string ABBR { get; set; }

        public string NAME { get; set; }
    }
}