using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LocalMealManagement.Models
{
    public class Groups
    {
        [Key]
        public int GroupId { get; set; }
        [Required]
        [StringLength(256)]
        public string GroupName { get; set; }
    }
}
