using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeMangment.Core.Model
{
    public class SignUpModel
    {
        [Required]
        public string UserName { get; set; } = "";
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = "";
        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Confirm Password should match with Password.")]
        public string ConfirmPassword { get; set; } = "";
        [Required]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string EmailID { get; set; } = "";
        [Required]
        [Phone(ErrorMessage = "Invalid Phone Number")]
        [StringLength(10,MinimumLength =10,ErrorMessage = "Mobile number must be 10 digits")]
        public string MobileNumber { get; set; } = "";
    }
}
