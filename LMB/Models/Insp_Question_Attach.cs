using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMB.Models
{
    public class Insp_Question_Attach
    {
        [Key]
        public int IDAttachQuestion { get; set; }
        public Nullable<int> IDValueChecklist { get; set; }
        public string ImagenString { get; set; }
        public int IdIQAtt { get; set; }
        public string Comment { get; set; }
        public string Medida { get; set; }
    }
}
