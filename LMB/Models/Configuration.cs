using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LMB.Models
{
    public class Configuration
    {
        [Key]
        public int IdConfiguration { get; set; }

        public string NameCompany { get; set; }

        public string Contract { get; set; }

        public string footPage { get; set; }

        public string FootPageText { get; set; }

        public string PathLogo { get; set; }

        [NotMapped]
        public HttpPostedFileBase LogoFile { get; set; }

        public string ImageSing { get; set; }

        [NotMapped]
        public HttpPostedFileBase SingFile { get; set; }

        public string ImageContract { get; set; }

        [NotMapped]
        public HttpPostedFileBase ContractFile { get; set; }
    }
}