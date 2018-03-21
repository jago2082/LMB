using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMB.Models
{
    public class NombreCampos
    {
        [Key]
        public int IdField { get; set; }
        public string NameField { get; set; }
    }
}
