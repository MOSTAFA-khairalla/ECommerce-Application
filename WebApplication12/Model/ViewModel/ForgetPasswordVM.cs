using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication12.Model.ViewModel
{
    public class ForgetPasswordVM
    {
        [Required(ErrorMessage = "Mail Requrid")]
        [EmailAddress(ErrorMessage = "U Must Enter Valid mail ")]
        public string Email { get; set; }
    }
}
