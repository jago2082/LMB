using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LMB.Models
{
    public class Pdf
    {
        [Key]
        public int idPDF { get; set; }

        public InspectionDaily InspectionDaily { get; set; }

        public Insp_Type_Attach Insp_Type_Attach { get; set; }
    }
}