using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMB.Models
{
    public class CheckListProject
    {
        [Key]
        public int IdCheckList { get; set; }
        public Nullable<int> IdTypeInspection { get; set; }
        public int IdClient { get; set; }
        public int IdProject { get; set; }
        public string Name { get; set; }
        public int Type { get; set; }
        public Nullable<int> Active { get; set; }

        [JsonIgnore]
        public virtual TypeInspection TypeInspection { get; set; }
        [JsonIgnore]
        public virtual ICollection<CheckListSection> CheckListSections { get; set; }
    }
}
