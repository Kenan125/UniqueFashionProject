using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Dtos
{
    public class ChangePasswordDto
    {
        public string? CurrentPassword { get; set; }

        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string? NewPassword { get; set; }

        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        [Compare("NewPassword", ErrorMessage = "Passwords do not match!")]
        public string? ConfirmNewPassword { get; set; }
    }
}
