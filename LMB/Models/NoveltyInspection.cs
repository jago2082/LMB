using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMB.Models
{
    public class NoveltyInspection
    {
        [Key]
        public int IdNovelty { get; set; }
        public Nullable<int> IdInspection { get; set; }
        public Nullable<int> IdTypeNovelty { get; set; }
        public string Novelty { get; set; }
    }
}
