using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMB.Models
{
    public class Inspection
    {
        [Key]
        public int ID { get; set; }
        public DateTime InspDate { get; set; }
        public int IdClient { get; set; }
        public int IdProject { get; set; }
        public string Comment { get; set; }
        public Nullable<int> Value { get; set; }
        public string UserName { get; set; }
        public Nullable<int> IdCkeclist { get; set; }
        public Nullable<int> Sync { get; set; }
        public Nullable<decimal> coodX { get; set; }
        public Nullable<decimal> coodY { get; set; }
    }
}
