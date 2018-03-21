using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMB.Models
{
    public class TypeFuncionalidad
    {
        [Key]
        public int IdFuncionality { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public bool Active { get; set; }
    }
}
