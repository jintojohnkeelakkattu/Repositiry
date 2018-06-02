
using System.ComponentModel.DataAnnotations;


namespace JobMaster.Service.ViewModels
{
    public class RegisterUser
    {
        [Required]
        [Display(Name = "User Name")]
        [StringLength(50, MinimumLength = 4)]
        public string UserName { get; set; }

        [Required]
        [Display(Name = "Email")]
        [StringLength(50)]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        [StringLength(50, MinimumLength = 5)]
        [CompareAttribute("ConfirmPassword", ErrorMessage = "The Password and Confirm Password fields did not match.")]
        public string Password { get; set; }


        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [StringLength(50, MinimumLength = 5)]
        [CompareAttribute("Password", ErrorMessage = "The Password and Confirm Password fields did not match.")]
        public string ConfirmPassword { get; set; }
    }
}
