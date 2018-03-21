using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMB.Models
{
    public class V_InspecionCount
    {
        [Key]
        public int IdInspectionDetailcount { get; set; }
        public string NumInspection { get; set; }
        public string Referencia { get; set; }
        public Nullable<int> CantidadReportada { get; set; }
        public Nullable<int> CantidadEncontrada { get; set; }
        public string Observacion { get; set; }
        public Nullable<int> Status { get; set; }
    }
}
