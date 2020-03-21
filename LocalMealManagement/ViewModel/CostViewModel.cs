﻿using LocalMealManagement.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LocalMealManagement.ViewModel
{
    public class CostViewModel
    {
        [Required]
        public string Descriptions { get; set; }
        [Required]
        public double Taka { get; set; }
    }
    public class CostViewModelList : CostViewModel
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public virtual SubGroups SubGroups { get; set; }
        public virtual IdentityUser IdentityUser { get; set; }
    }
}
