using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMB.Models
{
    public class UserDB
    {
        [Key]
        public int IDUser { get; set; }

        [Required(ErrorMessage ="The field {0} is required")]
        [Display(Name = "User Name")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "The field {0} is required")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "The field {0} is required")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [DataType(DataType.EmailAddress)]
        [MaxLength(256,ErrorMessage ="The field {0} must be maximun {1} characters length")]
        [Display(Name = "Email Address")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Choose Password")]
        public string Password { get; set; }
        [Required(ErrorMessage = "The field {0} is required")]
        public int IsActive { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        public int IdClient { get; set; }
        public int IsUpdate { get; set; }

        public string FullName { get { return String.Format("{0} {1}", FirstName, LastName); }  }

        public int IdInspection { get; set; }

        public virtual ICollection<InspectionDaily> InspectionDailys { get; set; }

    }
}
