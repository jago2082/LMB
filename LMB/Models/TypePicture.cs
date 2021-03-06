﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMB.Models
{
    public class TypePicture
    {
        [Key]
        public int IdTypePicture { get; set; }
        public string Description { get; set; }

        public int IdProject { get; set; }

        public virtual ICollection<Insp_Type_Attach> Insp_Type_Attach { get; set; }
    }
}
