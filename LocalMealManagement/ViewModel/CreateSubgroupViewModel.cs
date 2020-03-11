using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LocalMealManagement.ViewModel
{
    public class CreateSubgroupViewModel
    {
        public int? Id { get; set; }
        [Required]
        public string SubGroupName { get; set; }
        public DateTime CreateDate { get; set; }

        [DisplayFormat(DataFormatString = "HH: MM")]
        [Display(Name = "Starting Time")]
        [DataType(DataType.Time)]
        public DateTime? StartDate { get; set; }

        [DisplayFormat(DataFormatString = "HH: MM")]
        [Display(Name = "Ending Time")]
        [DataType(DataType.Time)]
        public DateTime? EndDate { get; set; }
    }
}
