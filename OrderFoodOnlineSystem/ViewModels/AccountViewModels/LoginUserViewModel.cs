using Microsoft.AspNetCore.Authentication;
using System.ComponentModel.DataAnnotations;

namespace OrderFoodOnlineSystem.ViewModels.AccountViewModels
{
    public class LoginUserViewModel
    {
        [Required]
        [EmailAddress]
        [RegularExpression(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$", ErrorMessage = "Email is not valid.")]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Remember Me")]
        public bool RememberMe { get; set; }

        //Third-party login providers
        public IEnumerable<AuthenticationScheme> Schemes { get; set; } = new List<AuthenticationScheme>();
    }
}
