using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks; 

namespace LocalMealManagement.ViewModel 
{ 
    public class SubGroupViewModel 
    { 
        public int SubGroupId { get; set; } 
        public string SubGroupName { get; set; } 
        public DateTime SubGroupCreateDate { get; set; }
        public DateTime startDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
