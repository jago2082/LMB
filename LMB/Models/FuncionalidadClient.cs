using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMB.Models
{
    public class FuncionalidadClient
    {
        [Key]
        public int IdFuncionalidad { get; set; }
        public int IdProject { get; set; }
        public int IDTypeInspection { get; set; }
        public Nullable<bool> Active { get; set; }
        public string NameFuncionalidad { get; set; }
    }
}
