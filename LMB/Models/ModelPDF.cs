﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LMB.Models
{
    public class ModelPDF
    {
        public string ImageString { get; set; }

        public string Description { get; set; }

        public string PTDescription { get; set; }

        public string Company { get; set; }

        public string NumInspection { get; set; }
        public string DateInspectionEnd { get; set; }
    }
}