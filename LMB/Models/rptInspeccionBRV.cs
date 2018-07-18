using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LMB.Models
{
    public class rptInspeccionBRV
    {
        public ICollection<InspectionBasicRegistryValue> InspectionBasicRegistryValues { get; set; }

        public InspectionBasicRegistry InspectionBasicRegistries { get; set; }
    }
}