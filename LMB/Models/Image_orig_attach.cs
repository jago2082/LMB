using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LMB.Models
{
    public class Image_orig_attach
    {
        [Key]
        public int IdImageOriAttach { get; set; }
        public int? IDAttach { get; set; }

        public int? TypeData { get; set; }
        public Nullable<int> IDInspection { get; set; }
        public Nullable<int> IDTypePicture { get; set; }

        public TypePicture TypePicture { get; set; }

        [DataType(DataType.ImageUrl)]
        [Display(Name = "Image")]
        public string ImageString { get; set; }

        [NotMapped]
        public HttpPostedFileBase LogoFile { get; set; }

        [NotMapped]
        public string numinspection { get; set; }

        public string Caption { get; set; }

        public int? IdDirectionPhotoType { get; set; }

        public DirectionPhotoType DirectionPhotoType { get; set; }

        public string Comment { get; set; }

        [Display(Name = "Photo Camera No.")]
        public string PhotoCameraNum { get; set; }

        public virtual ICollection<InspectionDaily> InspectionDailys { get; set; }

    }
}