using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication12.Model.ViewModel
{
    public class ResetPasswordVM
    {
        [Required(ErrorMessage = "Mail Requrid")]
        [EmailAddress(ErrorMessage = "U Must Enter Valid mail ")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password Requrid")]
        [DataType(DataType.Password)]
        [MinLength(3, ErrorMessage = "Min Length 3 ")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Password Requrid")]
        [DataType(DataType.Password)]
        [MinLength(3, ErrorMessage = "Min Length 3 ")]
        [Compare("Password", ErrorMessage = "Not Matching ")]
        [Display(Name = "Confrim passsword")]
        public string ConfrimPassword { get; set; }

        public string Token { get; set; }
    }
}
