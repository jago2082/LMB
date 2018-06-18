using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LMB.Models
{
    public class ConfigurationApp
    {
        public Configuration configuration { get; set; }
        public ICollection<Reports> reports { get; set; }
    }
}