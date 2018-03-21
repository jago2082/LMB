using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMB.Models
{
    public class TypeInspectionProject
    {
        [Key]
        public int IdTypeInspectionProject { get; set; }
        public int IDProject { get; set; }
        public int idTypeInspection { get; set; }
        public string Description { get; set; }
    }
}
