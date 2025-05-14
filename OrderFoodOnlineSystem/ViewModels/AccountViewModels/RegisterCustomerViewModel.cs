using Microsoft.AspNetCore.Authentication;
using System.ComponentModel.DataAnnotations;

namespace OrderFoodOnlineSystem.ViewModels.AccountViewModels
{
    public class RegisterCustomerViewModel
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        [MinLength(1)]
        [RegularExpression("^[a-zA-Z]+$", ErrorMessage = "Name must contain only letters.")]
        public string FirstName { get; set; }

        [MaxLength(50)]
        [MinLength(1)]
        [RegularExpression("^[a-zA-Z]+$", ErrorMessage = "Name must contain only letters.")]
        public string? LastName { get; set; }

        [Required]
        [EmailAddress]
        [RegularExpression(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$", ErrorMessage = "Email is not valid.")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Compare("Password")]
        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        //Third-party login providers
        public IEnumerable<AuthenticationScheme> Schemes { get; set; } = new List<AuthenticationScheme>();
    }
}
