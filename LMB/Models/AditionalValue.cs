using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LMB.Models
{
    public class AditionalValue
    {
         
        [Key]
        public int IdAditionalValue { get; set; }
        public string Dato1 { get; set; }
        public string Dato2 { get; set; }
        public int VDato1 { get; set; }
        public int VDato2 { get; set; }

    }
}