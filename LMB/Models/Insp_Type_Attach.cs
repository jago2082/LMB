using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMB.Models
{
    public class Insp_Type_Attach
    {
        [Key]
        public int IDAttach { get; set; }
        public Nullable<int> IDInspection { get; set; }
        public Nullable<int> IDTypePicture { get; set; }
        public string ImageString { get; set; }
    }
}
