using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EmployeeManagement.EF.Entities
{
    public enum Gender
    {
        [Display(Name = "Kadın")]
        Female,
        [Display(Name = "Erkek")]
        Male
    }
}