using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LMB.Models
{
    public class ReferenceFeatureUnderType
    {
        [Key]
        public int IdReferenceFeatureType { get; set; }

        public string Description { get; set; }

        public string Value { get; set; }
    }
}