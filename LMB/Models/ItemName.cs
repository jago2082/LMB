using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LMB.Models
{
    public class ItemName
    {
        [Key]
        public int IdItemName { get; set; }

        public string description { get; set; }
    }
}