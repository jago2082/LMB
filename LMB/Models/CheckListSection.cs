using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMB.Models
{
    public class CheckListSection
    {
        [Key]
        public int IdCheckListSection { get; set; }
        public int IdCheckList { get; set; }
        public string Name { get; set; }
        public int Sequence { get; set; }
        public Nullable<int> IdProject { get; set; }
        public Nullable<int> IdClient { get; set; }

        [JsonIgnore]
        public virtual CheckListProject CheckListProject { get; set; }
        [JsonIgnore]
        public virtual ICollection<CheckListQuestion> CheckListQuestions { get; set; }
    }
}
