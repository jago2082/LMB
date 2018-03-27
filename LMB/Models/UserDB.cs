using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMB.Models
{
    public class UserDB
    {
        [Key]
        public int IDUser { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public int IsActive { get; set; }
        public int IdClient { get; set; }
        public int IsUpdate { get; set; }

    }
}
