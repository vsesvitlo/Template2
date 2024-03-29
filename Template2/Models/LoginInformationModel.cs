using System;
using System.ComponentModel.DataAnnotations;
namespace Template2.Models
{
	public class LoginInformationModel
	{
        [Required]
        [StringLength(50)]
        [Display(Name = "First Name")]
        public string? FirstName{ get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Last Name")]
        public string? LastName { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Login")]
        public string? Login { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Your Email")]
        [EmailAddress]
        public string? Email { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Please, enter your password")]
        public string? Password{ get; set; }


        [Required]
        [StringLength(50)]
        [Display(Name = "Please, confirm your password")]
        public string? PasswordConfirm{ get; set; }

        [Required]
        public int? PhoneCode { get; set; }

        [Required]
        public int? PhoneNumber{ get; set; }
    }


}

