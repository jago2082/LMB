using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LMB.Models
{
    public class DirectionPhotoType
    {
        [Key]
        public int IdDirectionPhotoType { get; set; }

        public string Description { get; set; }
    }
}