using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LMB.Models
{
    public class FileLoad
    {
        public int type { get; set; }
        public HttpPostedFileBase file { get; set; }
    }
}