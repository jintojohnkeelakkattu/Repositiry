using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace JobMaster.Service.ViewModels
{
    public class LoginUser
    {
        [Required]
        [Display(Name = "User Name")]
        [StringLength(50, MinimumLength = 4)]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        [StringLength(50, MinimumLength = 5)]
        public string Password { get; set; }

    }
}
