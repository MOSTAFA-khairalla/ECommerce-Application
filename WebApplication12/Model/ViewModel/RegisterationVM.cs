using System.ComponentModel.DataAnnotations;
namespace WebApplication12.Model.ViewModel
{
    public class RegisterationVM
    {

        [Required(ErrorMessage ="Mail Requrid")]
        [EmailAddress(ErrorMessage ="U Must Enter Valid mail ")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password Requrid")]
        [DataType(DataType.Password)]
        [MinLength(3,ErrorMessage ="Min Length 3 ")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Password Requrid")]
        [DataType(DataType.Password)]
        [MinLength(3, ErrorMessage = "Min Length 3 ")]
        [Compare("Password", ErrorMessage ="Not Matching ")]
        [Display(Name ="Confrim passsword")]
        public string ConfrimPassword { get; set; }

    }
}
