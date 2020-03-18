using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LocalMealManagement.ViewModel
{
    public class AccountViewModel
    {
        [Required]
        public double Taka { get; set; }
        public string groupId { get; set; }
        public string subGroupId { get; set; }
        public string UserName { get; set; } 
    }
}
