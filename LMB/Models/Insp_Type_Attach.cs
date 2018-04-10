using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMB.Models
{
    public class Insp_Type_Attach
    {
        [Key]
        public int IDAttach { get; set; }
        public Nullable<int> IDInspection { get; set; }
        public Nullable<int> IDTypePicture { get; set; }

        public TypePicture TypePicture { get; set; }
        public string ImageString { get; set; }

        public string Caption { get; set; }

        public int IdDirectionPhotoType { get; set; }

        public DirectionPhotoType DirectionPhotoType { get; set; }

        public string Comment { get; set; }

        public string PhotoCameraNum { get; set; }

        public virtual ICollection<InspectionDaily> InspectionDailys { get; set; }
    }
}
