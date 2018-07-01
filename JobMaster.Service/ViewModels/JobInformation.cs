using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace JobMaster.Service.ViewModels
{
    public class JobInformation
    {
        [Required]
        [Display(Name = "Title")]
        [StringLength(50, MinimumLength = 4)]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Description")]
        [StringLength(500)]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Experience")]
        [StringLength(50, MinimumLength = 5)]
        public string Experience { get; set; }


        [Required]
        [Display(Name = "Company")]
        [StringLength(50, MinimumLength = 5)]
        public string Company { get; set; }

        [Required]
        [Display(Name = "Salary From")]
        [StringLength(50, MinimumLength = 5)]
        public string SalaryFrom { get; set; }

        [Required]
        [Display(Name = "Salary To")]
        [StringLength(50, MinimumLength = 5)]
        public string SalaryTo { get; set; }
    }
}
