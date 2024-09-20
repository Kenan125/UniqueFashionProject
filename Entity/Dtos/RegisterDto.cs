using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Dtos
{
    public class RegisterDto
    {
        
        [Required(ErrorMessage = "First name cannot be empty!")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last name cannot be empty!")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Username cannot be empty!")]
        [Display(Name = "Username")]
        public string UserName { get; set; }
        
        
        public string Gender { get; set; }
        [Required(ErrorMessage = "Email address cannot be empty!")]
        [EmailAddress(ErrorMessage = "Invalid email format!")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password cannot be empty!")]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required(ErrorMessage = "Confirm password cannot be empty!")]
        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Passwords do not match!")]
        public string ConfirmPassword { get; set; }

        public string? ProfilePictureUrl { get; set; } = "/images/DefaultPfp.png";
    }
}
